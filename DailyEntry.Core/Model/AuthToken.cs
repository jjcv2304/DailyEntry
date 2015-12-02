using System;

namespace DailyEntry.Core.Model
{
    public class AuthToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }
    }
}
