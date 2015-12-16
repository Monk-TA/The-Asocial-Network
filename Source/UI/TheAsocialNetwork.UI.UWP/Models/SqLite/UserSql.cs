namespace TheAsocialNetwork.UI.UWP.Models.SqLite
{
    using System;
    using System.Collections.Generic;
    using SQLite.Net.Attributes;

    [Table("Users")]
    public class UserSql
    {
        private ICollection<PostSql> posts;

        public UserSql()
        {
            this.posts = new List<PostSql>();
        }

        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string ObjectId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public AvatarSql Avatar { get; set; }

        public ICollection<PostSql> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
