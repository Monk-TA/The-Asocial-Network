namespace TheAsocialNetwork.UI.UWP.Services.Data.SqLite
{
    using System;
    using System.Threading.Tasks;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;

    public class SqLitePostsService : SqlConnectionService
    {
        public async Task<int> AddNewPostAsync(PostSql newPost)
        {
            try
            {
                var connection = this.GetDbConnectionAsync();
                var result = await connection.InsertAsync(newPost);

                return result;

            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return -1;
            }
        } 
    }
}
