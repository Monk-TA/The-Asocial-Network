﻿namespace TheAsocialNetwork.UI.UWP.Services.Data.SqLite
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SQLiteNetExtensionsAsync.Extensions;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;

    public class SqLitePostsService : SqlConnectionService
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
    }
}
