using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenu.Controllers.MenuItems
{
    public class RemoveMenuItemController
    {
        IMenuItemRepository _menuItemRepository;
        public int Number { get; set; }

        public RemoveMenuItemController(int number, IMenuItemRepository menuItemRepository)
        {

            Number = number;
            _menuItemRepository = menuItemRepository;
        }

        public void RemoveMenuItem()
        {
            _menuItemRepository.RemoveMenuItem(Number);
        }


    }
}
