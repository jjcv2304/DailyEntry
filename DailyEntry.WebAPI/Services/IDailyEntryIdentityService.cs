namespace DailyEntry.WebAPI.Services
{
    public interface IDailyEntryIdentityService
    {
        string CurrentUser { get; }
    }
}