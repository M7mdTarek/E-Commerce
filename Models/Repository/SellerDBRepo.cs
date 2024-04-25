using ITI_Project.Enitties;

namespace ITI_Project.Models.Repository
{
    public class SellerDBRepo
    {
        Context db = new Context();

        public void add(Person temp)
        {

            db.Persons.Add(temp);
            db.SaveChanges();
        }

        public Person find(int? id)
        {
            var seller = db.Persons.SingleOrDefault(x => x.Id == id);
            return seller;
        }

        public List<Person> list()
        {
            List<Person> list = new List<Person> ();
            Person s = new Person();
            foreach (var item in db.Persons.ToList())
            {
                if(item.role == "seller")
                {
                    list.Add(item);
                }
                    
            }
            return list;
        }
        public void update(Person temp)
        {
            db.Persons.Update(temp);
            db.SaveChanges();
        }
    }
}
