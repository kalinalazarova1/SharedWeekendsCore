using AutoMapper;
using SharedWeekends.MVC.Model.Enities;
using SharedWeekends.MVC.ViewModels;

namespace SharedWeekends.ViewModels
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(m => m.Avatar, opt => opt.MapFrom(u => u.AvatarPhoto));
            CreateMap<UserViewModel, User>()
                .ForMember(m => m.AvatarPhoto, opt => opt.MapFrom(u => u.Avatar));

            CreateMap<Weekend, WeekendViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(w => w.Author.UserName ?? w.Author.Email))
                .ForMember(m => m.Rating, opt => opt.MapFrom(w => w.Likes.Count() > 0 ? w.Likes.Sum(l => l.Stars) / w.Likes.Count() : 0))
                .ForMember(m => m.LikesCount, opt => opt.MapFrom(w => w.Likes.Count()))
                .ForMember(m => m.Description, opt => opt.MapFrom(w => w.Content))
                .ForMember(m => m.Category, opt => opt.MapFrom(w => w.Category.Name));
            CreateMap<WeekendViewModel, Weekend>()
                .ForMember(m => m.Content, opt => opt.MapFrom(w => w.Description));

            CreateMap<Like, LikeViewModel>()
                .ForMember(m => m.Voter, opt => opt.MapFrom(l => l.Voter.UserName))
                .ForMember(m => m.WeekendTitle, opt => opt.MapFrom(l => l.Weekend.Title));
            CreateMap<LikeViewModel, Like>();

            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();
        }
    }
}
