using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace BuildService.Shared.Build
{
    public struct BuildControllerOptions
    {
        public string BasePath { get; set; }
        public string RepositoryBasePath => Path.Combine(BasePath, @"repos");

        public string BuildOutputBasePath => Path.Combine(BasePath, @"builds");
    }
    public class BuildController
    {
        public BuildControllerOptions Options { get; private set; }
        public Server Server;
        public string BuildHistoryDirectory => Path.Combine(Directory.GetCurrentDirectory(), @"buildhistory");

        public BuildController(Server server, BuildControllerOptions options)
        {
            Server = server;
            Options = options;
            if (!Directory.Exists(Options.BasePath))
                Directory.CreateDirectory(Options.BasePath);
            if (!Directory.Exists(Options.RepositoryBasePath))
                Directory.CreateDirectory(Options.RepositoryBasePath);
            if (!Directory.Exists(Options.BuildOutputBasePath))
                Directory.CreateDirectory(Options.BuildOutputBasePath);
            if (!Directory.Exists(BuildHistoryDirectory))
                Directory.CreateDirectory(BuildHistoryDirectory);
            updateBuildHistory();
            updateAvailableBuilds();
        }

        public List<BuildHistoryObject> BuildHistory = new List<BuildHistoryObject>();

        public BuildHistoryObject GetByID(string id)
        {
            foreach (BuildHistoryObject build in BuildHistory)
            {
                if (build.ID == id)
                {
                    return build;
                }
            }
            return null;
        }
        public List<BuildHistoryObject> GetByOrganization(string organization)
        {
            List<BuildHistoryObject> itemList = new List<BuildHistoryObject>();
            foreach (BuildHistoryObject item in BuildHistory)
            {
                if (item.Organization == organization)
                    itemList.Add(item);
            }
            return itemList;
        }
        public List<BuildHistoryObject> GetByRepository(string organization, string repository)
        {
            List<BuildHistoryObject> itemList = new List<BuildHistoryObject>();
            foreach (BuildHistoryObject item in GetByOrganization(organization))
            {
                if (item.Repository == repository)
                    itemList.Add(item);
            }
            return itemList;
        }
        private void updateBuildHistory()
        {
            Regex filenameExpression = new Regex(@"(\/|\\\\)[a-zA-Z0-9_\-]{1,}\.bhis$", RegexOptions.IgnoreCase);

            string[] files = Directory.GetFiles(BuildHistoryDirectory);

            List<BuildHistoryObject> buildHistory = new List<BuildHistoryObject>();

            foreach (string filename in files)
            {
                Match regexMatch = filenameExpression.Match(filename);
                if (!regexMatch.Success)
                    continue;
                BuildHistoryObject item = parseBuildHistoryFile(filename);
                if (item != null)
                {
                    buildHistory.Add(item);
                }
            }

            BuildHistory = buildHistory;
        }

        private void updateAvailableBuilds()
        {
            List<string> availableBuilds = new List<string>();

            string[] repoDirectories = Directory.GetDirectories(Options.RepositoryBasePath);
            foreach (string repo in repoDirectories)
            {
                FileAttributes attr = File.GetAttributes(repo);
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    foreach (string child in Directory.GetDirectories(repo))
                    {
                        string buildScriptLocation = Path.Combine(child,
                            String.Format(@"build{0}", MainClass.BuildScriptExtension));
                        if (File.Exists(buildScriptLocation))
                            availableBuilds.Add(Path.GetFileName(repo) + @"/" + Path.GetFileName(child));
                    }
                }
            }
            
            Console.WriteLine(availableBuilds.Count);
        }
        
        private BuildHistoryObject parseBuildHistoryFile(string filename)
        {
            BuildHistoryObject obj = new BuildHistoryObject(filename);
            return obj.Valid ? obj : null;
        }
    }
}
