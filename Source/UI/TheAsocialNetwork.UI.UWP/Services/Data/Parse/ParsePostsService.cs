﻿namespace TheAsocialNetwork.UI.UWP.Services.Data.Parse
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using global::Parse;
    using TheAsocialNetwork.UI.UWP.Models;
    using TheAsocialNetwork.UI.UWP.Models.Parse;
    using TheAsocialNetwork.UI.UWP.Services.Apis;
    using TheAsocialNetwork.UI.UWP.Services.Contracts;

    public class ParsePostsService : IParsePostsService
    {
        private NotificationService notifier;

        public ParsePostsService()
        {
            this.notifier = new NotificationService();
        }

        public async Task<string> AddNewPostAsync(PostParse newPost)
        {
            try
            {
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

        public async Task<bool> AddNewRangeOfPostAsync(IEnumerable<PostParse> newPosts)
        {
            try
            {
                var currentUser = (UserParse)ParseUser.CurrentUser;
                currentUser.AddRangeToList("Posts", newPosts);
                await currentUser.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return false;
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

        public async Task<IEnumerable<PostParse>> GetCurrentUserAllPostsAsync()
        {
            try
            {
                var currenUser = ParseUser.CurrentUser;

                await currenUser.SaveAsync();

                var query = currenUser.Get<List<object>>("Posts");

                var usersPosts = new List<PostParse>();

                foreach (var post in query.Select(obj => ((PostParse)obj)))
                {
                    await post.FetchIfNeededAsync();

                    var images = post.Get<List<object>>("Images");

                    if (post.Images == null)
                    {
                        post.Images = new List<ImageParse>();
                    }

                    foreach (var im in images.Select(img => ((ImageParse)img)))
                    {
                        await im.FetchIfNeededAsync();
                        post.Images.Add(im);
                    }

                    var location = post.Get<ParseObject>("Location");
                    await location.FetchIfNeededAsync();

                    usersPosts.Add(post);
                }

                return usersPosts;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

               // this.notifier.ShowErrorToastWithDismissButton(msg);

                return null;
            }
        }

        public async Task<bool> DeleteImageByPostAndInageId(string imageId, string postId)
        {
            try
            {
                var q = new ParseQuery<ImageParse>();
                var post = await q.GetAsync(postId);

                await post.DeleteAsync();

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
