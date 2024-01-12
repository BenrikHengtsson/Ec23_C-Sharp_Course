using ConsoleApp.Interfaces;
using ConsoleApp.Models;

namespace ConsoleApp.Services;


public interface IMenuService 
{
    void RenderMainMenu();
    //void RenderAllContacts();

}


public class MenuService : IMenuService
{

    private readonly IContactService _contactService = new ContactService();


    public void RenderMainMenu()
    {
        Console.Clear();
        while (true)
        {
            RenderHeaderTitle("Main Menu");
            Console.WriteLine($"{"1.",-3} Add New Contact");
            Console.WriteLine($"{"2.",-3} View Contacts");
            Console.WriteLine($"{"3.",-3} Delete Contacts");
            Console.WriteLine($"{"0.",-3} Exit");
            Console.WriteLine();
            Console.Write("Enter Option: ");
            var option = Console.ReadLine();



            switch (option)
            {
                case "1":
                    RenderAddContactOption();
                    break;
                case "2":
                    RenderShowContactsOption();
                    break;
                case "3":
                    RenderAllContacts();
                    break;
                case "0":
                    RenderExitApplication();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\nInvalid Options, Press any key to continue..");
                    Console.ReadKey();
                    break;

            }
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

        var res = _contactService.AddContactToList(contact);

        switch (res.Status)
        {
            case Enums.ServiceStatus.SUCCESS:
                Console.WriteLine("\nContact Has Been Added!");
                break;
            case Enums.ServiceStatus.ALREADY_EXIST:
                Console.WriteLine("Contact already exist.");
                break;
            case Enums.ServiceStatus.FAILED:
                Console.WriteLine("Failed while tryng to add Contact..");
                Console.WriteLine("Error message : " + res.Result.ToString());
                break;
        }

        RenderPressAnyKey();
    }


    private void RenderRemoveContactOption()
    {

    }

    public void RenderShowContactsOption()
    {
        RenderHeaderTitle("Your Contacts:");
        var res = _contactService.GetContactsFromList();

        if (res.Status == Enums.ServiceStatus.SUCCESS)
        {
            if (res.Result is List<IContacts> contactlist)
            {
                if (!contactlist.Any())
                {
                    Console.WriteLine("No Contacts found");
                }
                else
                {
                    foreach (var contact in contactlist)
                    {
                        Console.WriteLine($"Nr:{contact.Id} Fullname: {contact.FirstName} {contact.LastName} Email: <{contact.Email}>");
                    }
                }
            }
        }
        {
            RenderPressAnyKey();
        }
    }



    private void RenderExitApplication()
    {
        Console.Clear();
        Console.Write("Do you want to exit this application? (y/n)");
        var option = Console.ReadLine() ?? "";

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
            Environment.Exit(0);
    }


    private void UpdateContactOption()
    {

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

    private void RenderPressAnyKey()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void RenderAllContacts()
    {
        RenderHeaderTitle("Your Contacts:");
        var res = _contactService.GetContactsFromList();

        if (res.Result is List<IContacts> contactlist)
        {
            if (!contactlist.Any())
            {
                Console.WriteLine("You have 0 Contacts.");
            }
            else
            {
                foreach (var contact in contactlist)
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}>");
                }
            }

            Console.WriteLine($"{"1.",-3} Delete Contact By Email");
            var option = Console.ReadLine() ?? "";
            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter the email to delete contact:");
                    var emailToDelete = Console.ReadLine();
                    _contactService.DeleteContactByEmail(emailToDelete);
                    break;
                case "0":
                    RenderMainMenu();
                    break;
            }

        }
    }
}


