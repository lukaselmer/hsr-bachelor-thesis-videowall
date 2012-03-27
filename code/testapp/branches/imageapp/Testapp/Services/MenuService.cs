using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Services
{
    public class MenuService
    {

        //private readonly List<Menu> _menu = new List<Menu>();
        private String fileString;

        public  MenuService()
        {
            var files = Directory.GetFiles(@"...\...\...\Resources\menu", "*.xps");
            fileString = files.First();
           // _menu.Add(new Menu(files.First()));
            
        }

        public Menu Menu
        {
            get { return new Menu(fileString); }
        }
        
    }
}
