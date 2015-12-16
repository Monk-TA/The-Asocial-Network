namespace TheAsocialNetwork.UI.UWP.Models.Parse
{
    using global::Parse;

    [ParseClassName("Image")]
    public class ImageParse : ParseObject
    {
        [ParseFieldName("Title")]
        public string Title
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        [ParseFieldName("Description")]
        public string Description
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        //[ParseFieldName("ImageInfo")]
        //public ParseRelation<ImageInfoParse> ImageInfo
        //{
        //    get { return this.GetRelationProperty<ImageInfoParse>(); }

        //}

        [ParseFieldName("ImageInfo")]
        public ImageInfoParse ImageInfo
        {
            get { return this.GetProperty<ImageInfoParse>(); }
            set { this.SetProperty<ImageInfoParse>(value); }
        }
    }
}
