using BlakeHunt_WebAPI_Final.Models.customers;
using BlakeHunt_WebAPI_Final.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace BlakeHunt_WebAPI_Final.Models.orders
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public double Total { get; set; }

        //foreign keys
        public  ICollection<customers.Customer> CustAddr { get; set; }
        public  ICollection<Product> ProductAddr { get; set; }
    }
}
