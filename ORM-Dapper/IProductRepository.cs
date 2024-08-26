namespace ORM_Dapper
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProdcuts();
        public void CreateProduct(string name, double price, int categoryID, bool onSale, int stockLevel);
        public Product GetProduct (int id);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int productID);
    }
}