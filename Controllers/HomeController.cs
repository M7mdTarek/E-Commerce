using ITI_Project.Enitties;
using ITI_Project.Models;
using ITI_Project.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace ITI_Project.Controllers
{
	public class HomeController : Controller
	{
        Context db = new Context();
        public ProductsContainer container = new ProductsContainer();
        public UserRepo userRepo;
        public SellerRepo SellerRepo;
        //public UserDBRepo userRepo = new UserDBRepo();
        //public SellerDBRepo SellerRepo = new SellerDBRepo();
        public static int Currentid = -1;
        public HomeController()
        {
            SellerRepo = SellerRepo.GetInstance();
            userRepo = UserRepo.GetInstance();
        }

        public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
        public ActionResult Login(Person person)
        {
			var users = userRepo.list();
			var sellers = SellerRepo.list();
            //check if the person is user
            if(person.role == "user")
            {
                foreach (var item in users)
                {
                    //check if the login is correct 
                    if (item.Name == person.Name && item.Password == person.Password)
                    {
                        person.Id = item.Id;
                        Currentid = item.Id;
                        return RedirectToAction("UserIndex", person);
                    }
                }
                ViewBag.wronglog = "please check username or password and try again";
                return View();
            }
            //check if the person is seller
            else if (person.role == "seller")
            {
                foreach (var item in sellers)
                {
                    if (item.Name == person.Name && item.Password == person.Password)
                    {
                        person.Id = item.Id;
                        Currentid = item.Id;
                        return RedirectToAction("SellerIndex", person);
                    }
                }
                ViewBag.wronglog = "please check username or password and try again";
                return View();
            }
            //if the user didnot choose role
            else
            {
                ViewBag.wronglog = "please choose the role";
                return View();
            }
        }
        public IActionResult UserIndex(Person person)
        {
            
            return View(container.Products);
        }
        public IActionResult SellerIndex(Person person)
        {
            var products = SellerRepo.find(person.Id).Products;
            ViewBag.sellerid = person.Id;
            return View(products);
        }
    }
}