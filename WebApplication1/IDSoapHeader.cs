using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class IDSoapHeader : System.Web.Services.Protocols.SoapHeader
    {
        private string userName = string.Empty;
        private string passWord = string.Empty;
        /// <summary> 
        /// 构造函数 
        /// </summary> 
        public IDSoapHeader()
        {
        }
        /// <summary> 
        /// 构造函数 
        /// </summary> 
        /// <param name="userName">用户名</param> 
        /// <param name="passWord">密码</param> 
        public IDSoapHeader(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }
        /// <summary> 
        /// 获取或设置用户用户名 
        /// </summary> 
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        /// <summary> 
        /// 获取或设置用户密码 
        /// </summary> 
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }
        public bool IsValid(string strUserName, string strPassword)
        {
            if (strUserName == "wangchao" && strPassword == "wangchao")
                return true;
            else
                return false;
        }
    }
}