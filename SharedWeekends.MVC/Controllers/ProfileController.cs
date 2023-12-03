using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedWeekends.MVC.Model;
using SharedWeekends.MVC.Model.Enities;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.MVC.Controllers
{
    public class ProfileController : BaseController
    {
        public ProfileController(IWeekendsDbContext data, IMapper mapper, UserManager<User> manager)
            : base(data, mapper, manager)
        {
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var username = User?.Identity?.Name;
            if(username == null)
            {
                return Unauthorized();
            }

            var user = await UserManager.FindByNameAsync(username);
            return View(Mapper.Map<UserViewModel>(user));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var weekend = Mapper.Map<WeekendViewModel>(Db.Weekends.Single(w => w.Id == id));
            return View("MyWeekendEdit", weekend);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WeekendViewModel weekend)
        {
            if (ModelState.IsValid)
            {
                var editedWeekend = Db.Weekends.Single(w => w.Id == weekend.Id);
                editedWeekend.Title = weekend.Title;
                editedWeekend.Content = weekend.Description;
                editedWeekend.CategoryId = int.Parse(weekend.Category);
                editedWeekend.PictureUrl = weekend.PictureUrl;
                editedWeekend.Lattitude = weekend.Lattitude;
                editedWeekend.Longitude = weekend.Longitude;

                Db.SaveChanges();
                TempData["Message"] = "Weekend successfully edited!";
                return RedirectToAction("Index");
            }

            TempData["Message"] = "Unable to edit weekend!";
            return View(weekend);
        }

        [HttpGet]
        public ActionResult EditReview(int id)
        {
            var review = Mapper.Map<LikeViewModel>(Db.Likes.Single(l => l.Id == id));
            return View("MyReviewEdit", review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReview(LikeViewModel like)
        {
            if (ModelState.IsValid)
            {
                var editedLike = Db.Likes.Single(l => l.Id == like.Id);
                editedLike.Stars = like.Stars;
                editedLike.Comment = like.Comment;
                
                Db.SaveChanges();
                TempData["Message"] = "Review successfully edited!";
                return RedirectToAction("Index");
            }

            TempData["Message"] = "Unable to edit review!";
            return View(like);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeAvatar(AvatarViewModel model)
        {
            if (model.AvatarFile != null)
            {
                var user = Db.Users.Single(u => u.UserName == User.Identity.Name);
                user.AvatarPhoto = GetImage(model.AvatarFile);
                Db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        private byte[] GetImage(IFormFile uploadedImage)
        {
            if (uploadedImage != null)
            {
                using (var memory = new MemoryStream())
                {
                    uploadedImage.CopyTo(memory);
                    var content = memory.GetBuffer();

                    if (uploadedImage.FileName.Split(new[] { '.' }).Last() == "jpg" || uploadedImage.FileName.Split(new[] { '.' }).Last() == "jpeg")
                    {
                        return content;
                    }
                    else
                    {
                        throw new Exception("Invalid file format");
                    }
                }
            }
            else
            {
                throw new Exception("Missing file");
            }
        }
    }
}