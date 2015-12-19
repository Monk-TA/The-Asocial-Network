namespace TheAsocialNetwork.UI.UWP.ViewModels
{
    using System;

    public class VideoViewModel : BaseViewModel
    {
        private int id;
        private string objectId;
        private DateTime? createdAt;
        private DateTime? updatedAt;
        private string title;
        private string description;
        private string videoUrl;

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
            get { return this.description; }
            set
            {
                this.description = value;
                this.OnPropertyChanged("Description");
            }
        }

        public string VideoUrl
        {
            get { return this.videoUrl; }
            set
            {
                this.videoUrl = value;
                this.OnPropertyChanged("VideoUrl");
            }
        }
    }
}
