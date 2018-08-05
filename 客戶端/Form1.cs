using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using System.Reflection;
using System.IO;
using System.Resources;

namespace 客戶端
{
    public partial class Form1 : Form
    {
        QuestionList q = new QuestionList();
        int locationX = 10;
        int locationY = 10;
        int answerX = 35;
        int spacing = 10;

        List<TextBox> txtList = new List<TextBox>();
        List<CheckBox> chbList = new List<CheckBox>();
        List<RadioButton> rdbList = new List<RadioButton>();

        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.panel1.AutoScroll = true;

            //using (ResourceWriter rw = new ResourceWriter(@".\Resources\Resource.resources"))
            //{
            //    FileStream fs = File.OpenRead(@"C:\Users\Administrator\Desktop\問卷調查\客戶端\bin\Debug\Resources\Questions.xml");
            //    rw.AddResource("11", fs);

            //    rw.Generate();
            //    rw.Close();
            //}
            //var vv=Properties.Resources.ResourceManager.GetObject("Questions");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string fileName = @".\Resources\Questions.xml";
            //q = Common.Common.DeserializeToClass<QuestionList>(fileName);

            //Type type = MethodBase.GetCurrentMethod().DeclaringType;
            //Assembly _assembly = Assembly.GetExecutingAssembly();
            //Stream stream = _assembly.GetManifestResourceStream(type.Namespace + ".Questions.xml");
            //q = Common.Common.ss<QuestionList>(stream);

            string fileName = AppDomain.CurrentDomain.BaseDirectory + "Questions.xml";
            q = Common.Common.DeserializeToClass<QuestionList>(fileName);
            
            if (q == null || q.Questions == null || q.Questions.Count == 0)
                return;

            q.Questions = q.Questions.OrderBy(Q => Q.Id).ToList();

            foreach (var item in q.Questions)
            {
                //Create label for show questions
                Label label = new Label();
                label.Parent = panel1;
                label.Name = "label" + q.Questions.IndexOf(item).ToString();
                label.AutoSize = true;
                label.Width = this.panel1.Width - 20;
                label.Text = item.Id + ". " + item.SpecificQuestion;
                label.Location = new Point(locationX, locationY);

                locationY += label.Height + spacing;

                //Create control for show answer
                switch (item.Type.ToString())
                {
                    case "文本":
                        TextBox tb = new TextBox();
                        tb.Parent = panel1;
                        tb.Name = "tb" + q.Questions.IndexOf(item).ToString();
                        tb.Multiline = true;
                        tb.ScrollBars = ScrollBars.Both;
                        tb.Width = this.panel1.Width - 60;
                        tb.Height = 50;
                        tb.Location = new Point(answerX, locationY);

                        locationY += tb.Height + spacing;
                        txtList.Add(tb);
                        break;
                    case "判斷":
                        CheckBox chb = new CheckBox();
                        chb.Parent = panel1;
                        chb.Name = "chb" + q.Questions.IndexOf(item).ToString();
                        chb.AutoSize = true;
                        chb.Text = item.Answers[0];
                        chb.Location = new Point(answerX, locationY);

                        locationY += chb.Height + spacing;
                        chbList.Add(chb);
                        break;
                    case "單選":
                        Panel p = new Panel();
                        p.Parent = panel1;
                        p.Name = "p" + q.Questions.IndexOf(item).ToString();
                        p.Width = panel1.Width - 20;

                        int tempY = 0;
                        foreach (var answer in item.Answers)
                        {
                            RadioButton rdb = new RadioButton();
                            rdb.Parent = p;
                            rdb.Name = "rdb" + q.Questions.IndexOf(item).ToString() + "_" + item.Answers.IndexOf(answer).ToString();
                            rdb.AutoSize = true;
                            rdb.Text = answer;
                            rdb.Location = new Point(answerX, tempY);

                            tempY += rdb.Height + spacing;
                            rdbList.Add(rdb);
                        }
                        p.Height = tempY;
                        p.Location = new Point(0, locationY);

                        locationY += p.Height;
                        break;
                    case "多選":
                        foreach (var answer in item.Answers)
                        {
                            CheckBox cb = new CheckBox();
                            cb.Parent = panel1;
                            cb.Name = "cb" + q.Questions.IndexOf(item).ToString() + "_" + item.Answers.IndexOf(answer).ToString();
                            cb.AutoSize = true;
                            cb.Text = answer;
                            cb.Location = new Point(answerX, locationY);

                            locationY += cb.Height + spacing;
                            chbList.Add(cb);
                        }

                        break;
                }
            }

            Button btn = new Button();
            btn.Parent = panel1;
            btn.Name = "btnSubmit";
            btn.Height = 30;
            btn.ForeColor = Color.Green;
            btn.Text = "提交";
            btn.Location = new Point(50, locationY + spacing);

            locationY += btn.Height + spacing;
            btn.Click += Btn_Click;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            foreach (var item in q.Questions)
            {
                item.SubmitAnswer = string.Empty;
                switch (item.Type.ToString())
                {
                    case "文本":
                        if (txtList.Any(T => T.Name == "tb" + q.Questions.IndexOf(item).ToString()))
                            item.SubmitAnswer = "    " + txtList.First(T => T.Name == "tb" + q.Questions.IndexOf(item).ToString()).Text;
                        break;
                    case "判斷":
                        var chb = chbList.FirstOrDefault(C => C.Name == "chb" + q.Questions.IndexOf(item).ToString());
                        if (chb != null && chb.Checked)
                            item.SubmitAnswer = "    " + chb.Text;
                        else
                            item.SubmitAnswer = "    " + "×";
                        break;
                    case "單選":
                        foreach (var answer in item.Answers)
                        {
                            var rdb = rdbList.FirstOrDefault(R => R.Name == "rdb" + q.Questions.IndexOf(item).ToString() + "_" + item.Answers.IndexOf(answer).ToString());
                            if (rdb != null && rdb.Checked)
                            {
                                item.SubmitAnswer = "    " + rdb.Text;
                                break;
                            }
                        }
                        break;
                    case "多選":
                        foreach (var answer in item.Answers)
                        {
                            var cb = chbList.FirstOrDefault(C => C.Name == "cb" + q.Questions.IndexOf(item).ToString() + "_" + item.Answers.IndexOf(answer).ToString());
                            if (cb != null && cb.Checked)
                                item.SubmitAnswer += "    " + cb.Text + "\r\n";
                        }
                        if (!string.IsNullOrEmpty(item.SubmitAnswer))
                            item.SubmitAnswer = item.SubmitAnswer.Contains("\r\n") ? item.SubmitAnswer.Substring(0, item.SubmitAnswer.LastIndexOf("\r\n")) : item.SubmitAnswer;
                        break;
                }

                if (string.IsNullOrEmpty(item.SubmitAnswer.Trim()))
                {
                    MessageBox.Show($"問題“{item.Id}”還未作答，不能提交！", "提示", MessageBoxButtons.OK);
                    return;
                }
            }

            SendMail();
            MessageBox.Show("提交成功！", "提示", MessageBoxButtons.OK);
            this.Close();
            Application.Exit();
        }

        private void SendMail()
        {
            string result = string.Empty;
            foreach (var item in q.Questions)
                result += item.Id + ". " + item.SpecificQuestion + "\r\n" + item.SubmitAnswer + "\r\n";

            MailHelper mh = new MailHelper();
            mh.ReceivingMail = q.ReceivingMail;
            mh.Body = result;
            Common.Common.SendMail(mh);
        }
    }
}
