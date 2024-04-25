namespace ITI_Project.Models.Repository
{
    public class CartRepo
    {
        public List<Cart> Carts { get; set; }
        private CartRepo() 
        {
            Carts = new List<Cart>()
            {
                new Cart
                {
                    Id = 1,
                    PersonId = 1,
                    Total = 0,
                    Products = new List<Product>()
                },
                new Cart
                {
                    Id = 2,
                    PersonId = 2,
                    Total = 0,
                    Products = new List<Product>()
                },
            };
        }
        private static readonly CartRepo _instance = new CartRepo();
        public static CartRepo GetInstance()
        {
            return _instance;
        }

        public Cart find(int? id)
        {
            var c = Carts.SingleOrDefault(x => x.Id == id);
            return c;
        }



    }
}
