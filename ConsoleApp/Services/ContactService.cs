using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using ConsoleApp.Models.Responses;
using System.Diagnostics;



namespace ConsoleApp.Services;


public class ContactService : IContactService
{
  private static readonly List<IContacts>   _contacts = new List<IContacts>(); //_contacts = []; senaste sättet att göra lista...

	public IServiceResult AddContactToList(IContacts contact)
	{
		IServiceResult response = new ServiceResult();
		try
		{
			if (!_contacts.Any(x => x.Email == contact.Email))
			{
				_contacts.Add(contact);
				response.Status = Enums.ServiceStatus.SUCCESS;
			}
			else
			{
				response.Status = Enums.ServiceStatus.ALREADY_EXIST;
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			response.Status = Enums.ServiceStatus.FAILED;
			response.Result = ex.Message;
		}
		return response;
	}

   

    IServiceResult IContactService.GetContactsFromList()
	{
		IServiceResult response = new ServiceResult();
		try
		{
			response.Status = Enums.ServiceStatus.SUCCESS;
			response.Result = _contacts;
        }
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			response.Status = Enums.ServiceStatus.FAILED;
			response.Result = ex.Message;
		}
		return response;


    }

	/// <summary>
	/// Only used for testing in ConsoleApp.Tests
	/// </summary>
	/// <param name="contact"></param>
	/// <returns></returns>
    public bool AddToList(IContacts contact)
    {
		try
		{
			contact.Id = _contacts.Count + 1;	
			_contacts.Add(contact);
			return true;
		}
		catch (Exception ex) { Debug.WriteLine(ex.Message);}
        return false;

    }

    public static IEnumerable<IContacts> GetAllFromList()
    {
        try
        {
			return _contacts;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
    /// <summary>
    /// /////vettefan om detta funkar
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    public IServiceResult DeleteContactByEmail(string email)
    {
        IServiceResult response = new ServiceResult();
        try
        {
            var contactToRemove = _contacts.FirstOrDefault(x => x.Email == email);
            if (contactToRemove != null)
            {
                _contacts.Remove(contactToRemove);
                response.Status = Enums.ServiceStatus.SUCCESS;
            }
            else
            {
                response.Status = Enums.ServiceStatus.NOT_FOUND; // Add this status if the contact is not found
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = Enums.ServiceStatus.FAILED;
            response.Result = ex.Message;
        }
        return response;
    }
}

   