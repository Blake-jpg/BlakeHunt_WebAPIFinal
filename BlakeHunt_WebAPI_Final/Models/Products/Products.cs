using System.ComponentModel.DataAnnotations;

namespace BlakeHunt_WebAPI_Final.Models.Products
{
    public class Product
    {
        [Key]
        public required int ProductID { get; set; }
        public required string ProductName { get; set; }
        public required string ProductDescription { get; set; }
        public required double Price { get; set; }
    }
}
