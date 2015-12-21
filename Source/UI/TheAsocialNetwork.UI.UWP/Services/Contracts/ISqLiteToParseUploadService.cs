namespace TheAsocialNetwork.UI.UWP.Services.Contracts
{
    using System.Threading.Tasks;

    public interface ISqLiteToParseUploadService
    {
        Task<bool> UploudNewPostToParseAsync();
    }
}