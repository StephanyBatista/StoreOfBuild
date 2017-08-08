namespace StoreOfBuild.Domain.Products
{
    public class ProductStorer
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ProductStorer(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public void Store(int id, string name, int categoryId, decimal price, int StockQuantity)
        {
            var category = _categoryRepository.GetById(categoryId);
            DomainException.When(category == null, "Category invalid");

            var product = _productRepository.GetById(id);
            if(product == null)
            {
                product = new Product(name, category, price, StockQuantity);
                _productRepository.Save(product);
            }
            else
                product.Update(name, category, price, StockQuantity);
        }
    }
}