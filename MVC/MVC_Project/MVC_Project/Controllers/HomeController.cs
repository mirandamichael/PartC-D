using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspTest.Models;
using System.Data.Entity;
using MVC_Project;

namespace aspTest.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Insert(String name)
        {
            using (var db = new BlogContext())
            {
                Blog blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
            return View("Index", GetViewModel());
        }

        public ActionResult Index()
        {
            return View(GetViewModel());
        }
        private HomeViewModel GetViewModel()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            using (var db = new BlogContext())
            {
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                foreach (Blog blogInDb in query)
                {
                    homeViewModel.blogs.Add(blogInDb.Name);
                }
            }
            return homeViewModel;
        }
    }
}