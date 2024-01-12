using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
//snabbversion gjord guidad utav ChatGPT och Kollegor som kan c#.
class Program
{
    static List<Contact> contacts = new List<Contact>();

    static void Main()
    {
        contacts = LoadContacts();

        while (true)
        {
            Console.Clear(); // Rensa konsolen

            Console.WriteLine("Välkommen till adressboken!");
            Console.WriteLine("1. Lägg till kontakt");
            Console.WriteLine("2. Lista alla kontakter");
            Console.WriteLine("3. Visa detaljer för en kontakt");
            Console.WriteLine("4. Ta bort en kontakt (via e-post eller telefonnummer)");
            Console.WriteLine("5. Avsluta");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    ListContacts();
                    break;
                case "3":
                    ShowContactDetails();
                    break;
                case "4":
                    RemoveContact();
                    break;
                case "5":
                    SaveContacts();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                    break;
            }
        }
    }

    private static void AddContact()
    {
        Console.Clear(); 

        Console.WriteLine("Ange förnamn:");
        string firstName = Console.ReadLine();

        Console.WriteLine("Ange efternamn:");
        string lastName = Console.ReadLine();

        Console.WriteLine("Ange telefonnummer:");
        string phoneNumber = Console.ReadLine();

        Console.WriteLine("Ange e-postadress:");
        string emailAddress = Console.ReadLine();

        Console.WriteLine("Ange adressinformation:");
        string address = Console.ReadLine();

        Contact newContact = new Contact
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            EmailAddress = emailAddress,
            Address = address
        };

        contacts.Add(newContact);
        Console.WriteLine("Kontakt tillagd!\n");
        Console.WriteLine("Tryck på en tangent för att fortsätta...");
        Console.ReadKey();
    }

    private static void ListContacts()
    {
        Console.Clear(); 

        Console.WriteLine("Alla kontakter:\n");

        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName}");
        }

        Console.WriteLine("\nTryck på en tangent för att fortsätta...");
        Console.ReadKey();
    }

    private static void ShowContactDetails()
    {
        Console.Clear(); 

        Console.WriteLine("Ange e-postadress eller telefonnummer för kontakten du vill visa detaljer för:");
        string input = Console.ReadLine();

        var contactToDisplay = contacts.FirstOrDefault(c => c.EmailAddress == input || c.PhoneNumber == input);

        if (contactToDisplay != null)
        {
            Console.WriteLine("\nDetaljer för kontakten:\n");
            Console.WriteLine($"Förnamn: {contactToDisplay.FirstName}");
            Console.WriteLine($"Efternamn: {contactToDisplay.LastName}");
            Console.WriteLine($"Telefonnummer: {contactToDisplay.PhoneNumber}");
            Console.WriteLine($"E-postadress: {contactToDisplay.EmailAddress}");
            Console.WriteLine($"Adress: {contactToDisplay.Address}\n");
        }
        else
        {
            Console.WriteLine("Kontakten hittades inte.\n");
        }

        Console.WriteLine("Tryck på en tangent för att fortsätta...");
        Console.ReadKey();
    }

    private static void RemoveContact()
    {
        Console.Clear(); 

        Console.WriteLine("Ange e-postadress eller telefonnummer för kontakten du vill ta bort:");
        string input = Console.ReadLine();

        var contactToRemove = contacts.FirstOrDefault(c => c.EmailAddress == input || c.PhoneNumber == input);

        if (contactToRemove != null)
        {
            contacts.Remove(contactToRemove);
            Console.WriteLine("Kontakt borttagen!\n");
        }
        else
        {
            Console.WriteLine("Kontakten hittades inte.\n");
        }

        Console.WriteLine("Tryck på en tangent för att fortsätta...");
        Console.ReadKey();
    }
    /// <summary>
    /// Laddar in kontakter från json fil från "@desktop"/skrivbord.
    /// </summary>
    /// <returns></returns>
    private static List<Contact> LoadContacts()
    {
        try
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(Path.Combine(desktopPath, "contacts.json"));
            return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
        }
        catch (FileNotFoundException)
        {
            return new List<Contact>();
        }
    }

    private static void SaveContacts()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(Path.Combine(desktopPath, "contacts.json"), json);
    }
}

class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Address { get; set; }
}
