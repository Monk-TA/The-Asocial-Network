namespace TheAsocialNetwork.UI.UWP.Services.Data.Parse
{
    using System;
    using System.Threading.Tasks;
    using global::Parse;
    using TheAsocialNetwork.UI.UWP.Models.Parse;

    public class ParseImagesService
    {
        public async Task<ImageParse> UploadImageAsync(ImageParse image)
        {
            try
            {
                await image.SaveAsync();

                return image;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                return null;
            }
        }
    }
}
