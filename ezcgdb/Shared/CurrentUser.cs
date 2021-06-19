using System.Collections.Generic;

namespace ezcgdb.Shared
{
    public class CurrentUser
    {
        public string UserName { get; set; }
        public bool IsAuthenticated { get; set; }
        public Dictionary<string, string> Claims { get; set; }
    }
}
