using System.Collections.Generic;

namespace DailyEntry.Core.Model
{
    public class ApiUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        public string AppId { get; set; }

        public virtual ICollection<AuthToken> AuthTokens { get; set; }
    }
}
