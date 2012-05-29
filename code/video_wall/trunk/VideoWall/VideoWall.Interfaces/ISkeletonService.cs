namespace VideoWall.Interfaces
{
    /// <summary>
    /// The skeleton service provides the skeletal tracking
    /// </summary>
    public interface ISkeletonService : IVideoWallService
    {
        event SkeletonChangedEvent SkeletonChanged;
    }
}