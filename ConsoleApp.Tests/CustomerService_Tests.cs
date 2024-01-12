using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using ConsoleApp.Models.Responses;
using ConsoleApp.Services;

namespace ConsoleApp.Tests;

/// <summary>
/// I dont really know wjat im doing, i think i understand..but im not 100% sure.
/// Cause im stil wrapping my head around Interfaces and this designpattern way of thinking.
/// not really sure aswell how to implement on my own services etc, at least for now. Tried testing my IServiceResult but i got confused...
/// </summary>

public class CustomerService_Tests
{
    [Fact]
    public void AddToListsShould_AddOneContact_InContactList_ThenReturnTrue()
    {
        //Arange
        IContacts contact = new Contact { FirstName = "TestJohan", LastName = "TestAndersson", Email = "Test@domain.com" };
        IContactService contactService = new ContactService();

        //Act
        var result = contactService.AddToList(contact);
        //IServiceResult result = ///

        //Assert
        Assert.True(result);

    }

    [Fact]
    public void GetAllFromListShould_GetAllContactsInContactList_ThenReturnTrue()
    {
        //Arrange
        IContactService contactService = new ContactService();
        IContacts contact = new Contact { FirstName = "TestJohan", LastName = "TestAndersson", Email = "Test@domain.com" };
        contactService.AddToList(contact);

        //Act
        IEnumerable<IContacts> result = ContactService.GetAllFromList();

        //Assert
        Assert.NotNull(result);
        Assert.True(((IEnumerable<IContacts>)result).Any()); //fick inte rött här som i videon. INGEN ANING om VARFÖR?
        IContacts returned_contact = result.FirstOrDefault()!;
        Assert.NotNull(returned_contact);
        Assert.Equal(contact.FirstName, returned_contact.FirstName);
        Assert.Equal(1, returned_contact.Id);

    }
}
