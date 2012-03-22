using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Services;

namespace UserInterface
{
    public class MenuWindowViewModel
    {
        public MenuWindowViewModel(MenuService menuService)
        {
            CurrentMenu = menuService.Menu;
        }

        public Menu CurrentMenu { get; set; }
    }
}
