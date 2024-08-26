namespace ORM_Dapper
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProdcuts();
        public void CreateProduct(string name, double price, int categoryID, bool onSale, int stockLevel);
        public void UpdateProduct(int productID, string newName);
        public void DeleteProduct(int productID);
    }
}