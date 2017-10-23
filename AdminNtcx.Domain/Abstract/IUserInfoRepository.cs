using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminNtcx.Domain.Entities;

namespace AdminNtcx.Domain.Abstract
{
    public interface IUserInfoRepository
    {
        IEnumerable<UserInfo> UserInfos { get; }

        //定义保存UserInfo的接口，并在Concrete中的EFUserInfoRepository实现这个接口
        void SaveUserInfo(UserInfo userInfo);

        //删除UserInfo
        UserInfo DeleteUserInfo(int userID);
    }

    
}
