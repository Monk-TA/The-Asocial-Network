namespace TheAsocialNetwork.UI.UWP.Views
{
    using System.Collections.Generic;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Parse;
    using TheAsocialNetwork.UI.UWP.Models;
    using TheAsocialNetwork.UI.UWP.Models.Parse;
    using TheAsocialNetwork.UI.UWP.Services.Data.Parse;

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

            var imageInfo = new ImageInfoParse()
            {
                OriginalName = "Klati3",
                FileExstension = "se",
                ByteArrayContent = new byte[100]
            };

            var newImage = new ImageParse()
            {
                Title = "Test image title",
                Description = "Deiba is snimkata",
                ImageInfo = imageInfo
            };

            var location = new LocationParse()
            {
                Latitude = 43.3,
                Longitude = 43.3,
                Town = "Sofia",
                Country = "BGGG"
            };

            var newPost = new PostParse()
            {
                Title = "Test title",
                Content = "Some test content",
                Category = "Bitch",
                Location = location
            };

            //   await newPost.SaveAsync();

            newPost.AddToList("Images", newImage);

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

            await postService.AddNewPostAsync(newPost);
        }
    }
}
