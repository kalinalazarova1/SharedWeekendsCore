using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedWeekends.MVC.Model;
using SharedWeekends.MVC.Model.Enities;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.MVC.Controllers
{
    public class CreateWeekendController : BaseController
    {
        public CreateWeekendController(IWeekendsDbContext data, IMapper mapper, UserManager<User> manager)
            : base(data, mapper, manager)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(WeekendViewModel weekend)
        {
            if (ModelState.IsValid)
            {
                var userId = await GetUserId(User?.Identity?.Name);
                if(userId == null)
                {
                    return Unauthorized();
                }

                var newWeekend = new Weekend()
                {
                    AuthorId = userId,
                    Title = weekend.Title,
                    Content = weekend.Description,
                    CategoryId = int.Parse(weekend.Category),
                    PictureUrl = weekend.PictureUrl,
                    Lattitude = weekend.Lattitude,
                    Longitude = weekend.Longitude,
                    CreationDate = DateTime.Now
                };

                Db.Weekends.Add(newWeekend);
                Db.SaveChanges();
                TempData["Message"] = "Weekend successfully created!";
                return RedirectToAction("Index");
            }

            TempData["Message"] = "Unable to create weekend!";
            return View(weekend);
        }
    }
}