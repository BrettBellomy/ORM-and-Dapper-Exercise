using Dapper;
using System.Data;

namespace ORM_Dapper
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProdcuts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public void CreateProduct(string name, double price, int categoryID, bool onSale, int stockLevel)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID, OnSale, StockLevel) VALUES (@name, @price, @categoryID, @onSale, @stockLevel);", new { name, price, categoryID, onSale, stockLevel });
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;", new { productID });
            _connection.Execute("DELETE FROM  sales WHERE ProductID = @productID;", new { productID });
            _connection.Execute("DELETE FROM products WHERE ProductID = @productID;", new { productID });
        }

        public void UpdateProduct(int productID, string newName)
        {
            _connection.Execute("UPDATE products SET Name = @newName WHERE ProductID = @productID;", new { productID, newName });
        }

        public Product GetProduct(int id)
        {
            return _connection.QuerySingle<Product>("SELECT * FROM Products WHERE ProductID = @id;", new {id});
        }

        public void UpdateProduct(Product product)
        {
            _connection.Execute("UPDATE products" +
                                " SET Name = @name, " +
                                "Price = @price, " +
                                "CategoryId = @categoryid, " +
                                "OnSale = @onsale, " +
                                "Stocklevel = @stocklevel " +
                                "WHERE ProductID = @id;",
                                new {
                                    id = product.ProductID,
                                    name = product.Name, 
                                    price = product.Price, 
                                    categoryid = product.CategoryID, 
                                    onsale = product.OnSale, 
                                    stocklevel = product.StockLevel
                                });
        }
    }
}