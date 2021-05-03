using JewelleryStore.Infrastructure;

namespace JewelleryStore.Api
{
    public class ApplicationContext: IApplicationContext
    {
        public int CurrentUserId => 2;
    }
}
