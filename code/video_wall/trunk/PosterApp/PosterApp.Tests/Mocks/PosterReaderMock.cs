using System.Collections.Generic;
using PosterApp.Data.Implementation;
using PosterApp.Data.Interfaces;

namespace PosterApp.Tests.Mocks
{
    /// <summary>
    /// A mock implementing the poster reader interface.
    /// </summary>
    public class PosterReaderMock : IPosterReader
    {
        readonly IPosterReader _mock = new PosterReader(new VideoWallServiceProviderMock());

        /// <summary>
        ///   Gets the files.
        /// </summary>
        public IEnumerable<string> Files { get { return _mock.Files; } }
    }
}