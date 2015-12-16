namespace TheAsocialNetwork.UI.UWP.Views
{
    using System.Collections.Generic;
    using System.Net.Http;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Parse;
    using TheAsocialNetwork.UI.UWP.Models;
    using TheAsocialNetwork.UI.UWP.Models.Parse;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;
    using TheAsocialNetwork.UI.UWP.Services.Data.Parse;
    using TheAsocialNetwork.UI.UWP.Services.Data.SqLite;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountView : Page
    {
        public AccountView()
        {
            this.InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
           // await ParseUser.LogOutAsync();

            //var imageInfo = new ImageInfoParse()
            //{
            //    OriginalName = "Klati3",
            //    FileExstension = "se",
            //    ByteArrayContent = new byte[100]
            //};

            //var newImage = new ImageParse()
            //{
            //    Title = "Test image title",
            //    Description = "Deiba is snimkata",
            //    ImageInfo = imageInfo
            //};

            //var location = new LocationParse()
            //{
            //    Latitude = 43.3,
            //    Longitude = 43.3,
            //    Town = "Sofia",
            //    Country = "BGGG"
            //};

            //var video = new VideoParse()
            //{
            //    Description = "some very cool video",
            //    Title = "Qq wunderbar",
            //    VideoUrl = "https://www.youtube.com/watch?v=FrG4TEcSuRg"
            //};

            //var newPost = new PostParse()
            //{
            //    Title = "Test title",
            //    Content = "Some test content",
            //    Category = "Bitch",
            //    Location = location
            //};

            ////   await newPost.SaveAsync();

            //newPost.AddToList("Images", newImage);
            //newPost.AddToList("Videos", video);

            // await newPost.SaveAsync();

            //  newPost.Images = new List<ImageParse>();

            // newPost.Images.AddRange( new List<ImageParse>() { newImage});

            //var newUser = new UserParse()
            //{
            //    Password = "sraLiDnes123",
            //    Username = "Pesho2",
            //    Email = "pesho2@pesho.com"
            //};

            // newUser.Posts.Add(newPost);

            //  var parseService = new ParseAuthenticationService();

            //  await parseService.RegisterAsync(newUser);

            // var result = await parseService.LogInAsync("Pesho2", "sraLiDnes123");

            var postService = new ParsePostsService();

           var posts =  await postService.GetPostsByCategotyAsync(Category.Ideas);
        }

        private async void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {

            var imageInfo = new ImageInfoSql()
            {
                OriginalName = "Klati3",
                FileExstension = "se",
                ByteArrayContent = new byte[100]
            };

            var newImage = new ImageSql()
            {
                Title = "Test image title",
                Description = "Deiba is snimkata",
                ImageInfo = imageInfo
            };

            var location = new LocationSql()
            {
                Latitude = 43.3,
                Longitude = 43.3,
                Town = "Sofia",
                Country = "BGGG"
            };

            var video = new VideoSql()
            {
                Description = "some very cool video",
                Title = "Qq wunderbar",
                VideoUrl = "https://www.youtube.com/watch?v=FrG4TEcSuRg"
            };

            var newPost = new PostSql()
            {
                Title = "Test title",
                Content = "Some test content",
                Category = "Bitch",
                Location = location
            };

            //   await newPost.SaveAsync();

            newPost.Images.Add(newImage);
            newPost.Videos.Add(video);

            var newUser = new UserSql()
            {
                Password = "sraLiDnes123",
                Username = "Pesho2",
                Email = "pesho2@pesho.com"
            };

            newUser.Posts.Add(newPost);

            var service = new SqLitePostsService();

           var result =  await service.AddNewPostAsync(newPost);
        }
    }
}
