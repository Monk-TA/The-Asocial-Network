namespace TheAsocialNetwork.UI.UWP.Models.Parse
{
    using global::Parse;

    [ParseClassName("Avatar")]
    public class AvatarParse : ParseObject
    {
        [ParseFieldName("ImageInfo")]
        public ImageInfoParse ImageInfo
        {
            get { return this.GetProperty<ImageInfoParse>(); }
            set { this.SetProperty<ImageInfoParse>(value); }
        }
    }
}