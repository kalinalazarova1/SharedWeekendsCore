using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SharedWeekends.MVC.Model;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.MVC.Components
{
    public class TopUsers: ViewComponent
    {
        private readonly IWeekendsDbContext db;
        private readonly IMapper mapper;

        public TopUsers(IWeekendsDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var users = mapper.Map<IList<UserViewModel>>(db.Users
                                        .OrderByDescending(u => u.Rating)
                                        .Take(3));

            return View(users);
        }
    }
}
