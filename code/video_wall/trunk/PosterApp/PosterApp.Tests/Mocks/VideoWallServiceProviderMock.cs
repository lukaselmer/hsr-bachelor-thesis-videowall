#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using Microsoft.Practices.Unity;
using VideoWall.Interfaces;

#endregion

namespace PosterApp.Tests.Mocks
{
    public class VideoWallServiceProviderMock : IVideoWallServiceProvider
    {
        #region IVideoWallServiceProvider Members

        /// <summary>
        ///   Gets an implementation of the interface which is provided by the video wall.
        /// </summary>
        /// <typeparam name="T"> The interface of a specific video wall service. </typeparam>
        /// <returns> A video wall service implementation. </returns>
        public T GetExtension<T>() where T : IVideoWallService
        {
            var container = new UnityContainer();
            container.RegisterInstance<IFileService>(new FileServiceMock());
            return container.Resolve<T>();
        }

        #endregion
    }
}
