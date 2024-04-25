namespace ITI_Project.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string role { get; set; }

        public int? CartID { get; set; }

        public int? Profit { get; set; } = 0;

        public List<Product> Products { get; set; }
    }
}
