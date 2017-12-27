namespace 問卷調查
{
    partial class EditForm_ReceivingMail
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
            this.txt_ReceivingMail = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_TestMail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "郵箱地址：";
            // 
            // txt_ReceivingMail
            // 
            this.txt_ReceivingMail.Location = new System.Drawing.Point(91, 15);
            this.txt_ReceivingMail.Name = "txt_ReceivingMail";
            this.txt_ReceivingMail.Size = new System.Drawing.Size(230, 23);
            this.txt_ReceivingMail.TabIndex = 1;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(187, 65);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(87, 27);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "確定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_TestMail
            // 
            this.btn_TestMail.Location = new System.Drawing.Point(62, 65);
            this.btn_TestMail.Name = "btn_TestMail";
            this.btn_TestMail.Size = new System.Drawing.Size(87, 27);
            this.btn_TestMail.TabIndex = 3;
            this.btn_TestMail.Text = "測試郵箱";
            this.btn_TestMail.UseVisualStyleBackColor = true;
            this.btn_TestMail.Click += new System.EventHandler(this.btn_TestMail_Click);
            // 
            // EditForm_ReceivingMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 106);
            this.Controls.Add(this.btn_TestMail);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.txt_ReceivingMail);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm_ReceivingMail";
            this.Text = "收件郵箱";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ReceivingMail;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_TestMail;
    }
}