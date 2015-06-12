using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// CheckUserService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://localhost/CheckUserService.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class CheckUserService : System.Web.Services.WebService
    {
        private BusinessLayer.UserBLL objUserBLL = new BusinessLayer.UserBLL();

        public IDSoapHeader IDHeader;

        [System.Web.Services.Protocols.SoapHeader("IDHeader")]
        [WebMethod]
        public string HelloWorld()
        {
            if (IDHeader.IsValid(IDHeader.UserName, IDHeader.PassWord))
            {
                return "Hello World";
            }
            else
            {
                return "NO";
            }
        }


        [System.Web.Services.Protocols.SoapHeader("IDHeader")]
        [WebMethod]
        public bool matching(string username, string password)
        {
            if (IDHeader.IsValid(IDHeader.UserName,IDHeader.PassWord))
            {
                bool result = false;
                Data.LOLAccount lolAccount = objUserBLL.SelectRecordByUsername(username);
                if (lolAccount != null && lolAccount.password.Equals(password))
                {
                    result = true;
                }
                return result;
            }
            else 
            {
                Console.Write("验证失败！");
                return false;
            }
        }

        [System.Web.Services.Protocols.SoapHeader("IDHeader")]
        [WebMethod]
        public bool extractCode_record(String checkCode,String userName) 
        {
            if (IDHeader.IsValid(IDHeader.UserName, IDHeader.PassWord))
            {
                bool result = false;
                result = objUserBLL.AddExtractingCode(checkCode, userName);
                return result;
            }
            else
            {
                Console.Write("验证失败！");
                return false;
            }
        }

        [System.Web.Services.Protocols.SoapHeader("IDHeader")]
        [WebMethod]
        public bool check_extractCode(String checkCode)
        {
            if (IDHeader.IsValid(IDHeader.UserName, IDHeader.PassWord))
            {
                bool result = false;
                result = objUserBLL.checkExtractingCode(checkCode);
                return result;
            }
            else
            {
                Console.Write("验证失败！");
                return false;
            }
        }
   
    }
}
