namespace TheAsocialNetwork.UI.UWP.Models.SqLite
{
    using System;
    using System.Collections.Generic;
    using SQLite.Net.Attributes;
    using SQLiteNetExtensions.Attributes;

    [Table("Users")]
    public class UserSql
    {
        private List<PostSql> posts;

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

        [ForeignKey(typeof(AvatarSql))]
        public int AvatarId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public AvatarSql Avatar { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<PostSql> Posts { get; set; }
    }
}
