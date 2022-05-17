using System;
using System.Collections.Generic;
using System.Text;
using BuildService.Shared.Build;
using BuildService.Shared.WebSocketService;

namespace BuildService.Shared.WebSocketProcessing
{
    public class AvailableBuildsMessage : ProcessableMessage
    {
        public override void Process(Server server, WebSocketServerWrapper wrapper)
        {
            List<BuildableItem> items = new List<BuildableItem>();

            foreach (BuildableItem child in server.BuildController.AvailableBuilds)
            {
                if (organization == @"*")
                {
                    items.Add(child);
                }
                else if (organization == child.Organization)
                {
                    if (repository == @"*")
                    {
                        items.Add(child);
                    }
                    else if (repository == child.Repository)
                    {
                        items.Add(child);
                    }
                }
            }

            wrapper.SendResponse(items.ToArray());
        }

        public string repository = @"*";
        public string organization = @"*";
    }
}