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

namespace 問卷調查
{
    public partial class EditForm_ReceivingMail : Form
    {
        QuestionList q = new QuestionList();
        public EditForm_ReceivingMail(QuestionList ql)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            q = ql;
            this.txt_ReceivingMail.Text = q.ReceivingMail;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_ReceivingMail.Text))
            {
                MessageBox.Show("郵箱地址不能為空！","提示",MessageBoxButtons.OK);
                return;
            }
            q.ReceivingMail = this.txt_ReceivingMail.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btn_TestMail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_ReceivingMail.Text))
            {
                MessageBox.Show("郵箱地址不能為空！", "提示", MessageBoxButtons.OK);
                return;
            }
            MailHelper mh = new MailHelper();
            mh.Subject = "測試";
            mh.Body = "測試郵箱是否可用！";
            mh.ReceivingMail = this.txt_ReceivingMail.Text;
            Common.Common.SendMail(mh);
        }
    }
}
