
namespace ĐIEMANHHS
{
    partial class UpdateTeacher
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
            this.rdNo = new System.Windows.Forms.RadioButton();
            this.rdYes = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnupdate = new System.Windows.Forms.Button();
            this.cbadmin = new System.Windows.Forms.ComboBox();
            this.txtrole = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rdNo
            // 
            this.rdNo.AutoSize = true;
            this.rdNo.Location = new System.Drawing.Point(378, 170);
            this.rdNo.Name = "rdNo";
            this.rdNo.Size = new System.Drawing.Size(56, 17);
            this.rdNo.TabIndex = 16;
            this.rdNo.Text = "Không";
            this.rdNo.UseVisualStyleBackColor = true;
            // 
            // rdYes
            // 
            this.rdYes.AutoSize = true;
            this.rdYes.Checked = true;
            this.rdYes.Location = new System.Drawing.Point(260, 170);
            this.rdYes.Name = "rdYes";
            this.rdYes.Size = new System.Drawing.Size(44, 17);
            this.rdYes.TabIndex = 15;
            this.rdYes.TabStop = true;
            this.rdYes.Text = "Còn";
            this.rdYes.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(112, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Công tác tại trường:";
            // 
            // btnupdate
            // 
            this.btnupdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnupdate.FlatAppearance.BorderSize = 0;
            this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.Image = global::ĐIEMANHHS.Properties.Resources.fix_it_icon;
            this.btnupdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnupdate.Location = new System.Drawing.Point(251, 230);
            this.btnupdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(94, 36);
            this.btnupdate.TabIndex = 17;
            this.btnupdate.Text = "Update";
            this.btnupdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // cbadmin
            // 
            this.cbadmin.FormattingEnabled = true;
            this.cbadmin.Items.AddRange(new object[] {
            "Không",
            "Admin"});
            this.cbadmin.Location = new System.Drawing.Point(261, 80);
            this.cbadmin.Name = "cbadmin";
            this.cbadmin.Size = new System.Drawing.Size(236, 21);
            this.cbadmin.TabIndex = 21;
            // 
            // txtrole
            // 
            this.txtrole.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtrole.Location = new System.Drawing.Point(261, 122);
            this.txtrole.Margin = new System.Windows.Forms.Padding(4);
            this.txtrole.Name = "txtrole";
            this.txtrole.Size = new System.Drawing.Size(236, 20);
            this.txtrole.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(115, 125);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "Vai trò:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(115, 81);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Admin";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(201, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "CẬP NHẬT THÔNG TIN GIÁO VIÊN";
            // 
            // UpdateTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(602, 295);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.cbadmin);
            this.Controls.Add(this.txtrole);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rdNo);
            this.Controls.Add(this.rdYes);
            this.Controls.Add(this.label4);
            this.Name = "UpdateTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateTeacher";
            this.Load += new System.EventHandler(this.UpdateTeacher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdNo;
        private System.Windows.Forms.RadioButton rdYes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.ComboBox cbadmin;
        private System.Windows.Forms.TextBox txtrole;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
    }
}