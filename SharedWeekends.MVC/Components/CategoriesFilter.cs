using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SharedWeekends.MVC.Model;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.MVC.Components
{
    public class CategoriesFilter: ViewComponent
    {
        private readonly IWeekendsDbContext db;
        private readonly IMapper mapper;

        public CategoriesFilter(IWeekendsDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var categories = mapper.Map<List<CategoryViewModel>>(db.Categories);
            return View(categories);
        }
    }
}
