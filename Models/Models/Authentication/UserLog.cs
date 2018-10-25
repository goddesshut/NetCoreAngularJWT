using Models.Enums;
using System;

namespace Models
{
    public class UserLog
    {
        public long LogId { get; set; }
        public string Username { get; set; }
        public LoginType ELoginType { get; set; }
        public string LoginType { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
