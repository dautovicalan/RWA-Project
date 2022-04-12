using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class AspNetUserLogins
    {
        public int LoginProvider { get; set; }
        public int ProviderKey { get; set; }
        public int UserId { get; set; }
    }
}
