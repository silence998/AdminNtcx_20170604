using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using AdminNtcx.WebUI.Infrastructure.Abstract;
using AdminNtcx.Domain.Abstract;
using AdminNtcx.Domain.Entities;

namespace AdminNtcx.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        //创建与User类相对于的存储器
        private IUserInfoRepository repository;

        public FormsAuthProvider(IUserInfoRepository userInfoRepository)
        {
            this.repository = userInfoRepository;
        }

        public bool Authenticate(string userName, string password)
        {
            UserInfo UserInfo = repository.UserInfos.FirstOrDefault(p => p.UserName == userName && p.Password == password);
            bool result = false;
            if ( UserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userName, false);

                //ticket用于存放登录名和用户权限Role
                //用户权限Role存放于ticket.UserData中
                //注意顺序，先要执行上面的SetAuthCookie，再生成ticket，否则会导致ticket无法正常读取
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,userName,DateTime.Now,DateTime.Now.AddMinutes(20),true,"1","/");
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                cookie.HttpOnly = true;
                HttpContext.Current.Response.Cookies.Add(cookie);

                result = true;
                
            }
            return result;
        }
    }
}