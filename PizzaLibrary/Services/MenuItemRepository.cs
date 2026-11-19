using PizzaLibrary.Data;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Services
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private List<IMenuItem> _menuItemList;
        public MenuItemRepository()
        {
            _menuItemList = MockData.MenuItemData;
        }

        public int Count { get { return _menuItemList.Count(); } }

        public void AddMenuItem(IMenuItem menuItem)
        {
            if (GetMenuItemByNo(menuItem.No) != null) _menuItemList.Add(menuItem);
        }

        public List<IMenuItem> GetAll()
        {
            return _menuItemList;
        }

        public IMenuItem GetMenuItemByNo(int no)
        {
            foreach(IMenuItem menuItem in _menuItemList)
            {
                if (menuItem.No == no) return menuItem;
            }
            return null;
        }

        public void PrintAllMenuItems()
        {
            foreach (IMenuItem menuItem in _menuItemList)
            {
                Console.WriteLine(menuItem.ToString());
            }
            
        }

        public void RemoveMenuItem(int no)
        {
          
            //for (int i = 0; i<_menuItemList.Count; i++)
            //{
            //    if (_menuItemList[i].No == no) _menuItemList.Remove(_menuItemList[i]);
                
            //}
            IMenuItem menuItem = GetMenuItemByNo(no);
            _menuItemList.Remove(menuItem);
        }
        public List<IMenuItem> GetAllFromType(MenuType menuType)
        {
            List<IMenuItem> returnList = new();
            foreach (IMenuItem menuItem in _menuItemList)
            {
                if (menuItem.TheMenuType == menuType) returnList.Add(menuItem);
            }
            return returnList;
        }
        public IMenuItem GetMostExpensiveByType(MenuType menuType)
        {
            List<IMenuItem> typeItems = GetAllFromType(menuType);
            if (typeItems.Count > 0)
            {
                IMenuItem returnItem = typeItems[0];
                foreach (MenuItem menuItem in typeItems)
                {
                    if (menuItem.Price > returnItem.Price) returnItem = menuItem;
                }
                return returnItem;
            }
            return null;
        }
        public IMenuItem GetMostExpensive()
        {
            
            if (_menuItemList.Count > 0)
            {
                IMenuItem returnItem = _menuItemList[0];
                foreach (MenuItem menuItem in _menuItemList)
                {
                    if (menuItem.Price > returnItem.Price) returnItem = menuItem;
                }
                return returnItem;
            }
            return null;
        }
        public void PrintMenuByType()
        {
            foreach (MenuType menuType in Enum.GetValues(typeof(MenuType)))
            {
                Console.WriteLine($"----- all items of type {menuType} -----");
                List<IMenuItem> menuList = GetAllFromType(menuType);
                foreach (MenuItem menuItem in menuList)
                {
                    Console.WriteLine(menuItem.ToString());
                }
            }
        }
    }
}
