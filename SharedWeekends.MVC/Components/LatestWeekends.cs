using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedWeekends.MVC.Model;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.MVC.Components
{
    public class LatestWeekends : ViewComponent
    {
        private readonly IWeekendsDbContext db;
        private readonly IMapper mapper;

        public LatestWeekends(IWeekendsDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var latest = mapper.Map<IList<WeekendViewModel>>(db.Weekends
                .Include(w => w.Likes)
                .OrderByDescending(w => w.CreationDate)
                .Take(4));
            return View(latest);
        }
    }
}
