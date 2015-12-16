namespace TheAsocialNetwork.UI.UWP.Services.Data.Parse
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using global::Parse;
    using TheAsocialNetwork.UI.UWP.Models.Parse;

    public class ParsePostsService
    {
        public async Task<string> AddNewPostAsync(PostParse newPost)
        {
            try
            {
                //await newPost.SaveAsync();
                var currentUser = ParseUser.CurrentUser;
                currentUser.AddToList("Posts", newPost);
                await currentUser.SaveAsync();

                return newPost.ObjectId;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return null;
            }
        }

        public async Task<PostParse> UpdatePost(PostParse postToUpdate)
        {
            try
            {
                await postToUpdate.SaveAsync();

                return postToUpdate;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return null;
            }
        }

        public async Task<PostParse> AddNewImageToPost(PostParse postToUpdate)
        {
            try
            {
                await postToUpdate.SaveAsync();

                return postToUpdate;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return null;
            }
        }
    }
}
