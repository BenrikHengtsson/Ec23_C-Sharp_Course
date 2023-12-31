using ConsoleApp.Interfaces;

namespace ConsoleApp.Models
{
    public class Contact : IContacts
    {
        public string? PhoneNumber { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;




    }
}
