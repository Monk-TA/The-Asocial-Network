namespace TheAsocialNetwork.UI.UWP.Helpers.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TheAsocialNetwork.UI.UWP.Models.Parse;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;

    public interface ISqLiteToParseObjecConvertor
    {
        Task<IEnumerable<PostParse>> ConvertRangeOfPostAsync(IEnumerable<PostSql> sqlPosts);
        Task<PostParse> ConvertSinglePostAsync(PostSql sqlPost);
        Task<ImageParse> ConvertSingleImageAsync(ImageSql sqlImage);
        VideoParse ConvertSingleVideoAsync(VideoSql sqlVideo);
        LocationParse ConvertSingleLocation(LocationSql sqlLocation);
    }
}