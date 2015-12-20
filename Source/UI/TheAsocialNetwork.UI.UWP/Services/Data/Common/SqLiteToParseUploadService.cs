namespace TheAsocialNetwork.UI.UWP.Services.Data.Common
{
    using System.Threading.Tasks;
    using TheAsocialNetwork.UI.UWP.Helpers.Data;
    using TheAsocialNetwork.UI.UWP.Services.Data.Parse;
    using TheAsocialNetwork.UI.UWP.Services.Data.SqLite;

    public class SqLiteToParseUploadService
    {
        private ParsePostsService parseServoce;
        private SqLitePostsService sqLiteService;
        private SqLiteToParseObjecConvertor sqlToPaserConv;

        public SqLiteToParseUploadService()
        {
            this.parseServoce = new ParsePostsService();
            this.sqLiteService = new SqLitePostsService();
            this.sqlToPaserConv = new SqLiteToParseObjecConvertor();
        }

        public async Task<bool> UploudNewPostToParseAsync()
        {
            var sqLitePosts = await this.sqLiteService.GetAllPostsAsync();
            var parsePostsFromSqLite = await this.sqlToPaserConv.ConvertRangeOfPostAsync(sqLitePosts);

            var response = await this.parseServoce.AddNewRangeOfPostAsync(parsePostsFromSqLite);

            var deleted =  await this.sqLiteService.DeleteAllPostsAsync();

            return response;
        }
    }
}
