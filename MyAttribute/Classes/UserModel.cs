using MyAttribute.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Classes
{
    [Table(_tableName: "User")]
    public class UserModel
    {
        [IntValidate(0,10000)]
        public int Id { get; set; }
        #region Model

        /// <summary>
        /// 
        /// </summary>
        public string Account
        {
            set;
            get;
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            set;
            get;
        }
        /// <summary>
        /// EMaill
        /// </summary>
        public string Email
        {
            set;
            get;
        }
        /// <summary>
        /// 手提
        /// </summary>
        public string Mobile
        {
            set;
            get;
        }
        /// <summary>
        /// 企业ID
        /// </summary>
        public int? CompanyId
        {
            set;
            get;
        }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string CompanyName
        {
            set;
            get;
        }
        /// <summary>
        /// 用户状态  0正常 1冻结 2删除
        /// </summary>
        public int? State
        {
            set;
            get;
        }
        /// <summary>
        /// 用户类型  1 普通用户 2管理员 4超级管理员
        /// </summary>
        public int? UserType
        {
            set;
            get;
        }
        /// <summary>
        /// 最后一次登陆时间
        /// </summary>
        public DateTime? LastLoginTime
        {
            set;
            get;
        }

        /// <summary>
        /// 最后一次修改人
        /// </summary>
        public int? LastModifierId
        {
            set;
            get;
        }
        /// <summary>
        /// 最后一次修改时间
        /// </summary>
        public DateTime? LastModifyTime
        {
            set;
            get;
        }
        #endregion Model
    }
}
