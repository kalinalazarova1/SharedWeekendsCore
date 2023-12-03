using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedWeekends.MVC.Model;
using SharedWeekends.MVC.Model.Enities;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.MVC.Controllers
{
    public class SearchController : BaseController
    {
        private static readonly int PageSize = 3;

        public SearchController(IWeekendsDbContext data, IMapper mapper, UserManager<User> manager)
            : base(data, mapper, manager)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            TempData["CategoryId"] = 0;
            TempData["Page"] = 0;
            
            return View();
        }

        public ActionResult FilterByCategory(int? id, int page)
        {
            var currentPage = (int)TempData["Page"] + page < 0 ? 0 : (int)TempData["Page"] + page;
            if (page == 0)
            {
                currentPage = 0;
            }

            IEnumerable<WeekendViewModel> all;
            if (id == 0)
            {
                all = Mapper.Map<IList<WeekendViewModel>>(Db.Weekends
                    .Include(w => w.Likes)
                    .OrderByDescending(w => w.CreationDate)
                    .Skip(PageSize * currentPage)
                    .Take(PageSize));

                TempData["CategoryId"] = id;
            }
            else if (id == null && (int)TempData["CategoryId"] != 0)
            {
                var categoryId = (int)TempData["CategoryId"];
                all = Mapper.Map<IList<WeekendViewModel>>(Db.Weekends
                    .Include(w => w.Likes)
                    .Where(w => w.CategoryId == categoryId)
                    .OrderByDescending(w => w.CreationDate)
                    .Skip(PageSize * currentPage)
                    .Take(PageSize));

                TempData["CategoryId"] = categoryId;
            }
            else if (id == null && (int)TempData["CategoryId"] == 0)
            {
                var categoryId = (int)TempData["CategoryId"];
                all = Mapper.Map<IList<WeekendViewModel>>(Db.Weekends
                    .Include(w => w.Likes)
                    .OrderByDescending(w => w.CreationDate)
                    .Skip(PageSize * currentPage)
                    .Take(PageSize));

                TempData["CategoryId"] = categoryId;
            }
            else
            {
                all = Mapper.Map<IList<WeekendViewModel>>(Db.Weekends
                    .Include(w => w.Likes)
                    .Where(w => w.CategoryId == id)
                    .OrderByDescending(w => w.CreationDate)
                    .Take(PageSize));

                TempData["CategoryId"] = id;
            }

            TempData["Page"] = currentPage;
            return PartialView("_Weekends", all);
        }
    }
}