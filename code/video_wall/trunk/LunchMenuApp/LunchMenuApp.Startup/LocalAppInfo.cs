using VideoWall.Interfaces;

namespace LunchMenuApp.Startup
{
    /// <summary>
    /// The local app info is used for local development without the video wall framework.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public class LocalAppInfo : IVideoWallServiceProvider
    {
        #region Methods

        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetExtension<T>() where T : IVideoWallService
        {
            return default(T);
        }

        #endregion
    }
}