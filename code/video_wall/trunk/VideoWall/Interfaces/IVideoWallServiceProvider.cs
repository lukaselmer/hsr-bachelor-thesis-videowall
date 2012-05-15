using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    /// <summary>
    /// Provides services for the video wall, like hand tracking, skeleton tracking or a file service
    /// </summary>
    public interface IVideoWallServiceProvider
    {
        /// <summary>
        /// Gets an implementation of the interface <typeparam name="T"></typeparam> which is provided by the video wall
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetExtension<T>() where T : IVideoWallService;
    }

    /// <summary>
    /// Marker interface: represents a video wall extension
    /// </summary>
    public interface IVideoWallService { }

    /// <summary>
    /// The file service provides a directory where an exension has read and write access
    /// </summary>
    public interface IFileService : IVideoWallService
    {
        /// <summary>
        /// Gets the path to the resource directory
        /// </summary>
        string ResourceDirectory { get; }
    }

    // TODO: define more interfaces (if needed)
}
