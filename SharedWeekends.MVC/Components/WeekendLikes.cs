using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SharedWeekends.MVC.Model;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.MVC.Components
{
    public class WeekendLikes: ViewComponent
    {
        private readonly IWeekendsDbContext db;
        private readonly IMapper mapper;

        public WeekendLikes(IWeekendsDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public IViewComponentResult Invoke(int id)
        {
            var likes = mapper.Map<IList<LikeViewModel>>(db.Likes.Where(l => l.WeekendId == id));
            return View(likes);
        }
    }
}
