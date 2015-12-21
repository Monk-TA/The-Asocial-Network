namespace TheAsocialNetwork.UI.UWP.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TheAsocialNetwork.UI.UWP.Models.Parse;

    public interface IParsePostsService
    {
        Task<string> AddNewPostAsync(PostParse newPost);
        Task<bool> AddNewRangeOfPostAsync(IEnumerable<PostParse> newPosts);
        Task<PostParse> UpdatePostAsync(PostParse postToUpdate);
        Task<PostParse> AddNewImageToPostAsync(PostParse postToUpdate);
        Task<IEnumerable<PostParse>> GetCurrentUserAllPostsAsync();
        Task<bool> DeleteImageByPostAndInageId(string imageId, string postId);
    }
}