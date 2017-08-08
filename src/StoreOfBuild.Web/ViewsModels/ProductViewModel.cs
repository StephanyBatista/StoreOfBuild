using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreOfBuild.Web.ViewsModels
{
    public class ProductViewModel
    {
        public int Id {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "StockQuantity invalid")]
        public int StockQuantity {get;  set;}
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}