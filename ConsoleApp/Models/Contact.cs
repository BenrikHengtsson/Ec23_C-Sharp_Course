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
        public int Id {  get; set; } // gjorde detta pga testnings-video, fattar inte hur jag testar guid än att bara ev se om den printas?

        //public Guid Id {get; set;} = Guid.NewGuid();
        
    }
}
