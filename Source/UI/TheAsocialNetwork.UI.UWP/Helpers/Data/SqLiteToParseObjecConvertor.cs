namespace TheAsocialNetwork.UI.UWP.Helpers.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TheAsocialNetwork.UI.UWP.Models.Parse;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;
    using Parse;
    using Common.Extensions;
    using TheAsocialNetwork.UI.UWP.Helpers.Contracts;
    using TheAsocialNetwork.UI.UWP.Services.Contracts;
    using TheAsocialNetwork.UI.UWP.Services.Data.Parse;

    public class SqLiteToParseObjecConvertor : ISqLiteToParseObjecConvertor
    {
        private IParseFilesService parseFilesService;

        public SqLiteToParseObjecConvertor()
            :this(new ParseFilesService())
        {
        }

        public SqLiteToParseObjecConvertor(IParseFilesService service)
        {
            this.parseFilesService = service;
        }

        public async Task<IEnumerable<PostParse>> ConvertRangeOfPostAsync(IEnumerable<PostSql> sqlPosts)
        {
            if (sqlPosts == null)
            {
                return null;
            }

            var posts = (await Task.WhenAll(sqlPosts.Select(p => this.ConvertSinglePostAsync(p)))).ToList();

            return posts;
        }

        public async Task<PostParse> ConvertSinglePostAsync(PostSql sqlPost)
        {
            if (sqlPost == null)
            {
                return null;
            }

            var parsePost = new PostParse()
            {
                Title = sqlPost.Title,
                Content = sqlPost.Content,
                Category = sqlPost.Category,
                IsBest = sqlPost.IsBest,
                Location = this.ConvertSingleLocation(sqlPost.Location)
            };

            var parseImages = await Task.WhenAll(sqlPost.Images.Select(this.ConvertSingleImageAsync));

            if (sqlPost.Images != null)
            {
                parseImages.ForEach(i => parsePost.AddToList("Images", i));
            }

            if (sqlPost.Videos != null)
            {
                sqlPost.Videos.ForEach(v => parsePost.AddToList("Videos", this.ConvertSingleVideoAsync(v)));
            }



            return parsePost;
        }

        public async Task<ImageParse> ConvertSingleImageAsync(ImageSql sqlImage)
        {
            var parseImage = new ImageParse()
            {
                Title = sqlImage.Title,
                Description = sqlImage.Description,

            };

            if (sqlImage.ImageInfo != null)
            {
                var sqlImageInfo = sqlImage.ImageInfo;

                var imageInfo = new ParseFile(sqlImageInfo.OriginalName.ReplaceFileNameWithGuid(), sqlImageInfo.ByteArrayContent);

                imageInfo = await this.parseFilesService.UploadFileAsync(imageInfo);

                parseImage.ImageInfo = imageInfo;
                parseImage.ImageUrl = imageInfo.Url.OriginalString;
            }

            return parseImage;
        }

        public VideoParse ConvertSingleVideoAsync(VideoSql sqlVideo)
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
