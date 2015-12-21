namespace TheAsocialNetwork.UI.UWP.Services.Data.Parse
{
    using System;
    using System.Threading.Tasks;
    using global::Parse;
    using TheAsocialNetwork.UI.UWP.Services.Contracts;

    public class ParseFilesService : IParseFilesService
    {
        public async Task<ParseFile> UploadFileAsync(ParseFile file)
        {
            try
            {
                await file.SaveAsync();

                return file;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return null;
            }
        }
    }
}
