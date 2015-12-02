using System;
using DailyEntry.Core.Model;

namespace DailyEntry.Core.ViewModel
{
    public class AuthTokenVM
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public ApiUser ApiUser { get; set; }
    }
}
