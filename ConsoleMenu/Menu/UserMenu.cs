using System;
using System.Collections.Generic;
using System.Text;
using PizzaLibrary.Services;
using PizzaLibrary.Models;
using ConsoleMenu.Controllers.Customers;
using ConsoleMenu.Controllers.MenuItems;
using PizzaLibrary.Exceptions;

namespace ConsoleMenu.Menu
{
    public class UserMenu
    {
        private static string mainMenuChoices = "\t1.Vis Pizzamenu\n\t2.Vis Kunder\n\t3.Add Customer\n\t4.add menu item\n\t5.remove menu item\n\tQ.Afslut\n\n\tIndtast valg:";

        private CustomerRepository _customerRepository = new CustomerRepository();
        private MenuItemRepository _menuItemRepository = new MenuItemRepository();
        private static string ReadChoice(string choices)
        {
            Console.Clear();
            Console.Write(choices);
            string choice = Console.ReadLine();
            Console.Clear();
            return choice.ToLower();
        }
        public void ShowMenu()
        {
            string theChoice = ReadChoice(mainMenuChoices);
            while (theChoice != "q")
            {
                switch (theChoice)
                {
                    case "1":
                        Console.WriteLine("Valg 1");
                        ShowMenuItemController showMenuItemController = new ShowMenuItemController(_menuItemRepository);
                        showMenuItemController.ShowAllMenuItems();
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Valg 2");
                        _customerRepository.PrintAllCustomers();
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Valg 3");
                        Console.WriteLine("Indlæs navn:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Indlæs mobil nr:");
                        string mobile = Console.ReadLine();
                        Console.WriteLine("Indlæs adresse:");
                        string address = Console.ReadLine();
                        Console.WriteLine("Vil du være clubmember y/n");
                        string clubMemberString = Console.ReadLine().ToLower();
                        bool isClubMember = (clubMemberString[0] == 'y') ? true : false;
                        AddCustomerController addCustomerController = new AddCustomerController(name, mobile, address, isClubMember, _customerRepository);
                        try
                        {
                            addCustomerController.AddCustomer();
                        }
                        catch (CustomerMobileNumberExists ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadLine();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "4":
                        Console.WriteLine("valg 4 - tilføj menu item");
                        Console.WriteLine("indlæs navn");
                        string menuName = Console.ReadLine();
                        Console.WriteLine("indlæs pris");
                        double price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("indlæs beskrivelse");
                        string description = Console.ReadLine();
                        Console.WriteLine("angiv type");
                        foreach(MenuType thisMenuType in Enum.GetValues(typeof(MenuType)))
                        {
                            Console.Write((int)thisMenuType + " ");
                            Console.WriteLine(thisMenuType);
                        }
                        MenuType menuType = (MenuType) Convert.ToInt32(Console.ReadLine());
                        AddMenuItemController addMenuItemController = new(menuName, price, description, menuType, _menuItemRepository);
                        addMenuItemController.AddMenuType();
                        break;
                    case "5":
                        Console.WriteLine("valg 5 - fjern menu item");
                        Console.WriteLine("hvilket menu item skal fjernes?");
                        ShowMenuItemController showMenuItemController2 = new(_menuItemRepository);
                        showMenuItemController2.ShowAllMenuItems();
                        int itemNumber = Convert.ToInt32(Console.ReadLine());
                        _menuItemRepository.RemoveMenuItem(itemNumber);

                        break;

                    default:
                        Console.WriteLine("Angiv et tal fra 1-5 eller q for afslut");
                        break;
                }
                theChoice = ReadChoice(mainMenuChoices);
            }
        }

    }

}
