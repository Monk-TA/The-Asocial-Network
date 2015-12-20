namespace TheAsocialNetwork.UI.UWP.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq.Expressions;
    using System.Linq;
    using Parse;
    using TheAsocialNetwork.Common.Extensions;
    using TheAsocialNetwork.UI.UWP.Models.Parse;

    public class PostViewModel : BaseViewModel
    {
        public static Expression<Func<PostParse, PostViewModel>> FromParseObjectExpr
        {
            get
            {
                return pObj => new PostViewModel()
                {
                    ObjectId = pObj.ObjectId,
                    Title = pObj.Title,
                    Content = pObj.Content,
                    Category = pObj.Category,
                    CreatedAt = pObj.CreatedAt,
                    isBest = pObj.IsBest,
                    Location = LocationViewModel.FromParseObjectSngle(pObj.Location),
                    Images = pObj.Images.AsQueryable().Select(ImageViewModel.FromParseObjectExpr).ToList()
                };
            }
        }

        private ObservableCollection<ImageViewModel> images;
        private ObservableCollection<VideoViewModel> videos;

        private int id;
        private string objectId;
        private DateTime? createdAt;
        private DateTime? updatedAt;
        private string title;
        private string content;
        private string category;
        private LocationViewModel location;
        private bool isBest;

        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                this.OnPropertyChanged("Id");
            }
        }

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

        public string Title
        {
            get { return this.title; }
            set
            {
                this.title = value;
                this.OnPropertyChanged("Title");
            }
        }

        public string Content
        {
            get { return this.content; }
            set
            {
                this.content = value;
                this.OnPropertyChanged("Content");
            }
        }

        public string Category
        {
            get { return this.category; }
            set
            {
                this.category = value;
                this.OnPropertyChanged("Category");
            }
        }

        public LocationViewModel Location
        {
            get { return this.location; }
            set
            {
                this.location = value;
                this.OnPropertyChanged("Location");
            }
        }

        public bool IsBest
        {
            get { return this.isBest; }
            set
            {
                this.isBest = value;
                this.OnPropertyChanged("IsBest");
            }
        }

        public IEnumerable<ImageViewModel> Images
        {
            get { return this.images ?? (this.images = new ObservableCollection<ImageViewModel>()); }
            set
            {
                if (this.images == null)
                {
                    this.images = new ObservableCollection<ImageViewModel>();
                }

                this.images.Clear();

                value.ForEach(this.images.Add);
            }
        }

        public IEnumerable<VideoViewModel> Videos
        {
            get { return this.videos ?? (this.videos = new ObservableCollection<VideoViewModel>()); }
            set
            {
                if (this.videos == null)
                {
                    this.videos = new ObservableCollection<VideoViewModel>();
                }

                this.videos.Clear();

                value.ForEach(this.videos.Add);
            }
        }
    }
}
