using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Services
{
    public class PostersService : IPostersService
    {


        private readonly  List<IPoster> _posters = new List<IPoster>();

        public  PostersService()
        {
            var files = Directory.GetFiles(@"...\...\...\Resources", "*.xps");
            foreach (var file in files)
            {
                _posters.Add(new Poster(file));
            }
        }

        public List<IPoster> Posters
        {
            get { return _posters; }
        }
    }
}
