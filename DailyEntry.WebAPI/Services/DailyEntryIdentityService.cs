using System.Threading;

namespace DailyEntry.WebAPI.Services
{
    public class DailyEntryIdentityService : IDailyEntryIdentityService
    {
        public string CurrentUser
        {
            get
            {
#if DEBUG
                return "jcarmona";
#else
                   return Thread.CurrentPrincipal.Identity.Name;
#endif

            }
        }
    }

}