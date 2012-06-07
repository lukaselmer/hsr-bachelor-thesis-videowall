using System.Collections.Generic;
using System.Linq;
using PosterApp.ServiceModels.Implementation;
using PosterApp.ServiceModels.Interfaces;

namespace PosterApp.Tests.Mocks
{
    /// <summary>
    /// A mock implementing the poster service interface.
    /// </summary>
    public class PosterServiceMock : IPosterService
    {
        private readonly IEnumerable<Poster> _mock = new PosterReaderMock().Files.Select(f => new Poster(f));
        /// <summary>
        ///   Gets the posters.
        /// </summary>
        /// <value> The posters. </value>
        public IEnumerable<IPoster> Posters { get { return _mock; } }
    }
}