﻿namespace ConsoleApp.Interfaces
{
    public interface IContacts
    {
        string Address { get; set; }
        string City { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string? PhoneNumber { get; set; }
        string PostalCode { get; set; }
        //Guid Id { get; set; }
        int Id {  get; set; }
       
    }
}