namespace BuildService.Shared.Build;

public class BuildInstanceStatus
{
    private BuildInstance _instance;
    public BuildInstanceStatus(BuildInstance instance, BuildStatus status)
    {
        _instance = instance;
        Status = status;
        BuildID = instance.BuildID;
        Signature = instance.TargetItem.RelativeLocation;
    }

    public BuildStatus Status { get; private set; }
    public long Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    public string BuildID { get; private set; }
    public string Signature { get; private set; }
    public long StartTimestamp => _instance.StartTimestamp;
    public long? EndTimestamp => _instance.EndTimestamp;
}