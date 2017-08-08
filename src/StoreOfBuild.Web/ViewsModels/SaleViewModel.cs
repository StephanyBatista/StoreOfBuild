using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreOfBuild.Web.ViewsModels
{
    public class SaleViewModel
    {
        [Required]
        public string ClientName {get; set;}
        [Required]
        public int ProductId {get; set;}
        [Required]
        public int Quantity {get; set;}
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}