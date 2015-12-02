using DailyEntry.Core.Model;

namespace DailyEntry.Core.Interfaces
{
    public interface ISecurityRepository
    {
        ApiUser GetApiUser(string apiKey);
        void AddAuthToken(AuthToken authToken);
        AuthToken GetAuthToken(string token);
    }
}