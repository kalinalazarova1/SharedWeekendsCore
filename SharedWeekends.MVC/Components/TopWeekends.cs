using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedWeekends.MVC.Model;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.MVC.Components
{
    public class TopWeekends : ViewComponent
    {
        private readonly IWeekendsDbContext db;
        private readonly IMapper mapper;

        public TopWeekends(IWeekendsDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var top = mapper.Map<IList<WeekendViewModel>>(db.Weekends
               .Include(w => w.Likes)
               .OrderByDescending(w => w.Likes.Sum(l => l.Stars))
               .Take(4));
            return View(top);
        }
    }
}
