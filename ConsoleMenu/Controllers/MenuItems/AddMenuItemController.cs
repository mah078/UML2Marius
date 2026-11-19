using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenu.Controllers.MenuItems
{
    public class AddMenuItemController
    {
        IMenuItemRepository _menuItemRepository;
        public MenuItem MenuItem { get; set; }

        public AddMenuItemController(string name, double price, string description, MenuType menuType, IMenuItemRepository menuItemRepository)
        {

            MenuItem = new MenuItem(name, price, description, menuType);
            _menuItemRepository = menuItemRepository;
        }

        public void AddMenuType()
        {
            _menuItemRepository.AddMenuItem(MenuItem);
        }


    }
}
