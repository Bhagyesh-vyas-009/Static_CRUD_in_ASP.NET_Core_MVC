using System.ComponentModel.DataAnnotations;

namespace Static_CRUD.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        //[StringLength(50)]
        [Required(ErrorMessage = "ProductName is required")]
        public string? ProductName { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Product Price is required")]
        public double ProductPrice { get; set; }

        public string ProductCode { get; set; }

        [MaxLength(10000)]
        [MinLength(10)]
        public string Description { get; set; }

        public int UserID { get; set; }
    }
}
