namespace TheAsocialNetwork.UI.UWP.Services.Data.Parse
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
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
                await this.UploadFiles(newPost.Images);

                var currentUser = (UserParse)ParseUser.CurrentUser;
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

        public async Task<string> AddNewRangeOfPostAsync(IEnumerable<PostParse> newPosts)
        {
            try
            {
                var currentUser = (UserParse)ParseUser.CurrentUser;
                currentUser.AddRangeToList("Posts", newPosts);
                await currentUser.SaveAsync();

                return "success";
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return null;
            }
        }

        private async Task UploadFiles(IEnumerable<ImageParse> files)
        {
            if (files != null)
            {
                await Task.WhenAll(files.Select(f => f.ImageInfo.SaveAsync()));
            }

            //foreach (ParseFile file in files)
            //{
            //    await file.SaveAsync();
            //}
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

        public async Task<IEnumerable<PostParse>> GetAllPostsAsync(Category category)
        {
            try
            {
                var posts = ParseUser.CurrentUser.Get<IList<object>>("Posts");

                var fullPosts = new List<PostParse>();

                foreach (var obj in posts)
                {
                    var id = (obj as ParseObject).ObjectId;

                    var post = await new ParseQuery<PostParse>().Include("Images").GetAsync(id);

                    fullPosts.Add(post);
                }

                //var weapons = query;


                //  return null;


                // var posts = ParseUser.CurrentUser.Get<IList<Object>>("Posts");

                //var userQuery = ParseUser.Query;

                //userQuery = userQuery.Include("Posts");

                //IEnumerable<ParseUser> results = await userQuery.FindAsync();

                //var result = (await new ParseQuery<PostParse>()
                //            .FindAsync()).ToList();


                //var singleresult = (await new ParseQuery<PostParse>()
                //    .Include("Images")
                //  .GetAsync(result[2].ObjectId));

                //foreach (ImageParse  img in singleresult.Images)
                //{
                //    var imeg = img;
                //}


                return fullPosts;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return null;
            }
        }



    }
}
