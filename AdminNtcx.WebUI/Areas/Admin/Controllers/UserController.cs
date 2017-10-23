using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminNtcx.Domain.Abstract;
using AdminNtcx.Domain.Entities;

namespace AdminNtcx.WebUI.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        //创建与User类相对于的存储器
        private IUserInfoRepository repository;

        public UserController(IUserInfoRepository UserInfoRepository)
        {
            this.repository = UserInfoRepository;
        }

        // GET: Admin/User
        public ActionResult Index()
        {
            return View(repository.UserInfos);
        }

        //编辑用户普通视图
        public ViewResult Edit(int userID)
        {
            UserInfo UserInfo = repository.UserInfos.FirstOrDefault(p => p.UserID == userID);
            return View(UserInfo);
        }

        //编辑用户的提交操作,submit
        [HttpPost]
        public ActionResult Edit(UserInfo userInfo)
        {
            if( ModelState.IsValid)
            {
                repository.SaveUserInfo(userInfo);
                TempData["message"] = userInfo.RealName;
                return RedirectToAction("Index");
            }
            else
            {
                return View(userInfo);
            }
        }

        //添加用户
        public ViewResult Create()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.RegistDate = DateTime.Now;
            //添加默认密码（注意，后期需要加上MD5加密
            userInfo.Password = "123456";
            return View("Edit", userInfo);
        }

        //删除用户
        public ActionResult Delete(int userID)
        {
            UserInfo deletedUserInfo = repository.DeleteUserInfo(userID);
            if( deletedUserInfo != null)
            {
                //弹出删除成功提示
            }
            return RedirectToAction("Index");
        }

        //模型验证，用户名是否已经存在 
        public JsonResult GetUserName(string userName, int userID)
        {
            //如果 userID 不为0，表示是在edit用户，此时不用验证用户名
            if ( userID !=0 )
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                UserInfo userInfo = repository.UserInfos.FirstOrDefault(p => (p.UserName == userName));
                if (userInfo == null)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("daijiujiu", JsonRequestBehavior.AllowGet);
                }
            }
        }  


}
}