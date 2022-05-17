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
    public string content { get; set; }
}