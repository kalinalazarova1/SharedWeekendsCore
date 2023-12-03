using Microsoft.AspNetCore.Mvc;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.MVC.Components
{
    public class CreateLikeForm: ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            TempData["Id"] = id;
            var model = new LikeViewModel
            {
                Voter = User?.Identity?.Name ?? string.Empty
            };

            return View(model);
        }
    }
}
