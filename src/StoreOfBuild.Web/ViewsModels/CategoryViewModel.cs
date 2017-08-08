using System.ComponentModel.DataAnnotations;

namespace StoreOfBuild.Web.ViewsModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}