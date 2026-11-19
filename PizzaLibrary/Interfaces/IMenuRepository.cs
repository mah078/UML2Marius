using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Interfaces
{
    public interface IMenuItemRepository
    {
        int Count { get; }
        List<IMenuItem> GetAll();
        void AddMenuItem(IMenuItem menuItem);
        IMenuItem GetMenuItemByNo(int no);
        void RemoveMenuItem(int no);

        void PrintAllMenuItems();
        List<IMenuItem> GetAllFromType(MenuType menuType);
        IMenuItem GetMostExpensiveByType(MenuType menuType);
        IMenuItem GetMostExpensive();
        void PrintMenuByType();

    }

}
