namespace TheAsocialNetwork.UI.UWP.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using TheAsocialNetwork.Common.Extensions;

    public class UserViewModel : BaseViewModel
    {
        private ObservableCollection<PostViewModel> posts;

        private string objectId;
        private DateTime? createdAt;
        private DateTime? updatedAt;
        private string username;
        private string password;
        private string email;
        private AvatarViewModel avatar;

        public string ObjectId
        {
            get { return this.objectId; }
            set
            {
                this.objectId = value;
                this.OnPropertyChanged("ObjectId");
            }
        }

        public DateTime? CreatedAt
        {
            get { return this.createdAt; }
            set
            {
                this.createdAt = value;
                this.OnPropertyChanged("CreatedAt");
            }
        }

        public DateTime? UpdatedAt
        {
            get { return this.updatedAt; }
            set
            {
                this.updatedAt = value;
                this.OnPropertyChanged("UpdatedAt");
            }
        }

        public string Username
        {
            get { return this.username; }
            set
            {
                this.username = value;
                this.OnPropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                this.password = value;
                this.OnPropertyChanged("Password");
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                this.email = value;
                this.OnPropertyChanged("Email");
            }
        }

        public AvatarViewModel Avatar
        {
            get { return this.avatar; }
            set
            {
                this.avatar = value;
                this.OnPropertyChanged("Avatar");
            }
        }

        public IEnumerable<PostViewModel> Videos
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
