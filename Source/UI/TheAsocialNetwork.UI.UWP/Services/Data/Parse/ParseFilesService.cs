namespace TheAsocialNetwork.UI.UWP.Services.Data.Parse
{
    using System;
    using System.Threading.Tasks;
    using global::Parse;

    public class ParseFilesService
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
