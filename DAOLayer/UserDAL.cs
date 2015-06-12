using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAOLayer
{
    public class UserDAL
    {
        private Data.LOLDataDataContext ldc = new Data.LOLDataDataContext("Data Source=HP-HP\\SQLEXPRESS;Initial Catalog=MyFirst;Integrated Security=True");
        private Data.CHECKDataDataContext cdc = new Data.CHECKDataDataContext("Data Source=HP-HP\\SQLEXPRESS;Initial Catalog=MyFirst;Integrated Security=True");
        public Data.LOLAccount SelectRecordByUsername(string username)
        {
            try
            {
                return (from l in ldc.LOLAccount where l.username == username select l).Single();
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }
        public bool InsertToCheckDB(String checkCode,String userName) {
            //插入数据库，更新状态为1：可用
            Data.checkDB checkdata = new Data.checkDB();
            checkdata.checkcode = checkCode;
            checkdata.state = 1;
            checkdata.username = userName;
            
            cdc.checkDB.InsertOnSubmit(checkdata);

            try
            {
                cdc.SubmitChanges();
            }
            catch (Exception ee)
            {
                Console.Write(ee);
                return false;
            }
            return true;
        }
        public bool updateCheckDB(Data.checkDB checkCodeRecord)
        {
            //更新数据库
            Data.checkDB temp = cdc.checkDB.Single(c=>c.checkcode == checkCodeRecord.checkcode);
            temp = checkCodeRecord;
            cdc.SubmitChanges();
            return true;
        }
        public Data.checkDB SelectByCheckcode(String checkCode) {
            //根据提取码获取记录
            try
            {
                return (from c in cdc.checkDB where c.checkcode == checkCode select c).Single();
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }
    }
}
