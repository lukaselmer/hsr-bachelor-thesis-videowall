using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using PosterApp.ResourceLoader.Properties;

namespace PosterApp.ResourceLoader
{
    public class ResourceLoader
    {
        public ResourceLoader()
        {
            var a = Assembly.GetExecutingAssembly();
            Console.WriteLine(a);
            //var x = Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, false, false);
            //var z = Resources.ResourceManager.ResourceSetType;
            //Console.WriteLine(x);
        }
    }
}
