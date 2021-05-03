using JewelleryStore.Model;

namespace JewelleryStore.Infrastructure
{
    public interface IApplicationContext
    {
        int CurrentUserId { get; }
    }
}
