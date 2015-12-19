namespace TheAsocialNetwork.UI.UWP.Models.Parse
{
    using System;
    using System.Linq.Expressions;
    using global::Parse;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;

    [ParseClassName("ImageInfo")]
    public class ImageInfoParse : ParseObject
    {
        public static Expression<Func<ImageInfoSql , ImageInfoParse>> FromSqlObject
        {
            get
            {
                return sqlObj => new ImageInfoParse()
                {
                    OriginalName = sqlObj.OriginalName,
                    FileExstension = sqlObj.OriginalName,
                    ByteArrayContent = sqlObj.ByteArrayContent
                };
            }
        }

        [ParseFieldName("OriginalName")]
        public string OriginalName
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        [ParseFieldName("FileExstension")]
        public string FileExstension
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        [ParseFieldName("ByteArrayContent")]
        public byte[] ByteArrayContent
        {
            get { return this.GetProperty<byte[]>(); }
            set { this.SetProperty<byte[]>(value); }
        }
    }
}
