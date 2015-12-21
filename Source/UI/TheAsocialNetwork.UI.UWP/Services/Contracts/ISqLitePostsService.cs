namespace TheAsocialNetwork.UI.UWP.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SQLite.Net.Async;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;

    public interface ISqLitePostsService
    {
        Task<int> AddNewPostAsync(PostSql newPost);
        Task<int> AddUserWithDatasync(UserSql newUser);
        Task<IEnumerable<PostSql>>  GetAllPostsAsync();
        Task<bool> DeleteAllPostsAsync();
        SQLiteAsyncConnection GetDbConnectionAsync();
    }
}