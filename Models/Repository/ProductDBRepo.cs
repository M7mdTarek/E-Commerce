using ITI_Project.Enitties;

namespace ITI_Project.Models.Repository
{
    public class ProductDBRepo
    {
        Context db = new Context();

        public void add(Product temp)
        {
            db.Products.Add(temp);
            db.SaveChanges();
        }
        public Product find(int id)
        {
            var p = db.Products.SingleOrDefault(x => x.Id == id);
            return p;
        }

        public void delete(int id)
        {
            var p = find(id);
            db.Products.Remove(p);
            db.SaveChanges();
        }

        public Product findbyseller(int id, int sellerid)
        {
            var p = db.Products.SingleOrDefault(x => x.Id == id && x.PersonId == sellerid);
            return p;
        }

        public List<Product> list() => db.Products.ToList();

        public List<Product> listbyseller(int sellerid)
        {
            var products = db.Products.Where(x => x.PersonId == sellerid).ToList();
            return products;
        }

        public List<Product> search(string term)
        {
            var results = db.Products.Where(a => a.Name.Contains(term)).ToList();
            return results;
        }

        public void update(Product temp)
        {
            db.Products.Update(temp);
            db.SaveChanges();

        }
    }
}
