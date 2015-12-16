namespace TheAsocialNetwork.UI.UWP.Models.Parse
{
    using System.Collections.Generic;
    using global::Parse;

    [ParseClassName("Post")]
    public class PostParse : ParseObject
    {
        //private ICollection<ImageParse> images;
        //private ICollection<VideoParse> videos;

        public PostParse()
        {
           // this.Images = new List<ImageParse>();
           // this.Videos = new List<VideoParse>();
        }

        [ParseFieldName("Title")]
        public string Title
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        [ParseFieldName("Content")]
        public string Content
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        [ParseFieldName("Category")]
        public string Category
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }
        
        [ParseFieldName("Location")]
        public LocationParse Location
        {
            get { return this.GetProperty<LocationParse>(); }
            set { this.SetProperty<LocationParse>(value); }
        }

        [ParseFieldName("IsBest")]
        public bool IsBest
        {
            get { return this.GetProperty<bool>(); }
            set { this.SetProperty<bool>(value); }
        }


        [ParseFieldName("Images")]
        public List<ImageParse> Images
        {
            get { return this.GetProperty<List<ImageParse>>(); }
            set { this.SetProperty<List<ImageParse>>(value); }
        }

        [ParseFieldName("Videos")]
        public List<VideoParse> Videos
        {
            get { return this.GetProperty<List<VideoParse>>(); }
            set { this.SetProperty<List<VideoParse>>(value); }
        }
    }
}
