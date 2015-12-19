namespace TheAsocialNetwork.UI.UWP.Models.Parse
{
    using System.Collections.Generic;
    using global::Parse;

    public class UserParse : ParseUser
    { 
        [ParseFieldName("Avatar")]
        public AvatarParse Avatar
        {
            get { return this.GetProperty<AvatarParse>(); }
            set { this.SetProperty<AvatarParse>(value); }
        }

        //[ParseFieldName("PostsRelations")]
        //public ParseRelation<PostParse> PostsRelations
        //{
        //    get { return this.GetRelationProperty<PostParse>(); }
        //}

        [ParseFieldName("Posts")]
        public List<PostParse> Posts
        {
            get { return this.GetProperty<List<PostParse>>(); }
            set { this.SetProperty<List<PostParse>>(value); }
        }
    }
}
