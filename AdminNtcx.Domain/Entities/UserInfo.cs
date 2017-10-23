using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AdminNtcx.Domain.Entities
{
    //默认生产的数据表名为类名+s
    public class UserInfo
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }
        [Required(ErrorMessage ="请输入用户名")]
        [Remote("GetUserName", "User", "Admin",AdditionalFields ="UserID",ErrorMessage = "该用户名已存在！")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "请输入姓名")]
        public string RealName { get; set; }
        public string Password { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime RegistDate { get; set; }
    }
}
