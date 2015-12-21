namespace TheAsocialNetwork.UI.UWP.Services.Contracts
{
    using System.Threading.Tasks;
    using global::Parse;

    public interface IParseFilesService
    {
        Task<ParseFile> UploadFileAsync(ParseFile file);
    }
}