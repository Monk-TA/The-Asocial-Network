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

        [ParseFieldName("ImageUrl")]
        public string ImageUrl
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        [ParseFieldName("ImageInfo")]
        public ParseFile ImageInfo
        {
            get { return this.GetProperty<ParseFile>(); }
            set { this.SetProperty<ParseFile>(value); }
        }
    }
}
