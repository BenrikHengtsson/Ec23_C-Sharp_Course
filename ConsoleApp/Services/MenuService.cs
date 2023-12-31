using ConsoleApp.Interfaces;
using ConsoleApp.Models;

namespace ConsoleApp.Services;

public interface IMenuService 
{
    void RenderMainMenu();

}

/// <summary>
/// Adds a Main Menu blueprint in console for user.
/// </summary>
public class MenuService : IMenuService
{
    public void RenderMainMenu()
    {
        while (true) 
        {
            RenderHeaderTitle("Main Menu");
            Console.WriteLine($"{"1.", -3} Add New Contact");
            Console.WriteLine($"{"2.", -3} View Contact");
            Console.WriteLine($"{"0.",-3} Exit");
            Console.WriteLine();
            Console.Write("Enter Option: ");
            var option= Console.ReadLine();

            switch (option)
            {
                case "1":
                    RenderAddContactOption();
                    break;
                case "2":RenderShowContactsOption();
                    break;
                case "0": RenderExitApplication();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\nInvalid Options, Press any key to continue..");
                    Console.ReadKey();
                    break;

            }
            Console.ReadKey();
        }
    }


    private void RenderAddContactOption()
    {
        IContacts contact = new Contact();

        RenderHeaderTitle("Add New Contact");
        Console.Write("First Name: ");
        contact.FirstName = Console.ReadLine() ?? "";
        Console.Write("Last Name: ");
        contact.LastName = Console.ReadLine() ?? "";
        Console.Write("Email: ");
        contact.Email = Console.ReadLine() ?? "";
        Console.Write("Phone Number: ");
        contact.PhoneNumber = Console.ReadLine() ?? "";
        Console.Write("Adress: ");
        contact.Address = Console.ReadLine() ?? "";
        Console.Write("City: ");
        contact.City = Console.ReadLine() ?? "";
        Console.Write("Postal Code: ");
        contact.PostalCode = Console.ReadLine() ?? "";
    }

    private void RenderRemoveContactOption()
    {
        throw new NotImplementedException();
    }

    private void RenderShowContactsOption()
    {
        throw new NotImplementedException();
    }

    private void RenderExitApplication()
    {
        Console.Clear();
        Console.WriteLine("Do you want to exit this application? (y/n)");
        var option = Console.ReadLine() ?? "";

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
            Environment.Exit(0);
    }
    private void UpdateContactOption()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Render app-Name and variable "topmenu" slot.
    /// </summary>
    /// <param name="title"></param>
    private void RenderHeaderTitle(string title) 
    {
        Console.Clear();
        Console.WriteLine("####  ADRESSBOOK  ####");
        Console.WriteLine();
        Console.WriteLine($"-¤¤-  {title}  -¤¤-");
        Console.WriteLine();
    }
}
