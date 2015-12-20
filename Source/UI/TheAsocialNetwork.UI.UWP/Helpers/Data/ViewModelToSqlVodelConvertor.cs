namespace TheAsocialNetwork.UI.UWP.Helpers.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TheAsocialNetwork.Common.Extensions;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;
    using TheAsocialNetwork.UI.UWP.Services.Apis;
    using TheAsocialNetwork.UI.UWP.Services.Data.SqLite;
    using TheAsocialNetwork.UI.UWP.ViewModels;

    public class ViewModelToSqlVodelConvertor
    {

        private GeolocationService geolocationService;
        private SqLitePostsService sqLiteService;

        public ViewModelToSqlVodelConvertor()
        {
            this.geolocationService = new GeolocationService();
            this.sqLiteService = new SqLitePostsService();
        }

        public async Task<int> ConvertSinglePostAsync(PostViewModel sqlPost)
        {
            if (sqlPost == null)
            {
                return -1;
            }

            LocationSql location = new LocationSql();

            var addres = await this.geolocationService.GetCurrentCivilAddresByLocationAsync();

            if (addres != null)
            {
                location.Town = addres.Town;
                location.Country = addres.Country;
            }

            var images = new List<ImageSql>();

            // TODO: ViewModel to SqLite model make it right way
            sqlPost.Images.ForEach(i =>
            {
                var imgInfo = new ImageInfoSql()
                {
                    OriginalName = i.ImageInfo.OriginalName,
                    FileExstension = i.ImageInfo.FileExstension,
                    ByteArrayContent = i.ImageInfo.ByteArrayContent
                };

                var img = new ImageSql()
                {
                    Title = i.Title,
                    Description = i.Description,
                    ImageInfo = imgInfo
                };

                images.Add(img);
            });

            var post = new PostSql()
            {
                Title = sqlPost.Title,
                Content = sqlPost.Content,
                Category = sqlPost.Category,
                IsBest = sqlPost.IsBest,
                Location = location,
                Images = images
            };

            var result = await this.sqLiteService.AddNewPostAsync(post);

            return result;
        }


    }
}
