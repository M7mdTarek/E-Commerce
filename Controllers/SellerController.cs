using ITI_Project.Models;
using ITI_Project.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using ITI_Project.Enitties;

namespace ITI_Project.Controllers
{
    public class SellerController : Controller
    {
        Context db = new Context();
        public SellerRepo SellerRepo;
        public ProductRepo ProductRepo;
        //public ProductDBRepo ProductRepo = new ProductDBRepo();
        //public SellerDBRepo SellerRepo = new SellerDBRepo();
        IHostingEnvironment hosting;

        public SellerController( IHostingEnvironment hosting)
        {
            this.SellerRepo = SellerRepo.GetInstance();
            this.ProductRepo = ProductRepo.GetInstance();
            this.hosting = hosting;
        }

        public ActionResult Index(int id)
        {
            id = HomeController.Currentid;
            Person p = SellerRepo.find(id);
            return RedirectToAction("SellerIndex", "Home", p);
        }
        // GET: SellerController/Details/5
        public ActionResult Details(int id)
        {
            var seller = SellerRepo.find(id);
            return View(seller);
        }

        // GET: SellerController/Edit/5
        public ActionResult EditSeller(int id)
        {
            var seller = SellerRepo.find(id);
            return View(seller);
        }

        // POST: SellerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSeller(Person seller)
        {
            try
            {
                SellerRepo.update(seller);
                return RedirectToAction("Details", new { seller.Id });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditProduct(int id)
        {
            var product = ProductRepo.findbyseller(id, HomeController.Currentid);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(Product product)
        {
            try
            {

                if (product.file != null)
                {
                    //to make evry file name unique
                    string name = product.file.FileName + DateTime.Now.ToString("yyyyMMdd_HHmmss") + Path.GetExtension(product.file.FileName);

                    string newpath = preppath(name);
                    //imgUrl is old one
                    string oldpath = preppath(product.ImageUrl);
                    //delete the old file
                    //System.IO.File.Delete(oldpath);

                    //save new file then release the resources
                    FileStream f;
                    product.file.CopyTo(f = new FileStream(newpath, FileMode.Create));
                    f.Dispose();

                    //now imgUrl is new one
                    product.ImageUrl = name;

                }
                ProductRepo.update(product);
                return RedirectToAction("Index", HomeController.Currentid);
            }
            catch
            {
                return View();
            }
        }


        // GET: SellerController/Create
        public ActionResult CreateProduct()
        {
            ViewBag.sellerid = HomeController.Currentid;
            return View();
        }

        // POST: SellerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(Product product)
        {
            try
            {
                if (product.file != null)
                {
                    //to make evry file name unique
                    string name = product.file.FileName + DateTime.Now.ToString("yyyyMMdd_HHmmss") + Path.GetExtension(product.file.FileName);

                    //save new file then release the resources
                    FileStream f;
                    product.file.CopyTo(f = new FileStream(preppath(name), FileMode.Create));
                    f.Dispose();

                    product.ImageUrl = name;
                }

                ProductRepo.add(product);
                SellerRepo.find(product.PersonId).Products.Add(product);
                return RedirectToAction("Index", HomeController.Currentid);
            }
            catch
            {
                return View();
            }
        }

        // GET: SellerController/Delete/5
        public ActionResult DeleteProduct(int id)
        {
            var product = ProductRepo.findbyseller(id, HomeController.Currentid);
            return View(product);
        }

        // POST: SellerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(Product product)
        {
            try
            {
                var p = ProductRepo.find(product.Id);
                string path = ProductRepo.find(product.Id).ImageUrl;
                path = preppath(path);
                ProductRepo.delete(product.Id);
                SellerRepo.find(HomeController.Currentid).Products.Remove(p);

                //delete file only when delete the developer successfully 
                System.IO.File.Delete(path);


                return RedirectToAction("Index", HomeController.Currentid);
            }
            catch
            {
                return View();
            }
        }
        //handle the path
        string preppath(string name)
        {
            //handle the root path
            string uploads = Path.Combine(hosting.WebRootPath, "assets");

            string fullpath = Path.Combine(uploads, name);

            return fullpath;
        }
    }
}
