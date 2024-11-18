namespace Assignment14
{
    class Program
    {
        public static void Main(string[] args)
        {
            var inventory = new Inventory();

            var product1 = new Product(1, 100, false);
            var product2 = new Product(2, 200, false);
            var product3 = new Product(3, 150, false);

            inventory.AddProduct(product1, 10);
            inventory.AddProduct(product2, 5);
            inventory.AddProduct(product3, 8);

            Console.WriteLine("Initial Inventory Value: " + inventory.TotalValue);

            product1.Price = 120;
            Console.WriteLine("Updated Inventory Value (after price change): " + inventory.TotalValue);

            product2.IsDefective = true;
            Console.WriteLine("Updated Inventory Value (after removing defective): " + inventory.TotalValue);

            inventory.UpdateProductQuantity(product3, 12);
            Console.WriteLine("Updated Inventory Value (after quantity update): " + inventory.TotalValue);

            inventory.RemoveProduct(product1);
            Console.WriteLine("Final Inventory Value (after removing a product): " + inventory.TotalValue);
        }
    }

    public class Product : IEquatable<Product>
    {
        public event EventHandler PriceChanged;
        public event EventHandler BecameDefective;

        private decimal price;
        private bool isDefective;

        public int Id { get; }

        public decimal Price
        {
            get => price;
            set
            {
                if (price != value)
                {
                    price = value;
                    PriceChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public bool IsDefective
        {
            get => isDefective;
            set
            {
                if (isDefective != value)
                {
                    isDefective = value;
                    if (isDefective)
                    {
                        BecameDefective?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        public Product(int id, decimal price, bool isDefective)
        {
            Id = id;
            Price = price;
            IsDefective = isDefective;
        }

        public bool Equals(Product other)
        {
            return other != null && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Product);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public class Inventory
    {
        private readonly Dictionary<Product, int> products = new Dictionary<Product, int>();

        public decimal TotalValue { get; private set; }

        public void AddProduct(Product product, int quantity)
        {
            if (!products.ContainsKey(product))
            {
                products[product] = 0;
                product.PriceChanged += OnProductPriceChanged;
                product.BecameDefective += OnProductBecameDefective;
            }

            products[product] += quantity;
            UpdateTotalValue();
        }

        public void RemoveProduct(Product product)
        {
            if (products.ContainsKey(product))
            {
                products.Remove(product);
                product.PriceChanged -= OnProductPriceChanged;
                product.BecameDefective -= OnProductBecameDefective;
                UpdateTotalValue();
            }
        }

        public void UpdateProductQuantity(Product product, int quantity)
        {
            if (products.ContainsKey(product))
            {
                products[product] = quantity;
                UpdateTotalValue();
            }
        }

        private void OnProductPriceChanged(object sender, EventArgs e)
        {
            UpdateTotalValue();
        }

        private void OnProductBecameDefective(object sender, EventArgs e)
        {
            RemoveProduct(sender as Product);
        }

        private void UpdateTotalValue()
        {
            TotalValue = 0;
            foreach (var item in products)
            {
                TotalValue += item.Key.Price * item.Value;
            }
        }
    }
}