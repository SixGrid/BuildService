using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            BuildLocation = Path.Combine(buildRepoLocation, StartTimestamp.ToString());

            LogfileLocation = Path.Combine(BuildLocation, @"build.log");
            
            StartInformation.Environment.Add(@"project_repo_location", TargetItem.Location);
            StartInformation.Environment.Add(@"project_builds_all", buildRepoLocation);
            StartInformation.Environment.Add(@"build_outfolder", BuildLocation);
            StartInformation.Environment.Add(@"build_logfile", LogfileLocation);
            
            
            StartInformation.WorkingDirectory = Path.Combine(controller.Options.BuildOutputBasePath,
                TargetItem.Organization, TargetItem.Repository);
            StartInformation.FileName = Path.Combine(StartInformation.WorkingDirectory,
                @"build" + BuildService.Shared.MainClass.BuildScriptExtension);
            StartInformation.WindowStyle = ProcessWindowStyle.Normal;

            ScriptProcess = new Process();
            ScriptProcess.StartInfo = StartInformation;
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
            ScriptProcess.Start();
            while (ScriptProcess.StandardOutput.Peek() >= 0)
            {
                var args = new BuildInstanceMessageEventArgs();
                args.outputType = StandardOutputType.Output;
                args.content = ScriptProcess.StandardOutput.ReadLine() ?? string.Empty;
                OnBuildMessageEvent(args);
            }
            ScriptProcess.WaitForExit();
            waitHandle.Set();
        }

        public EventHandler<BuildInstanceMessageEventArgs> BuildMessageEvent;
        protected virtual void OnBuildMessageEvent(BuildInstanceMessageEventArgs e)
        {
            var handler = BuildMessageEvent;
            handler?.Invoke(this, e);
        }
    }
}