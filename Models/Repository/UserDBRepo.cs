using ITI_Project.Enitties;

namespace ITI_Project.Models.Repository
{
    public class UserDBRepo
    {
        Context db = new Context();

        
        public void add(Person temp)
        {
            
            db.Persons.Add(temp);
            db.SaveChanges();
        }
        public Person find(int id)
        {
            var user = db.Persons.SingleOrDefault(x => x.Id == id);
            return user;
        }

        public List<Person> list()
        {
            var list = new List<Person>();
            foreach (var item in db.Persons.ToList())
            {
                if(item.role == "user")
                {
                    var u = new Person();
                    u.Name = item.Name;
                    u.role = item.role;
                    u.Id = item.Id;
                    u.CartID = item.CartID;
                    u.Password = item.Password;
                    list.Add(u);
                }
            }
            return list;
        }
    }
}
