namespace TheAsocialNetwork.UI.UWP.Models.SqLite
{
    using System;
    using System.Collections.Generic;
    using SQLite.Net.Attributes;
    using SQLiteNetExtensions.Attributes;

    [Table("Users")]
    public class UserSql
    {
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

        [OneToOne]
        public AvatarSql Avatar { get; set; }

        [OneToMany]
        public List<PostSql> Posts { get; set; }
    }
}
