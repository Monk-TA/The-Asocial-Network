namespace TheAsocialNetwork.UI.UWP.Helpers.Contracts
{
    using System.Collections.Generic;
    using NotificationsExtensions.Toasts;

    public interface IToastCrerator
    {
        ToastVisual GetVisualToast(
            string title,
            string contentFirstLine,
            string contentSecondLine,
            IEnumerable<string> imagesPaths = null,
            string logoPath = null);

        ToastActionsCustom GetToastCustomActions(IEnumerable<IToastInput> textBoxes, IEnumerable<IToastButton> buttons, string audioUri = null);
        ToastContent GetToastContent(ToastVisual visual, ToastActionsCustom actions);
    }
}