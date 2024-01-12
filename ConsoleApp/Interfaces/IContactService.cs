using ConsoleApp.Models.Responses;

namespace ConsoleApp.Interfaces;

public interface IContactService
{
    IServiceResult AddContactToList(IContacts contact);
    bool AddToList(IContacts contact);
 
    //ServiceResult GetContactByEmailFromList(Func<Contact, bool> predicate);
    IServiceResult GetContactsFromList();

    IServiceResult DeleteContactByEmail(string email);

  





    //ServiceResult UdateContactInList(Contact contact);
    //ServiceResult DeleteContactFromList(Func<Contact, bool> predicate);

    // func eller i kontext - Func<Contact, bool> predicate == lambda expression (Contact)=> Contact.FirstName == "Henke"
}
