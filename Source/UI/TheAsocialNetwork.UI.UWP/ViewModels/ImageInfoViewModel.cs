namespace TheAsocialNetwork.UI.UWP.ViewModels
{
    using System;

    public class ImageInfoViewModel : BaseViewModel
    {
        private int id;
        private string objectId;
        private DateTime? createdAt;
        private DateTime? updatedAt;
        private string originalName;
        private string fileExstension;
        private byte[] byteArrayContent;

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

        public string OriginalName
        {
            get { return this.originalName; }
            set
            {
                this.originalName = value;
                this.OnPropertyChanged("OriginalName");
            }
        }

        public string FileExstension
        {
            get { return this.fileExstension; }
            set
            {
                this.fileExstension = value;
                this.OnPropertyChanged("FileExstension");
            }
        }

        public byte[] ByteArrayContent
        {
            get { return this.byteArrayContent; }
            set
            {
                this.byteArrayContent = value;
                this.OnPropertyChanged("ByteArrayContent");
            }
        }
    }
}
