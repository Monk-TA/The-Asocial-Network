namespace TheAsocialNetwork.UI.UWP.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Windows.UI.Xaml.Media.Imaging;
    using Parse;
    using TheAsocialNetwork.Common.Extensions;
    using TheAsocialNetwork.UI.UWP.Commands;
    using TheAsocialNetwork.UI.UWP.Helpers.Data;
    using TheAsocialNetwork.UI.UWP.Services.Data.Parse;
    using TheAsocialNetwork.UI.UWP.Services.Data.SqLite;

    public class ListedPostViewModel : BaseViewModel
    {
        private ObservableCollection<PostViewModel> posts;

        private bool isWaitunForData = true;

        private ICommand getDataommand;

        public ListedPostViewModel(){
        }


        public ICommand GetData
        {
            get
            {
                if (this.getDataommand == null)
                {
                    this.getDataommand = new RelayCommand(this.HandleGetDataCommand);
                }

                return this.getDataommand;
            }
        }

        private async void HandleGetDataCommand()
        {
            this.isWaitunForData = true;

            var sqSservice = new SqLitePostsService();

            // var sqlResponce = await sqSservice.AddUserWithDatasync(newUser);

            var postsSql = await sqSservice.GetAllPostsAsync();

            await ParseUser.LogOutAsync();
            var parseService = new ParseAuthenticationService();
            var result = await parseService.LogInAsync("Pesho2", "sraLiDnes123");

            var postServiceParse = new ParsePostsService();
            var sqlRoParseConv = new SqLiteToParseObjecConvertor();

            var parsePostsFromSqLite = await sqlRoParseConv.ConvertSinglePostAsync(postsSql.FirstOrDefault());

            var response = await postServiceParse.AddNewPostAsync(parsePostsFromSqLite);

            var parsePosts = (await postServiceParse.GetCurrentUserAllPostsAsync());

            this.Posts = parsePosts.AsQueryable().Select(PostViewModel.FromParseObjectExpr).ToList();

            this.isWaitunForData = false;
        }

        public bool IsWaitunForData
        {
            get { return this.isWaitunForData; }
            set
            {
                this.isWaitunForData = value;
                this.OnPropertyChanged("IsWaitunForData");
            }
        }

        public IEnumerable<PostViewModel> Posts
        {
            get { return this.posts ?? (this.posts = new ObservableCollection<PostViewModel>()); }
            set
            {
                if (this.posts == null)
                {
                    this.posts = new ObservableCollection<PostViewModel>();
                }

                this.posts.Clear();

                value.ForEach(this.posts.Add);
            }
        }
    }
}
