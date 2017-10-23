using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminNtcx.Domain.Entities;
using System.Data.Entity;

namespace AdminNtcx.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }
    }
}
