namespace TheAsocialNetwork.UI.UWP.ViewModels
{
    using System;

    public class AvatarViewModel : BaseViewModel
    {
        private int id;
        private string objectId;
        private DateTime? createdAt;
        private DateTime? updatedAt;
        private ImageViewModel imageInfo;

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
