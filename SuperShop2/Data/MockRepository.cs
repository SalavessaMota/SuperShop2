//using SuperShop2.Data.Entities;

//namespace SuperShop2.Data;

//public class MockRepository : IRepository
//{
//    public void AddProduct(Product product)
//    {
//        throw new NotImplementedException();
//    }

//    public Product GetProduct(int id)
//    {
//        throw new NotImplementedException();
//    }

//    public IEnumerable<Product> GetProducts()
//    {
//        var products = new List<Product>();
//        products.Add(new Product { Id = 1, Name = "Test1", Price = 10 });
//        products.Add(new Product { Id = 2, Name = "Test2", Price = 20 });
//        products.Add(new Product { Id = 3, Name = "Test3", Price = 30 });
//        products.Add(new Product { Id = 4, Name = "Test4", Price = 40 });
//        products.Add(new Product { Id = 5, Name = "Test5", Price = 50 });

//        return products;
//    }

//    public bool ProductExists(int id)
//    {
//        throw new NotImplementedException();
//    }

//    public void RemoveProduct(Product product)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<bool> SaveAllAsync()
//    {
//        throw new NotImplementedException();
//    }

//    public void UpdateProduct(Product product)
//    {
//        throw new NotImplementedException();
//    }
//}
