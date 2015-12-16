namespace TheAsocialNetwork.UI.UWP.Services.Data.Parse
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using global::Parse;
    using TheAsocialNetwork.UI.UWP.Models;
    using TheAsocialNetwork.UI.UWP.Models.Parse;

    public class ParsePostsService
    {
        public async Task<string> AddNewPostAsync(PostParse newPost)
        {
            try
            {
                var newAvata = new AvatarParse()
                {
                    ImageInfo = new ImageInfoParse()
                    {
                        OriginalName = "avatar",
                        FileExstension = "huc",
                        ByteArrayContent = new byte[1000]
                    }
                };

                //await newPost.SaveAsync();
                var currentUser = (UserParse)ParseUser.CurrentUser;
                currentUser.AddToList("Posts", newPost);
                currentUser.Avatar = newAvata;
                await currentUser.SaveAsync();

                return newPost.ObjectId;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return null;
            }
        }

        public async Task<PostParse> UpdatePostAsync(PostParse postToUpdate)
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

        public async Task<PostParse> AddNewImageToPostAsync(PostParse postToUpdate)
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

        public async Task<IEnumerable<PostParse>> GetPostsByCategotyAsync(Category category)
        {
            try
            {
                var result = await new ParseQuery<PostParse>()
                    .Where(p => p.Category == "Bitch")
                    .FindAsync();

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
