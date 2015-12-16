namespace TheAsocialNetwork.UI.UWP.Models.SqLite
{
    using System;
    using System.Collections.Generic;
    using SQLite.Net.Attributes;

    [Table("Users")]
    public class UserSql
    {
        private IEnumerable<PostSql> posts;

        public UserSql()
        {
            this.posts = new HashSet<PostSql>();
        }

        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }


        public string ObjectId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public IEnumerable<PostSql> Posts { get; set; }
    }
}
