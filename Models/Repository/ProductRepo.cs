namespace ITI_Project.Models.Repository
{
    public class ProductRepo
    {
        public List<Product> Products { get; set; }
        
        private ProductRepo()
        {
            
            Products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "product1",
                    Price = 9299,
                    Quantity = 5,
                    ImageUrl = "p1.jpg",
                    PersonId = 1,
                },
                new Product()
                {
                    Id = 2,
                    Name = "product2",
                    Price = 45000,
                    Quantity = 2,
                    ImageUrl = "p2.jpg",
                    PersonId = 1,
                },
                new Product()
                {
                    Id = 3,
                    Name = "product3",
                    Price = 600,
                    Quantity = 5,
                    ImageUrl = "p3.jpg",
                    PersonId = 1,
                },
                new Product()
                {
                    Id = 4,
                    Name = "product4",
                    Price = 2000,
                    Quantity = 3,
                    ImageUrl = "p4.jpg",
                    PersonId = 2,
                },
                new Product()
                {
                    Id = 5,
                    Name = "product5",
                    Price = 7000,
                    Quantity = 5,
                    ImageUrl = "p5.jpg",
                    PersonId = 2,
                },
                new Product()
                {
                    Id = 6,
                    Name = "product6",
                    Price = 500,
                    Quantity = 1,
                    ImageUrl = "p6.jpg",
                    PersonId = 2,
                }
            };
        }

        private static readonly ProductRepo _instance = new ProductRepo();
        public static ProductRepo GetInstance()
        {
            return _instance;
        }
        
        public void add(Product temp)
        {
            if (Products.Count == 0) temp.Id = 1;
            else temp.Id = Products.Max(a => a.Id) + 1;
            //add the product to the container list
            Products.Add(temp);
            //add the product to the seller list
            //SellerRepo.find(temp.SellerId).Products.Add(temp);
        }

        public void delete(int id)
        {
            var p = find(id);
            Products.Remove(p);
        }

        public Product find(int id)
        {
            var p = Products.SingleOrDefault(x => x.Id == id);
            return p;
        }

        public Product findbyseller(int id, int sellerid)
        {
            var p = Products.SingleOrDefault(x => x.Id == id && x.PersonId == sellerid);
            return p;
        }
        public List<Product> list() => Products.ToList();

        public List<Product> listbyseller(int sellerid)
        {
            var products = Products.FindAll(x => x.PersonId == sellerid);
            return products;
        }
        public List<Product> search(string term)
        {
            var results = Products.Where(a => a.Name.Contains(term)).ToList();
            return results;
        }

        public void update(Product temp)
        {
            var p = find(temp.Id);
            p.Name = temp.Name;
            p.Price = temp.Price;
            p.Quantity = temp.Quantity;
            p.ImageUrl = temp.ImageUrl;
            
        }
    }
}
