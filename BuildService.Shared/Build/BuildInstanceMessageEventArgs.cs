using System;
using System.Collections.Generic;
using System.Text;

namespace BuildService.Shared.Build;

public enum StandardOutputType
{
    Output,
    Error
}
public class BuildInstanceMessageEventArgs : EventArgs
{
    public StandardOutputType outputType { get; set; }
    public readonly long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    public string buildID { get; set; }
    public string? content { get; set; }
}