using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public interface IPostersService
    {
        List<IPoster> Posters { get; }
    }
}
