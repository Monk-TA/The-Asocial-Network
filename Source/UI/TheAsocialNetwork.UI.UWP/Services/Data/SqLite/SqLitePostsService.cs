namespace TheAsocialNetwork.UI.UWP.Services.Data.SqLite
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SQLiteNetExtensionsAsync.Extensions;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;
    using TheAsocialNetwork.UI.UWP.Services.Contracts;

    public class SqLitePostsService : SqlConnectionService, ISqLitePostsService
    {
        public async Task<int> AddNewPostAsync(PostSql newPost)
        {
            try
            {
                var connection = this.GetDbConnectionAsync();

                await connection.InsertOrReplaceWithChildrenAsync(newPost, recursive: true);

                return newPost.Id;

            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return -1;
            }
        }

        public async Task<int> AddUserWithDatasync(UserSql newUser)
        {
            try
            {
                var connection = this.GetDbConnectionAsync();

                await connection.InsertOrReplaceWithChildrenAsync(newUser, recursive: true);

                return newUser.Id;

            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return -1;
            }
        }

        public async Task<IEnumerable<PostSql>>  GetAllPostsAsync()
        {
            try
            {
                var connection = this.GetDbConnectionAsync();
                var result = await connection.GetAllWithChildrenAsync<PostSql>(recursive: true);

                return result;

            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return null;
            }
        }

        public async Task<bool> DeleteAllPostsAsync()
        {
            try
            {
                var connection = this.GetDbConnectionAsync();
                var posts = await connection.DeleteAllAsync<PostSql>();
                var locations = await connection.DeleteAllAsync<LocationSql>();
                var images = await connection.DeleteAllAsync<ImageSql>();
                var imageInfos = await connection.DeleteAllAsync<ImageInfoSql>();
                var videos = await connection.DeleteAllAsync<VideoSql>();

                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return false;
            }
        }
    }
}
