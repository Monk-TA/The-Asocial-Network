namespace TheAsocialNetwork.UI.UWP.Helpers.Data
{
    using System.Collections.Generic;
    using TheAsocialNetwork.UI.UWP.Models.Parse;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;
    using Parse;
    using Common.Extensions;
    public class SqLiteToParseObjecConvertor
    {
        public IEnumerable<PostParse> ConvertRangeOfPost(IEnumerable<PostSql> sqlPosts)
        {
            var parsePosts = new List<PostParse>();

            sqlPosts.ForEach(p => parsePosts.Add(this.ConvertSinglePost(p)));

            return parsePosts;
        }

        public PostParse ConvertSinglePost(PostSql sqlPost)
        {
            var parsePost = new PostParse()
            {
                Title = sqlPost.Title,
                Content = sqlPost.Content,
                Category = sqlPost.Category,
                IsBest = sqlPost.IsBest,
                Location = this.ConvertSingleLocation(sqlPost.Location)
            };

            if (sqlPost.Images != null)
            {
                sqlPost.Images.ForEach(i => parsePost.AddToList("Images", this.ConvertSingleImage(i)));
            }

            if (sqlPost.Videos != null)
            {
                sqlPost.Videos.ForEach(v => parsePost.AddToList("Videos", this.ConvertSingleVideo(v)));
            }

            return parsePost;
        }


        public ImageParse ConvertSingleImage(ImageSql sqlImage)
        {
            var parseImage = new ImageParse()
            {
                Title = sqlImage.Title,
                Description = sqlImage.Description,

            };

            if (sqlImage.ImageInfo != null)
            {
                var sqlImageInfo = sqlImage.ImageInfo;

                parseImage.ImageInfo = new ImageInfoParse()
                {
                    OriginalName = sqlImageInfo.OriginalName,
                    FileExstension = sqlImageInfo.FileExstension,
                    ByteArrayContent = sqlImageInfo.ByteArrayContent
                };
            }

            return parseImage;
        }

        public VideoParse ConvertSingleVideo(VideoSql sqlVideo)
        {
            var parseVideo = new VideoParse()
            {
                Title = sqlVideo.Title,
                Description = sqlVideo.Description,
                VideoUrl = sqlVideo.VideoUrl
            };

            return parseVideo;
        }

        public LocationParse ConvertSingleLocation(LocationSql sqlLocation)
        {
            var parseLocation = new LocationParse()
            {
                Latitude = sqlLocation.Latitude,
                Longitude = sqlLocation.Longitude,
                Town = sqlLocation.Town,
                Country = sqlLocation.Country
            };

            return parseLocation;
        }
    }
}
