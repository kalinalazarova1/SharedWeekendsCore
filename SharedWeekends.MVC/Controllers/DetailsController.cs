using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedWeekends.MVC.Model;
using SharedWeekends.MVC.Model.Enities;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.MVC.Controllers
{
    public class DetailsController : BaseController
    {
        public DetailsController(IWeekendsDbContext data, IMapper mapper, UserManager<User> manager)
            : base(data, mapper, manager)
        {
        }

        [HttpGet]
        public async Task<ActionResult> Index(int? id)
        {
            var selected = Mapper.Map<WeekendViewModel>(
                Db.Weekends
                .Include(w => w.Author)
                .Include(w => w.Category)
                .Include(w => w.Likes)
                .Where(w => w.Id == id)
                .Single());

            var userId = await GetUserId(User?.Identity?.Name);
            if (User?.Identity != null &&
                Db.Likes.Any(l => l.WeekendId == id && l.VoterId == userId || selected.Author == User.Identity.Name))
            {
                ViewBag.HasLikedThis = true;
            }
            else
            {
                ViewBag.HasLikedThis = false;
            }
           
            return View(selected);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateLike(LikeViewModel like)
        {
            like.Voter = User?.Identity?.Name ?? string.Empty;
            if (ModelState.IsValid && User?.Identity?.Name != null)
            {
                like.CreationDate = DateTime.Now;
                var userId = await GetUserId(User?.Identity?.Name);
                if(userId == null)
                {
                    return Unauthorized();
                }

                var newLike = new Like()
                {
                    Comment = like.Comment,
                    VoterId = userId,
                    Stars = like.Stars,
                    WeekendId = like.WeekendId
                };

                Db.Likes.Add(newLike);
                Db.SaveChanges();
                var author = Db.Weekends.Single(w => w.Id == newLike.WeekendId).Author;
                if (author != null)
                {
                    author.Rating += newLike.Stars;
                }
                
                Db.SaveChanges();
            }

            return PartialView("_SingleLike", like);
        }
    }
}