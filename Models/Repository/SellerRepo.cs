using NuGet.Protocol.Core.Types;

namespace ITI_Project.Models.Repository
{
    public class SellerRepo 
    {
        public List<Person> Sellers;
        public ProductRepo ProductRepo = ProductRepo.GetInstance();
        //public ProductDBRepo ProductRepo = new ProductDBRepo();
        private SellerRepo()
        {
            
            Sellers = new List<Person>()
            {
                new Person()
                {
                    Id = 1,
                    Name = "tarek mohamed",
                    Password = "123456",
                    role = "seller",
                    Profit = 0,
                    Products = ProductRepo.listbyseller(1)
                },
                new Person()
                {
                    Id = 2,
                    Name = "adel mahmoud",
                    Password = "123456",
                    role = "seller",
                    Profit = 0,
                    Products = ProductRepo.listbyseller(2)
                }
            };
        }
        private static readonly SellerRepo _instance = new SellerRepo();
        public static SellerRepo GetInstance()
        {
            return _instance;
        }
        public void add(Person temp)
        {
            if (Sellers.Count == 0) temp.Id = 1;
            else temp.Id = Sellers.Max(a => a.Id) + 1;
            Sellers.Add(temp);
        }



        public Person find(int? id)
        {
            var seller = Sellers.SingleOrDefault(x => x.Id == id);
            return seller;
        }

        public List<Person> list() => Sellers.ToList();

        public void update(Person temp)
        {
            Person seller = find(temp.Id);
            seller.Name = temp.Name;
            seller.Password = temp.Password;
        }
    }
}
