using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminNtcx.Domain.Abstract;
using AdminNtcx.Domain.Entities;

namespace AdminNtcx.Domain.Concrete
{
    public class EFUserInfoRepository : IUserInfoRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<UserInfo> UserInfos
        {
            get { return context.UserInfos; }
        }

        public void SaveUserInfo(UserInfo userInfo)
        {
            if( userInfo.UserID == 0)
            {
                //利用 context的 add 方法来插入一条新记录
                context.UserInfos.Add(userInfo);
            }
            else
            {
                UserInfo dbEntry = context.UserInfos.Find(userInfo.UserID);
                if( dbEntry != null)
                {
                    dbEntry.UserName = userInfo.UserName;
                    dbEntry.RealName = userInfo.RealName;
                    dbEntry.Password = userInfo.Password;
                }
            }
            context.SaveChanges();
        }

        public UserInfo DeleteUserInfo(int userID)
        {
            UserInfo dbEntry = context.UserInfos.Find(userID);
            if( dbEntry != null)
            {
                context.UserInfos.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
