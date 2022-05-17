using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace BuildService.Shared.Build
{
    public class BuildInstance
    {
        private BuildController controller;

        public long StartTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        public long EndTimestamp;

        public BuildableItem TargetItem;
        
        public BuildInstance(BuildController _controller, BuildableItem buildableItem)
        {
            controller = _controller;
            TargetItem = buildableItem;
            StartInformation = new ProcessStartInfo();
            initalizeStartInformation();
        }

        public ProcessStartInfo StartInformation { get; private set; }
        public Process ScriptProcess { get; private set; }
        
        public string LogfileLocation { get; private set; }

        public string BuildLocation { get; private set; }
        
        private void initalizeStartInformation()
        {
            StartInformation.Environment.Add(@"basedir", controller.Options.BasePath);
            StartInformation.Environment.Add(@"basedir_repos", controller.Options.RepositoryBasePath);
            StartInformation.Environment.Add(@"basedir_builds", controller.Options.BuildOutputBasePath);
            
            StartInformation.Environment.Add(@"timestamp", StartTimestamp.ToString());
            StartInformation.Environment.Add(@"project_org", TargetItem.Organization);
            StartInformation.Environment.Add(@"project_repo", TargetItem.Repository);
            
            string buildOrgLocation = Path.Combine(controller.Options.BuildOutputBasePath, TargetItem.Organization);
            string buildRepoLocation = Path.Combine(buildOrgLocation, TargetItem.Repository);

            if (!Directory.Exists(buildOrgLocation))
                Directory.CreateDirectory(buildOrgLocation);
            if (!Directory.Exists(buildRepoLocation))
                Directory.CreateDirectory(buildRepoLocation);
            
            BuildLocation = Path.Combine(buildRepoLocation, StartTimestamp.ToString());
            if (!Directory.Exists(BuildLocation))
                Directory.CreateDirectory(BuildLocation);
            
            LogfileLocation = Path.Combine(BuildLocation, @"build.log");
            
            StartInformation.Environment.Add(@"project_repo_location", TargetItem.Location);
            StartInformation.Environment.Add(@"project_builds_all", buildRepoLocation);
            StartInformation.Environment.Add(@"build_outfolder", BuildLocation);
            StartInformation.Environment.Add(@"build_logfile", LogfileLocation);
            
            StartInformation.WorkingDirectory = Path.Combine(controller.Options.RepositoryBasePath,
                TargetItem.Organization, TargetItem.Repository);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                StartInformation.FileName = @"/usr/bin/bash";
                StartInformation.Arguments = Path.Combine(controller.Options.RepositoryBasePath,
                    TargetItem.Organization, TargetItem.Repository, @"build.sh");
            }
            else
            {
                StartInformation.FileName = @"build" + BuildService.Shared.MainClass.BuildScriptExtension;
            }
            StartInformation.UseShellExecute = false;
            StartInformation.RedirectStandardOutput = true;
            StartInformation.RedirectStandardError = true;
        }

        public async void Start()
        {
            EventWaitHandle waithandleSubprocess = new EventWaitHandle(false, EventResetMode.ManualReset);
            Thread threadSubprocess = new Thread(new ThreadStart(() => startThread(waithandleSubprocess)));
            
            threadSubprocess.Start();
            WaitHandle.WaitAll(new WaitHandle[] { waithandleSubprocess });
        }

        private void startThread(EventWaitHandle waitHandle)
        {
            BuildMessageEvent += new EventHandler<BuildInstanceMessageEventArgs>(HandleBuildMessageEvent);
            ScriptProcess = new Process();
            ScriptProcess.StartInfo = StartInformation;

            ScriptProcess.OutputDataReceived += new DataReceivedEventHandler((s, e) =>
            {
                var args = new BuildInstanceMessageEventArgs
                {
                    outputType = StandardOutputType.Output,
                    content = e.Data
                };
                OnBuildMessageEvent(args);
            });
            ScriptProcess.ErrorDataReceived += new DataReceivedEventHandler((s, e) =>
            {
                var args = new BuildInstanceMessageEventArgs
                {
                    outputType = StandardOutputType.Error,
                    content = e.Data
                };
                OnBuildMessageEvent(args);
            });

            ScriptProcess.Start();
            
            ScriptProcess.BeginOutputReadLine();
            ScriptProcess.BeginErrorReadLine();
            
            ScriptProcess.WaitForExit();
            waitHandle.Set();
        }

        public EventHandler<BuildInstanceMessageEventArgs> BuildMessageEvent;
        protected virtual void OnBuildMessageEvent(BuildInstanceMessageEventArgs e)
        {
            var handler = BuildMessageEvent;
            handler?.Invoke(this, e);
        }

        public void HandleBuildMessageEvent(object? sender, BuildInstanceMessageEventArgs args)
        {
            Console.WriteLine($@"{args.content}");
        }
    }
}