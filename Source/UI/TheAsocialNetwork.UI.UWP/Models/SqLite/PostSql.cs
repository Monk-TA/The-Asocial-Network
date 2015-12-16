namespace TheAsocialNetwork.UI.UWP.Models.SqLite
{
    using System;
    using System.Collections.Generic;
    using SQLite.Net.Attributes;
    using TheAsocialNetwork.UI.UWP.Models.Parse;

    [Table("Posts")]
    public class PostSql
    {
        private ICollection<VideoSql> videos;
        private ICollection<ImageSql> images; 

        public PostSql()
        {
            this.videos = new List<VideoSql>();
            this.images = new List<ImageSql>();
        }

        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string ObjectId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public ImageSql Image { get; set; }

        public VideoSql Video { get; set; }

        public LocationSql Location { get; set; }

        public bool IsBest { get; set; }

        public ICollection<ImageSql> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public ICollection<VideoSql> Videos
        {
            get { return this.videos; }
            set { this.videos = value; }
        }
    }
}
