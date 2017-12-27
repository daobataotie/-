using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common
{
    public class Common
    {
        public static void SerializeToXml(string filePath, object ob, string root = null)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                Type type = ob.GetType();
                XmlSerializer xmlSerializer = string.IsNullOrEmpty(root) ? new XmlSerializer(type) : new XmlSerializer(type, new XmlRootAttribute(root));
                xmlSerializer.Serialize(writer, ob);
            }
        }

        public static T DeserializeToClass<T>(string filePath) where T : new()
        {
            object result = new T();
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    result = xmlSerializer.Deserialize(reader);
                }
            }

            return (T)result;
        }

        public static T ss<T>(Stream stream) where T : new()
        {
            object result = new T();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            result = xmlSerializer.Deserialize(stream);
            return (T)result;
        }

        public static void SendMail(MailHelper mh)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = mh.SmtpService;
            //smtpClient.Port = "";//qq邮箱可以不用端口
            //构建发件地址和收件地址
            MailAddress sendAddress = new MailAddress(mh.SendEmail);
            MailAddress receiverAddress = new MailAddress(mh.ReceivingMail);

            //构造一个Email的Message对象 内容信息
            MailMessage message = new MailMessage(sendAddress, receiverAddress);
            message.Subject = mh.Subject + " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            message.SubjectEncoding = Encoding.UTF8;
            message.Body = mh.Body;
            message.BodyEncoding = Encoding.UTF8;
            //设置邮件的信息 如登陆密码 账号
            //邮件发送方式  通过网络发送到smtp服务器
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //如果服务器支持安全连接，则将安全连接设为true
            smtpClient.EnableSsl = true;

            //添加附件
            //foreach (string item in Directory.GetFiles(@"C:\Users\Administrator\Desktop\1"))
            //{
            //    message.Attachments.Add(new Attachment(item));
            //}

            try
            {
                smtpClient.UseDefaultCredentials = false;
                //发件用户登陆信息
                NetworkCredential senderCredential = new NetworkCredential(mh.SendEmail, mh.Sendpwd);
                smtpClient.Credentials = senderCredential;
                //发送邮件
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public enum AnswerType
    {
        文本,
        判斷,
        單選,
        多選
    }

    public class MailHelper
    {
        public string SmtpService { get; set; } = "smtp.qq.com";

        public string ReceivingMail { get; set; }

        public string SendEmail { get; set; } = "844309084@qq.com";

        public string Sendpwd { get; set; } = "ivppxmijsapubfge";

        public string Subject { get; set; } = "問卷調查";

        public string Body { get; set; }
    }
}
