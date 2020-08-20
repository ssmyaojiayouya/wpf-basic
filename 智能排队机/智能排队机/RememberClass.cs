using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static 智能排队机.Users;

namespace 智能排队机
{
    public class RememberClass
    {
   //获得data.bin的路径。
   // string filePath = System.Windows.Forms.Application.StartupPath + "\\" + "data.bin"; 

    //声明一个Dictionary的集合。
    private static Dictionary<string, User> dicUserInfo = new Dictionary<string, User>();

    /// <summary>
    /// 构造方法，读取文件流。
    /// </summary>
    public RememberClass()
    {
       //实例化一个流：FileStream。
       using (FileStream fs =  new FileStream("userdata.bin", FileMode.OpenOrCreate))
       {
          //如果有数据。
          if (fs.Length > 0)
          {
            //BinaryFormatter：以二进制格式序列化和反序列化对象或连接对象的整个图形。
            //实例化序列化对象。
             BinaryFormatter bf = new BinaryFormatter();
            //将反序化后的内容转换为dicUserInfo集合。
             dicUserInfo = bf.Deserialize(fs) as Dictionary<string, User>;
           }
        }
     }
 

 
     /// <summary>
     /// 此方法用于保存用户名和密码。
     /// </summary>
     public void AddRemember(User _userInfo)
     {
         //实例化一个流：FileStream。
         using (FileStream fs = new FileStream("userdata.bin", FileMode.OpenOrCreate))
         {
             //实例化序列化对象。
             BinaryFormatter bf = new BinaryFormatter();
             //如果已存在此用户，那么就移除掉。
             if (dicUserInfo.ContainsKey(_userInfo.Username))
             {
               dicUserInfo.Remove(_userInfo.Username);
             }
             //再添加该用户，防止用户更新密码。
             dicUserInfo.Add(_userInfo.Username, _userInfo);
             //序列化。
             bf.Serialize(fs, dicUserInfo);
             fs.Close();
             MessageBox.Show("添加成功。");                    
          }
      }

    }
}
