using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 問卷調查
{
    public partial class EditForm_AddQuestion : Form
    {
        int initialHeight;
        public Common.Question Question { get; set; }

        public EditForm_AddQuestion()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            initialHeight = Height;

            foreach (var item in Enum.GetNames(typeof(Common.AnswerType)))
            {
                cob_Type.Items.Add(item);
            }
        }

        public EditForm_AddQuestion(Common.Question question) : this()
        {
            Question = question;
            this.txt_Id.Text = question.Id;
            this.txt_Question.Text = question.SpecificQuestion;

            foreach (var item in question.Answers)
            {
                dataGridView1.Rows.Add(item);
            }
            this.cob_Type.SelectedIndex = (int)question.Type;
        }

        private void cob_Type_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cob_Type.SelectedItem.ToString() == Common.AnswerType.單選.ToString() || cob_Type.SelectedItem.ToString() == Common.AnswerType.多選.ToString() || cob_Type.SelectedItem.ToString() == Common.AnswerType.判斷.ToString())
            {
                dataGridView1.Visible = true;
                this.dataGridView1.AllowUserToAddRows = true;
                Height = initialHeight + this.dataGridView1.Height + 10;

                if (cob_Type.SelectedItem.ToString() == Common.AnswerType.判斷.ToString())
                {
                    this.dataGridView1.AllowUserToAddRows = false;
                    if (this.dataGridView1.Rows.Count == 0)
                    {
                        this.dataGridView1.Rows.Add();
                    }
                    else if (this.dataGridView1.Rows.Count > 1)
                    {
                        int lenght = this.dataGridView1.Rows.Count;
                        for (int i = lenght - 1; i > 0; i--)
                        {
                            this.dataGridView1.Rows.RemoveAt(i);
                        }
                    }
                }
            }
            else
            {
                dataGridView1.Visible = false;

                Height = initialHeight;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Id.Text))
            {
                MessageBox.Show("編號不能為空", "提示", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(txt_Question.Text))
            {
                MessageBox.Show("問題不能為空", "提示", MessageBoxButtons.OK);
                return;
            }
            if (cob_Type.SelectedIndex < 0)
            {
                MessageBox.Show("答案類型不能為空", "提示", MessageBoxButtons.OK);
                return;
            }

            if (Question == null)
                Question = new Common.Question();
            Question.Id = this.txt_Id.Text;
            Question.SpecificQuestion = this.txt_Question.Text;
            Question.Type = (Common.AnswerType)cob_Type.SelectedIndex;
            Question.Answers = new List<string>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[0].Value != null && !string.IsNullOrEmpty(item.Cells[0].Value.ToString().Trim()))
                    Question.Answers.Add(item.Cells[0].Value.ToString());
            }

            this.DialogResult = DialogResult.OK;
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //this.dataGridView1.RefreshEdit();
            //this.dataGridView1.UpdateCellValue(e.ColumnIndex, e.RowIndex);
            //string str = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
