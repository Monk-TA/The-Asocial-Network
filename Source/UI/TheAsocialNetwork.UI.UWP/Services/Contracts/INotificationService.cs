namespace TheAsocialNetwork.UI.UWP.Services.Contracts
{
    public interface INotificationService
    {
        void ShowSuccessToast(string message);
        void ShowErrorToastWithDismissButton(string message);
    }
}