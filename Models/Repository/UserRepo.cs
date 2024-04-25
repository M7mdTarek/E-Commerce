namespace ITI_Project.Models.Repository
{
    public class UserRepo
    {
        public List<Person> Users { get; set; }


        private UserRepo()
        {
            Users = new List<Person>()
            {
                new Person {
                    Id = 1,
                    Name = "mohamed tarek",
                    Password = "123456",
                    role = "user",
                    CartID = 1 
                    
                },
                new Person {
                    Id = 2,
                    Name = "mahmoud adel",
                    Password = "123456",
                    role = "user",
                    CartID = 2
                }
            };
        }

        private static readonly UserRepo _instance = new UserRepo();
        public static UserRepo GetInstance()
        {
            return _instance;
        }
        public void add(Person temp)
        {
            if (Users.Count == 0) temp.Id = 1;
            else temp.Id = Users.Max(a => a.Id) + 1;
            Users.Add(temp);
        }

        

        public Person find(int id)
        {
            var user = Users.SingleOrDefault(x => x.Id == id);
            return user;
        }

        public List<Person> list() => Users.ToList();

        

      
    }
}
