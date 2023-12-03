using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedWeekends.MVC.Model;
using SharedWeekends.MVC.Model.Enities;

namespace SharedWeekends.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController(IWeekendsDbContext db, IMapper mapper, UserManager<User> manager)
        {
            Db = db;
            Mapper = mapper;
            UserManager = manager;
        }

        protected IWeekendsDbContext Db { get; set; }

        protected IMapper Mapper { get; set; }

        protected UserManager<User> UserManager { get; set; }

        protected async Task<string?> GetUserId(string? username)
        {
            if(username == null)
            {
                return null;
            }

            var user = await UserManager.FindByNameAsync(username);
            if (user != null)
            {
                return user.Id;
            }

            return null;
        }
    }
}