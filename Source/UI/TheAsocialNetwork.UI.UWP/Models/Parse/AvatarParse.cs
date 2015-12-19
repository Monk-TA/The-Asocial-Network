namespace TheAsocialNetwork.UI.UWP.Models.Parse
{
    using System;
    using System.Linq.Expressions;
    using global::Parse;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;

    [ParseClassName("Avatar")]
    public class AvatarParse : ParseObject
    {
        public static Expression<Func<AvatarSql, AvatarParse>> FromSqlObject
        {
            get
            {
                return sqlObj => new AvatarParse()
                {
                  ImageInfo = new ImageInfoParse()
                };
            }
        }

        [ParseFieldName("ImageInfo")]
        public ImageInfoParse ImageInfo
        {
            get { return this.GetProperty<ImageInfoParse>(); }
            set { this.SetProperty<ImageInfoParse>(value); }
        }
    }
}