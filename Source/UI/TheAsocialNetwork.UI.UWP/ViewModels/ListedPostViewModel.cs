namespace TheAsocialNetwork.UI.UWP.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using TheAsocialNetwork.Common.Extensions;
    using TheAsocialNetwork.UI.UWP.Commands;
    using TheAsocialNetwork.UI.UWP.Services.Data.Parse;

    public class ListedPostViewModel : BaseViewModel
    {
        private ObservableCollection<PostViewModel> posts;

        private bool isWaitunForData = false;

        private ICommand getDataommand;

        public ListedPostViewModel()
        {
            this.HandleGetDataCommand();
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
            this.IsWaitunForData = true;

            try
            {
                var postServiceParse = new ParsePostsService();
             
                var parsePosts = (await postServiceParse.GetCurrentUserAllPostsAsync());

                if (parsePosts != null)
                {
                    this.Posts = parsePosts.AsQueryable().Select(PostViewModel.FromParseObjectExpr).ToList();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }


            this.IsWaitunForData = false;
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
