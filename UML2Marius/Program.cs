using PizzaLibrary.Exceptions;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using PizzaLibrary.Services;
using PizzaLibrary.Models;

ICustomerRepository cusRepo = new CustomerRepository();

Customer c1 = new("poul", "16161616", "Roskilde");

cusRepo.AddCustomer(c1);

cusRepo.PrintAllCustomers();

cusRepo.RemoveCustomer("14141414");

ICustomer c2;
c2 = cusRepo.GetCustomerByMobile("13131313");
Console.WriteLine(c2.ToString());

MenuItem m1 = new("Hawaii", 205, "Tomat, ost, skinke & ananas", MenuType.PIZZESPECIALI);

IMenuItemRepository menuItemRepo = new MenuItemRepository();

menuItemRepo.AddMenuItem(m1);

menuItemRepo.PrintAllMenuItems();

menuItemRepo.RemoveMenuItem(7);

menuItemRepo.PrintAllMenuItems();


Customer memberman = new("memberman", "00000000", "membership road 222");
memberman.ClubMember = true;
cusRepo.AddCustomer(memberman);
List<ICustomer> members;
members = cusRepo.GetAllMembers();
foreach (Customer customer in members) Console.WriteLine(customer.ToString());

List<ICustomer> roskilde;
roskilde = cusRepo.GetAllFromAddress("Roskilde");
foreach (Customer customer in roskilde) Console.WriteLine(customer.ToString());

List<IMenuItem> specialPizzas;
specialPizzas = menuItemRepo.GetAllFromType(MenuType.PIZZESPECIALI);
foreach (MenuItem menuItem in specialPizzas) Console.WriteLine(menuItem.ToString());

IMenuItem mostExpensive = menuItemRepo.GetMostExpensive();
IMenuItem mostExpensiveClassiche = menuItemRepo.GetMostExpensiveByType(MenuType.PIZZECLASSSICHE);
Console.WriteLine();
Console.WriteLine(mostExpensive.ToString());
Console.WriteLine(mostExpensiveClassiche.ToString());
menuItemRepo.PrintMenuByType();

Customer c3 = new VIPCustomer("mr importante", "11010100110", "cool avenue 123", 20);
MenuItem m2 = new Beverage("vodka", 50, "its just vodka", MenuType.DRIKKELSE, true);


Console.WriteLine("\n\n");
Customer c4 = new("poul 2", "16161616", "samme som poul");
try
{
    cusRepo.AddCustomer(c4);
}
catch (CustomerMobileNumberExists ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();

try
{
    Customer c5 = new VIPCustomer("cheater", "21848912489", "addydress 222", 90);
}
catch (InvalidDiscountException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("\n\n");

CompanyInfo comInfo;
comInfo = CompanyInfo.getInstance();
Console.WriteLine(comInfo.ToString());