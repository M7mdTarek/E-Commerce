using ITI_Project.Enitties;
using ITI_Project.Models;
using ITI_Project.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace ITI_Project.Controllers
{
    public class UserController : Controller
    {
        Context db = new Context();
        public UserRepo UserRepo;
        public ProductRepo ProductRepo;
        public CartRepo CartRepo;
        //public ProductDBRepo ProductRepo = new ProductDBRepo();
        //public UserDBRepo UserRepo = new UserDBRepo();
        //public CartDBRepo CartRepo = new CartDBRepo();
        public UserController() 
        {
            UserRepo = UserRepo.GetInstance();
            ProductRepo = ProductRepo.GetInstance();
            CartRepo = CartRepo.GetInstance();
        }
        // GET: UserController
        public ActionResult Index()
        {
            Person p = UserRepo.find(HomeController.Currentid);
            return RedirectToAction("UserIndex", "Home", p);
        }

        public ActionResult Search(string term)
        {
            if(term == null)
            {
                return View();
            }
            else
            {
                var products = ProductRepo.search(term);
                return View(products);
            }
            
        }

        public ActionResult AddToCart(int productid)
        {
            var user = UserRepo.find(HomeController.Currentid);
            var product = ProductRepo.find(productid);
            if(ProductRepo.find(productid).Quantity > 0)
            {
                ProductRepo.find(productid).Quantity--;
                CartRepo.find(user.CartID).Products.Add(product);
                //user.Cart.Products.Add(product);

                CartRepo.find(user.CartID).Total += product.Price;
                //user.Cart.Total += product.Price;
            }

            return RedirectToAction("Index");
        }

        public ActionResult ViewCart()
        {
            var user = UserRepo.find(HomeController.Currentid);
            var cart = CartRepo.find(user.CartID);
            return View(cart);
        }

        public ActionResult DeleteFromCart(int productid)
        {
            var user = UserRepo.find(HomeController.Currentid);
            var product = ProductRepo.find(productid);

            product.Quantity++;

            //user.Cart.Total -= product.Price;
            CartRepo.find(user.CartID).Total -= product.Price;

            //user.Cart.Products.Remove(product);
            CartRepo.find(user.CartID).Products.Remove(product);

            return RedirectToAction("ViewCart");
        }

        public ActionResult Checkout()
        {
            var user = UserRepo.find(HomeController.Currentid);

            //user.Cart.Products.Clear();
            CartRepo.find(user.CartID).Products.Clear();

            //user.Cart.Total = 0;
            CartRepo.find(user.CartID).Total = 0;

            //return RedirectToAction("ViewCart");
            return View();
        }
    }
}
