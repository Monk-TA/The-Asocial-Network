namespace TheAsocialNetwork.UI.UWP.Services.Data.Common
{
    using System.Threading.Tasks;
    using TheAsocialNetwork.UI.UWP.Helpers.Contracts;
    using TheAsocialNetwork.UI.UWP.Helpers.Data;
    using TheAsocialNetwork.UI.UWP.Services.Contracts;
    using TheAsocialNetwork.UI.UWP.Services.Data.Parse;
    using TheAsocialNetwork.UI.UWP.Services.Data.SqLite;

    public class SqLiteToParseUploadService : ISqLiteToParseUploadService
    {
        private IParsePostsService parseServoce;
        private ISqLitePostsService sqLiteService;
        private ISqLiteToParseObjecConvertor sqlToPaserConv;

        public SqLiteToParseUploadService()
            : this(new ParsePostsService(), new SqLitePostsService(), new SqLiteToParseObjecConvertor())
        {
        }

        public SqLiteToParseUploadService(IParsePostsService parse, ISqLitePostsService sqLite, ISqLiteToParseObjecConvertor sqlToPase)
        {
            this.parseServoce = parse;
            this.sqLiteService = sqLite;
            this.sqlToPaserConv = sqlToPase;
        }

        public async Task<bool> UploudNewPostToParseAsync()
        {
            var sqLitePosts = await this.sqLiteService.GetAllPostsAsync();
            var parsePostsFromSqLite = await this.sqlToPaserConv.ConvertRangeOfPostAsync(sqLitePosts);

            var isOk = await this.parseServoce.AddNewRangeOfPostAsync(parsePostsFromSqLite);

            if (isOk)
            {
                var deleted = await this.sqLiteService.DeleteAllPostsAsync();
            }

            return isOk;
        }
    }
}
