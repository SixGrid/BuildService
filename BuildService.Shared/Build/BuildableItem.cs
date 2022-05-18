using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BuildService.Shared.Build
{
    public class BuildableItem
    {
        private BuildController controller;
        
        public BuildableItem(BuildController controller, string repositoryRelativeLocation)
        {
            this.controller = controller;
            RelativeLocation = repositoryRelativeLocation;

            if (!Directory.Exists(Path.Combine(controller.Options.BuildOutputBasePath, Organization, Repository,
                    @"latest")))
                Directory.CreateDirectory(Path.Combine(controller.Options.BuildOutputBasePath, Organization, Repository,
                    @"latest"));
        }

        public string RelativeLocation { get; private set; }
        public string[] RelativeLocationSplit => RelativeLocation.Split(@"/");

        public string Location => Path.Combine(controller.Options.RepositoryBasePath, RelativeLocation);
        public string Organization => RelativeLocationSplit[0];
        public string Repository => RelativeLocationSplit[1];
        public string Branch = @"default";

        public string ToJson() => JsonConvert.SerializeObject(this);

        public BuildStatus CurrentBuildStatus = BuildStatus.ReadyToBuild;
        public string LatestBuildID = string.Empty;
        public BuildInstance? CreateBuild()
        {
            if (CurrentBuildStatus == BuildStatus.InProgress) return null;
            var buildable = controller.GetBuildable(RelativeLocation);
            if (buildable == null) return null;
            return controller.Server.BuildController != null ? new BuildInstance(controller.Server.BuildController, buildable) : null;
        }
    }
}