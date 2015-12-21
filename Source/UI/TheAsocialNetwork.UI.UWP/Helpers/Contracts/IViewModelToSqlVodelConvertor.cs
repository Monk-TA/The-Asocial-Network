namespace TheAsocialNetwork.UI.UWP.Helpers.Contracts
{
    using System.Threading.Tasks;
    using TheAsocialNetwork.UI.UWP.ViewModels;

    public interface IViewModelToSqlVodelConvertor
    {
        Task<int> ConvertSinglePostAsync(PostViewModel sqlPost);
    }
}