namespace TheAsocialNetwork.UI.UWP.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using TheAsocialNetwork.Common.Extensions;
    using TheAsocialNetwork.UI.UWP.Commands;
    using TheAsocialNetwork.UI.UWP.Helpers.Data;
    using TheAsocialNetwork.UI.UWP.Services.Apis;
    using TheAsocialNetwork.UI.UWP.Services.Data.Common;
    using Windows.Media.Capture;
    using Windows.UI.Popups;

    public class AddPostViewModel : BaseViewModel
    {
        private ObservableCollection<ImageViewModel> images;

        private PostViewModel post;

        private ICommand savePostCommand;
        private ICommand addImageCommand;

        private ViewModelToSqlVodelConvertor postToSqlModel;
        private SqLiteToParseUploadService sqlToParse;
        private NotificationService notificator;

        public AddPostViewModel()
        {
            this.postToSqlModel = new ViewModelToSqlVodelConvertor();
            this.sqlToParse = new SqLiteToParseUploadService();
            this.notificator = new NotificationService();
        }

        //public ICommand SavePost
        //{
        //    get
        //    {
        //        if (this.savePostCommand == null)
        //        {
        //            this.savePostCommand = new RelayCommand(this.HandleSavePostCommand);
        //        }

        //        return this.savePostCommand;
        //    }
        //}

        public ICommand AddImage
        {
            get
            {
                if (this.addImageCommand == null)
                {
                    this.addImageCommand = new RelayCommand(this.HandleAddImageCommand);
                }

                return this.addImageCommand;
            }
        }

        private async void HandleAddImageCommand()
        {
            var camera = new CameraCaptureUI();
            var photo = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);

            ImageInfoViewModel imageInfo = null;

            if (photo != null)
            {
                var extension = photo.FileType;
                var bytearray = File.ReadAllBytes(photo.Path);
                var name = photo.DisplayName;

                imageInfo = new ImageInfoViewModel()
                {
                    OriginalName = name,
                    FileExstension = extension,
                    ByteArrayContent = bytearray
                };

                var image = new ImageViewModel()
                {
                    ImageInfo = imageInfo,
                    ImageUrl = photo.Path
                };

                this.images.Add(image);
            }
            else
            {
                // TODO: Set real notification
                var dialog = new MessageDialog("Something Get Wrong");
                await dialog.ShowAsync();
            }
        }

        public async Task HandleSavePostCommand()
        {

            this.Post.Images = this.Images;

            var result = await this.postToSqlModel.ConvertSinglePostAsync(this.Post);

            // TODO: Do that at background service, this thing has no place here!!
            var success = await this.sqlToParse.UploudNewPostToParseAsync();

            if (success)
            {
                this.notificator.ShowSuccessToast("Success - you added new " + this.Post.Category);
            }
            else
            {
                this.notificator.ShowErrorToastWithDismissButton("Something Get really wrong, try again later!");
            }

            //var dialog = new MessageDialog("Result = " + posts);
            //await dialog.ShowAsync();
        }

        public PostViewModel Post
        {
            get
            {
                if (this.post == null)
                {
                    this.post = new PostViewModel();
                }
                return this.post;
            }
            set
            {
                if (this.post == null)
                {
                    this.post = new PostViewModel();
                }
                this.post = value;
                this.OnPropertyChanged("Post");
            }
        }

        public IEnumerable<ImageViewModel> Images
        {
            get { return this.images ?? (this.images = new ObservableCollection<ImageViewModel>()); }
            set
            {
                if (this.images == null)
                {
                    this.images = new ObservableCollection<ImageViewModel>();
                }

                this.images.Clear();

                value.ForEach(this.images.Add);
            }
        }
    }
}
