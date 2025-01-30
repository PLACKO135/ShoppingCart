﻿
namespace ShoppingCartProject.Models
{
    public class ShoppingCart
    {
        private readonly List<Product> _products;

        public ShoppingCart()
        {
            _products = new List<Product>();
        }

        public int ProductCount => _products.Count;

        //TODO Készítse el a ShoppingCart osztályban azokat a metódusokat, amelyekkel sikeresen lefutnak a tesztesetek!

        public void AddProduct(string productName, double price)
        {
            if (_products.Any(prod => prod.Name == productName)) { return; }
            _products.Add(new Product(productName, price));
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public double GetTotalPrice()
        {
            return _products.Sum(p => p.Price);
        }

        public void RemoveProduct(string deleteProductName)
        {
            Product? foundedItem = _products.Find(prod => prod.Name == deleteProductName);
            if (foundedItem is null)
            {
                throw new InvalidOperationException($"{deleteProductName} product isn't in backet!");
            }
            else
            {
                _products.Remove(foundedItem);
            }
        }

    }
}
