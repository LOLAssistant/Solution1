using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class UserBLL
    {
        private DAOLayer.UserDAL objUserDAL= new DAOLayer.UserDAL();
        public Data.LOLAccount SelectRecordByUsername(string username)
        {
            return objUserDAL.SelectRecordByUsername(username);
        }

        public bool checkExtractingCode(String checkCode) {
            Data.checkDB checkCodeRecord = objUserDAL.SelectByCheckcode(checkCode);
            if (checkCodeRecord == null) {
                
                return false;
            }
            else if (checkCodeRecord.state != 1)
            {
                
                return false;
            }
            else
            {
                checkCodeRecord.state = 0;
                if (objUserDAL.updateCheckDB(checkCodeRecord))
                {
                    return true;
                }
                else
                {
                    
                    return false;
                }
            }
        }

        public bool AddExtractingCode(String checkCode,String userName) {

            Data.checkDB checkCodeRecord = objUserDAL.SelectByCheckcode(checkCode);
            if (checkCodeRecord != null)
            {
                return false;
            }
            else
            {

                if (objUserDAL.InsertToCheckDB(checkCode, userName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
