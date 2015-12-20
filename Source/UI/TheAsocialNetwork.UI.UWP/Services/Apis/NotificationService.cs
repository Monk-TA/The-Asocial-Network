using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAsocialNetwork.UI.UWP.Services.Apis
{
    using Windows.UI.Notifications;
    using NotificationsExtensions.Toasts;
    using TheAsocialNetwork.UI.UWP.Helpers.ToastNotifications;

    public class NotificationService
    {
        private ToastCrerator toaster;

        public NotificationService()
        {
            this.toaster = new ToastCrerator();
        }

        public void ShowSuccessToast(string message)
        {
            ToastVisual visual = this.toaster.GetVisualToast(message, null, null);
          
            ToastContent content = this.toaster.GetToastContent(visual, null);
            var doc = content.GetXml();
            var notification = new ToastNotification(doc);
            ToastNotificationManager.CreateToastNotifier().Show(notification);
        }

        public void ShowErrorToastWithDismissButton(string message)
        {
            ToastVisual visual = this.toaster.GetVisualToast(message, null, null);

            var button = new ToastButtonDismiss();
            ToastActionsCustom actios = this.toaster.GetToastCustomActions(null, new List<IToastButton>() { button });
            ToastContent content = this.toaster.GetToastContent(visual, actios);
            var doc = content.GetXml();
            var notification = new ToastNotification(doc);
            ToastNotificationManager.CreateToastNotifier().Show(notification);
        }
    }
}
