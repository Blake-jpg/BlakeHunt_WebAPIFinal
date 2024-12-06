using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BlakeHunt_WebAPI_Final.Models.customers
{
    //multiple classes doesn't help towards isolation, but displays steps towards normalization.
    public class Customer
    {
        [Key]
        public required int CustId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [AllowNull]
        public string? BirthDate { get; set; }


        //foreign keys
        public ICollection<Address> AddressAddr { get; set; }
        public ICollection<Phone> PhoneAddr { get; set; }
    }
    public class Phone
    {
        [Key]
        public required int PhoneId { get; set; }
        public required string PhoneNumber { get; set; }
        public required int CustId { get; set; }
    }
    public class Address
    {
        [Key]
        public required int AddressId { get; set; }
        public required string StreetAdress { get; set; }
        public required string City { get; set; }
        [AllowNull]
        public string? State { get; set; }
        public required string Country { get; set; }
        public required int CustId { get; set; }
    }
}
