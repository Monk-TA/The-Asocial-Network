namespace TheAsocialNetwork.UI.UWP.Models.Parse
{
    using global::Parse;

    [ParseClassName("ImageInfo")]
    public class ImageInfoParse : ParseObject
    {
        [ParseFieldName("OriginalName")]
        public string OriginalName
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        [ParseFieldName("FileExstension")]
        public string FileExstension
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        [ParseFieldName("ByteArrayContent")]
        public byte[] ByteArrayContent
        {
            get { return this.GetProperty<byte[]>(); }
            set { this.SetProperty<byte[]>(value); }
        }
    }
}
