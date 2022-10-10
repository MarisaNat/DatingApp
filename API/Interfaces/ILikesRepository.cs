using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUserId, int likedUserId);
        Task<AppUser> GetUserWithLikes(int userId);
        //predicate: geliked oder hat selbst geliked
        Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams);
    }
}
