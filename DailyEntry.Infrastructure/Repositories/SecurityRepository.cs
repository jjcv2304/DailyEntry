using System.Linq;
using DailyEntry.Core.Interfaces;
using DailyEntry.Core.Model;

namespace DailyEntry.Infrastructure.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly TrainningDB _context;

        public SecurityRepository(TrainningDB trainningDb)
        {
            _context = trainningDb;
        }


        public ApiUser GetApiUser(string apiKey)
        {
            return _context.ApiUsers.FirstOrDefault(u => u.AppId == apiKey);
        }

        public void AddAuthToken(AuthToken authToken)
        {
            _context.AuthTokens.Add(authToken);
        }

        public AuthToken GetAuthToken(string token)
        {
            return _context.AuthTokens.Include("ApiUser").FirstOrDefault(t => t.Token == token);
        }
    }
}
