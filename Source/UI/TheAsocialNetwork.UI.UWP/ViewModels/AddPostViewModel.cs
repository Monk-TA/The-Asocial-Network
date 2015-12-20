namespace TheAsocialNetwork.UI.UWP.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Windows.Input;
    using Windows.Media.Capture;
    using Windows.UI.Popups;
    using Parse;
    using TheAsocialNetwork.Common.Extensions;
    using TheAsocialNetwork.UI.UWP.Commands;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;
    using TheAsocialNetwork.UI.UWP.Services.Data.Parse;

    public class AddPostViewModel : BaseViewModel
    {
        private ObservableCollection<ImageViewModel> images;

        private PostViewModel post;

        private bool isWaitunForData = false;

        private ICommand savePostCommand;
        private ICommand addImageCommand;

        public AddPostViewModel()
        {

        }

        public ICommand SavePost
        {
            get
            {
                if (this.savePostCommand == null)
                {
                    this.savePostCommand = new RelayCommand(this.HandleSavePostCommand);
                }

                return this.savePostCommand;
            }
        }

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

        private async void HandleSavePostCommand()
        {
            var dialog = new MessageDialog("Adding new post");
            await dialog.ShowAsync();
        }

        public bool IsWaitunForData
        {
            get { return this.isWaitunForData; }
            set
            {
                this.isWaitunForData = value;
                this.OnPropertyChanged("IsWaitunForData");
            }
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
