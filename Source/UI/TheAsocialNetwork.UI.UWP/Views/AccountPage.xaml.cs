namespace TheAsocialNetwork.UI.UWP.Views
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using Windows.Media.Capture;
    using Parse;
    using TheAsocialNetwork.UI.UWP.Helpers.Data;
    using TheAsocialNetwork.UI.UWP.Services.Data.Parse;
    using TheAsocialNetwork.UI.UWP.Services.Data.SqLite;
    using Windows.Storage.Streams;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Imaging;
    using Windows.UI.Xaml.Navigation;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountPage : Page
    {
        public AccountPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            // await ParseUser.LogOutAsync();

            // var imageInfo = new ImageInfoParse()
            // {
            //     OriginalName = "Klati3",
            //     FileExstension = "se",
            //     ByteArrayContent = new byte[100]
            // };

            // var newImage = new ImageParse()
            // {
            //     Title = "Test image title",
            //     Description = "Deiba is snimkata",
            //     ImageInfo = imageInfo
            // };

            // var location = new LocationParse()
            // {
            //     Latitude = 43.3,
            //     Longitude = 43.3,
            //     Town = "Sofia",
            //     Country = "BGGG"
            // };

            // var video = new VideoParse()
            // {
            //     Description = "some very cool video",
            //     Title = "Qq wunderbar",
            //     VideoUrl = "https://www.youtube.com/watch?v=FrG4TEcSuRg"
            // };

            // var newPost = new PostParse()
            // {
            //     Title = "Test title",
            //     Content = "Some test content",
            //     Category = "Bitch",
            //     Location = location
            // };

            // newPost.AddToList("Images", newImage);
            // newPost.AddToList("Videos", video);

            // await newPost.SaveAsync();

            //// newPost.Images = new List<ImageParse>();

            //// newPost.Images.AddRange(new List<ImageParse>() { newImage });

            // var newUser = new UserParse()
            // {
            //     Password = "sraLiDnes123",
            //     Username = "Pesho2",
            //     Email = "pesho2@pesho.com"
            // };

            // newUser.Posts.Add(newPost);

            // var parseService = new ParseAuthenticationService();

            // await parseService.RegisterAsync(newUser);

            // var result = await parseService.LogInAsync("Pesho2", "sraLiDnes123");

            // var postService = new ParsePostsService();

            // var posts = await postService.GetCurrentUserAllPostsAsync(Category.Ideas);
        }

        private async void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            var camera = new CameraCaptureUI();

            var photo = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);

            ImageInfoSql imageInfo = null;

            if (photo != null)
            {
                var extension = photo.FileType;
                var bytearray = File.ReadAllBytes(photo.Path);
                var nae = photo.DisplayName;

                imageInfo = new ImageInfoSql()
                {
                    OriginalName = nae,
                    FileExstension = extension,
                    ByteArrayContent = bytearray
                };
            }

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
                Location = location,
                Images = new List<ImageSql>() { newImage },
                Videos = new List<VideoSql>() { video }
            };

            var newUser = new UserSql()
            {
                Password = "sraLiDnes123",
                Username = "Pesho2",
                Email = "pesho2@pesho.com",
                Posts = new List<PostSql>() { newPost }
            };




            var sqSservice = new SqLitePostsService();

             var sqlResponce = await sqSservice.AddUserWithDatasync(newUser);

            var postsSql = await sqSservice.GetAllPostsAsync();

            await ParseUser.LogOutAsync();
            var parseService = new ParseAuthenticationService();
            var result = await parseService.LogInAsync("Pesho2", "sraLiDnes123");

            var postServiceParse = new ParsePostsService();
            var sqlRoParseConv = new SqLiteToParseObjecConvertor();

            var parsePostsFromSqLite = await sqlRoParseConv.ConvertSinglePostAsync(postsSql.FirstOrDefault());

            var response = await postServiceParse.AddNewPostAsync(parsePostsFromSqLite);

            var parsePosts = (await postServiceParse.GetCurrentUserAllPostsAsync()).FirstOrDefault();

            this.img.Source = new BitmapImage(parsePosts.Images.FirstOrDefault().ImageInfo.Url);
        }

        public async Task<BitmapImage> ImageFromBytes(byte[] bytes)
        {
            BitmapImage image = new BitmapImage();
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(bytes.AsBuffer());
                stream.Seek(0);
                await image.SetSourceAsync(stream);
            }
            return image;
        }
    }
}
