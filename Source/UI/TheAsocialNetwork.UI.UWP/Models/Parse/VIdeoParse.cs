namespace TheAsocialNetwork.UI.UWP.Models.Parse
{
    using global::Parse;

    [ParseClassName("Video")]
    public class VideoParse : ParseObject
    {
        [ParseFieldName("OriginalName")]
        public string Title
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        [ParseFieldName("OriginalName")]
        public string Description
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        [ParseFieldName("OriginalName")]
        public string VideoUrl
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }
    }
}
