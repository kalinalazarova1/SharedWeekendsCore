using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedWeekends.MVC.Model.Enities;
using SharedWeekends.MVC.Model;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.MVC.Components
{
    public class MyReviews : ViewComponent
    {
        private readonly IWeekendsDbContext db;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public MyReviews(IWeekendsDbContext db, IMapper mapper, UserManager<User> userManager)
        {
            this.db = db;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await userManager.FindByNameAsync(User.Identity?.Name ?? string.Empty);
            var my = mapper.Map<IList<LikeViewModel>>(db.Likes
                .Where(l => l.VoterId == user.Id)
                .OrderByDescending(l => l.CreationDate));

            return View(my);
        }
    }
}
