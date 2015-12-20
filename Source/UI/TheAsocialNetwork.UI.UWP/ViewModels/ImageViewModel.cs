namespace TheAsocialNetwork.UI.UWP.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using TheAsocialNetwork.UI.UWP.Models.Parse;

    public class ImageViewModel : BaseViewModel
    {
        public static Expression<Func<ImageParse, ImageViewModel>> FromParseObjectExpr
        {
            get
            {
                return pObj => new ImageViewModel()
                {
                    ObjectId = pObj.ObjectId,
                    Title = pObj.Title,
                    Description = pObj.Description,
                    createdAt = pObj.CreatedAt,
                    CreatedAt = pObj.CreatedAt,
                    imageUrl = pObj.ImageUrl,
                    // TODO: see if ImageInfo is necessary
                };
            }
        }

        private int id;
        private string objectId;
        private DateTime? createdAt;
        private DateTime? updatedAt;
        private string title;
        private string dscription;
        private ImageViewModel imageInfo;
        private string imageUrl;

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

        public string Description
        {
            get { return this.dscription; }
            set
            {
                this.dscription = value;
                this.OnPropertyChanged("Description");
            }
        }

        public string ImageUrl
        {
            get { return this.imageUrl; }
            set
            {
                this.imageUrl = value;
                this.OnPropertyChanged("ImageUrl");
            }
        }

        public ImageViewModel ImageInfo
        {
            get { return this.imageInfo; }
            set
            {
                this.imageInfo = value;
                this.OnPropertyChanged("ImageInfo");
            }
        }
    }
}
