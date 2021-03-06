﻿namespace TheAsocialNetwork.UI.UWP.Models.SqLite
{
    using System;
    using SQLite.Net.Attributes;
    using SQLiteNetExtensions.Attributes;

    [Table("Videos")]
    public class VideoSql
    {

        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string ObjectId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        [ForeignKey(typeof(PostSql))]
        public int PostId { get; set; }

        [ManyToOne]
        public PostSql Post { get; set; }
    }
}
