using System.Threading;

namespace DailyEntry.WebAPI.Services
{
    public class DailyEntryIdentityService : IDailyEntryIdentityService
    {
        public string CurrentUser
        {
            get
            {
                return Thread.CurrentPrincipal.Identity.Name;
            }
        }
    }

}