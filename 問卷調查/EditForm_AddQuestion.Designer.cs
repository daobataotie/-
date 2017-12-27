namespace 問卷調查
{
    partial class EditForm_AddQuestion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Id = new System.Windows.Forms.TextBox();
            this.txt_Question = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cob_Type = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "編號：";
            // 
            // txt_Id
            // 
            this.txt_Id.Location = new System.Drawing.Point(69, 43);
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.Size = new System.Drawing.Size(116, 23);
            this.txt_Id.TabIndex = 1;
            // 
            // txt_Question
            // 
            this.txt_Question.Location = new System.Drawing.Point(69, 72);
            this.txt_Question.Multiline = true;
            this.txt_Question.Name = "txt_Question";
            this.txt_Question.Size = new System.Drawing.Size(438, 40);
            this.txt_Question.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "問題：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "答案類型：";
            // 
            // cob_Type
            // 
            this.cob_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_Type.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cob_Type.FormattingEnabled = true;
            this.cob_Type.Location = new System.Drawing.Point(97, 118);
            this.cob_Type.Name = "cob_Type";
            this.cob_Type.Size = new System.Drawing.Size(88, 22);
            this.cob_Type.TabIndex = 5;
            this.cob_Type.SelectedValueChanged += new System.EventHandler(this.cob_Type_SelectedValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(526, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(49, 24);
            this.Save.Text = "保存";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(17, 154);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(193, 150);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "答案";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // EditForm_AddQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 153);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cob_Type);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Question);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm_AddQuestion";
            this.Text = "編輯問題";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Id;
        private System.Windows.Forms.TextBox txt_Question;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cob_Type;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}