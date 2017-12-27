using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Common;


namespace 問卷調查
{
    public partial class MaiForm : Form
    {
        QuestionList q = new QuestionList();

        public MaiForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            string fileName = AppDomain.CurrentDomain.BaseDirectory + "Questions.xml";
            if (File.Exists(fileName))
                q = Common.Common.DeserializeToClass<QuestionList>(fileName);

            this.bindingSource1.DataSource = q.Questions;

            this.dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ChangeGridRowColor();
        }

        private void ChangeGridRowColor()
        {
            foreach (DataGridViewRow item in this.dataGridView1.Rows)
            {
                if (this.dataGridView1.Rows.IndexOf(item) % 2 == 0)
                    item.DefaultCellStyle.ForeColor = Color.Red;
                else
                    item.DefaultCellStyle.ForeColor = Color.Blue;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            EditForm_AddQuestion form = new EditForm_AddQuestion();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.q.Questions.Add(form.Question);
                this.bindingSource1.DataSource = q.Questions.OrderBy(Q => Q.Id);
                ChangeGridRowColor();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定刪除？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Question question = this.bindingSource1.Current as Question;
                q.Questions.Remove(question);
                this.bindingSource1.DataSource = q.Questions.OrderBy(Q => Q.Id);

                ChangeGridRowColor();
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            Question question = this.bindingSource1.Current as Question;
            if (question != null)
            {
                EditForm_AddQuestion form = new EditForm_AddQuestion(question);
                form.ShowDialog(this);

                //question = form.Question;
                this.bindingSource1.DataSource = q.Questions.OrderBy(Q => Q.Id);
                ChangeGridRowColor();
            }
        }

        private void ReceivingMail_Click(object sender, EventArgs e)
        {
            EditForm_ReceivingMail form = new EditForm_ReceivingMail(q);
            form.ShowDialog(this);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (q.Questions == null || q.Questions.Count == 0)
                {
                    MessageBox.Show("問題為空，請添加后再保存！", "提示", MessageBoxButtons.OK);
                    return;
                }

                string fileName = AppDomain.CurrentDomain.BaseDirectory + "Questions.xml";


                Common.Common.SerializeToXml(fileName, q);

                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
    }
}
