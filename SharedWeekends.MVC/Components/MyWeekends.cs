using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedWeekends.MVC.Model;
using SharedWeekends.MVC.Model.Enities;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.MVC.Components
{
    public class MyWeekends: ViewComponent
    {
        private readonly IWeekendsDbContext db;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public MyWeekends(IWeekendsDbContext db, IMapper mapper, UserManager<User> userManager)
        {
            this.db = db;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await userManager.FindByNameAsync(User.Identity?.Name ?? string.Empty);
            var myWeekends = new List<WeekendViewModel>();
            if (user != null)
            {
                myWeekends = mapper.Map<List<WeekendViewModel>>(db.Weekends
                    .Include(w => w.Likes)
                    .Where(w => w.AuthorId == user.Id)
                    .OrderByDescending(w => w.CreationDate));
            }

            return View(myWeekends);
        }
    }
}
