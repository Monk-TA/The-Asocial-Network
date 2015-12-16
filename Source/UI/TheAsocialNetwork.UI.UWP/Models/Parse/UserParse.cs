namespace TheAsocialNetwork.UI.UWP.Models.Parse
{
    using System.Collections.Generic;
    using global::Parse;

    public class UserParse : ParseUser
    {
        //private ICollection<PostParse> posts;

        public UserParse()
        {
           // this.Posts = new List<PostParse>();
        }

        [ParseFieldName("Posts")]
        public List<PostParse> Posts
        {
            get { return this.GetProperty<List<PostParse>>(); }
            set { this.SetProperty<List<PostParse>>(value); }
        }
    }
}
