namespace ITI_Project.Models.Repository
{
    public class ProductsContainer
    {
        public ProductRepo ProductRepo = ProductRepo.GetInstance();
        //public ProductDBRepo ProductRepo = new ProductDBRepo();
        public List<Product> Products { get; set; }
        public ProductsContainer()
        {
            Products = ProductRepo.list();
        }
    }
}
