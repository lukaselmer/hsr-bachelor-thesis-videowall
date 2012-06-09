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

using System;
using System.Reflection;

#endregion

namespace PosterApp.ResourceLoader
{
    public class ResourceLoader
    {
        #region Constructors / Destructor

        public ResourceLoader()
        {
            var a = Assembly.GetExecutingAssembly();
            Console.WriteLine(a);
        }

        #endregion
    }
}
