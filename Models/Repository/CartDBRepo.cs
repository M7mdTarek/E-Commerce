using ITI_Project.Enitties;

namespace ITI_Project.Models.Repository
{
    public class CartDBRepo
    {
        Context db = new Context();

        public Cart find(int? id)
        {
            var c = db.Carts.SingleOrDefault(x => x.Id == id);
            
            return c;
        }
        
    }
}
