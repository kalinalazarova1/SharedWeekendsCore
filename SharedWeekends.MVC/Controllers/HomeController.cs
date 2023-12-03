using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedWeekends.MVC.Model;
using SharedWeekends.MVC.Model.Enities;

namespace SharedWeekends.MVC.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IWeekendsDbContext data, IMapper mapper, UserManager<User> manager)
            : base(data, mapper, manager)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}