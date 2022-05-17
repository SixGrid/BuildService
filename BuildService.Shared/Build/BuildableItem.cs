using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BuildService.Shared.Build
{
    public class BuildableItem
    {
        private BuildController controller;
        
        public BuildableItem(BuildController _controller, string repositoryRelativeLocation)
        {
            controller = _controller;
            RelativeLocation = repositoryRelativeLocation;
        }

        public string RelativeLocation { get; private set; }
        public string[] RelativeLocationSplit => RelativeLocation.Split(@"/");

        public string Location => Path.Combine(controller.Options.RepositoryBasePath, RelativeLocation);
        public string Organization => RelativeLocationSplit[0];
        public string Repository => RelativeLocationSplit[1];
        public string Branch = @"default";

        public string ToJson() => JsonConvert.SerializeObject(this);
    }
}