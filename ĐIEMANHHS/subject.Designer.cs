
namespace ĐIEMANHHS
{
    partial class subject
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(subject));
            this.datasubject = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rjButton6 = new ĐIEMANHHS.RJButton();
            this.rjButton1 = new ĐIEMANHHS.RJButton();
            this.rjButton5 = new ĐIEMANHHS.RJButton();
            this.txtmamon = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtname = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnout_sj = new Bunifu.Framework.UI.BunifuFlatButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.datasubject)).BeginInit();
            this.SuspendLayout();
            // 
            // datasubject
            // 
            this.datasubject.AllowUserToAddRows = false;
            this.datasubject.AllowUserToResizeColumns = false;
            this.datasubject.AllowUserToResizeRows = false;
            this.datasubject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datasubject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datasubject.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.datasubject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datasubject.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.datasubject.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(41)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(41)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datasubject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.datasubject.ColumnHeadersHeight = 30;
            this.datasubject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(77)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datasubject.DefaultCellStyle = dataGridViewCellStyle4;
            this.datasubject.EnableHeadersVisualStyles = false;
            this.datasubject.Location = new System.Drawing.Point(366, 63);
            this.datasubject.Name = "datasubject";
            this.datasubject.ReadOnly = true;
            this.datasubject.RowHeadersVisible = false;
            this.datasubject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datasubject.Size = new System.Drawing.Size(431, 375);
            this.datasubject.TabIndex = 8;
            this.datasubject.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datasubject_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã Môn";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên Môn Học";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(103, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 19);
            this.label9.TabIndex = 1;
            this.label9.Text = "Thông Tin Môn Học";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(21, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên Môn Học:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(21, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Mã Môn:";
            // 
            // rjButton6
            // 
            this.rjButton6.BackColor = System.Drawing.Color.Crimson;
            this.rjButton6.BackgroundColor = System.Drawing.Color.Crimson;
            this.rjButton6.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton6.BorderRadius = 20;
            this.rjButton6.BorderSize = 0;
            this.rjButton6.FlatAppearance.BorderSize = 0;
            this.rjButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton6.ForeColor = System.Drawing.Color.White;
            this.rjButton6.Location = new System.Drawing.Point(177, 172);
            this.rjButton6.Name = "rjButton6";
            this.rjButton6.Size = new System.Drawing.Size(133, 41);
            this.rjButton6.TabIndex = 58;
            this.rjButton6.Text = "Xóa";
            this.rjButton6.TextColor = System.Drawing.Color.White;
            this.rjButton6.UseVisualStyleBackColor = false;
            this.rjButton6.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.rjButton1.BackgroundColor = System.Drawing.Color.MediumSpringGreen;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 20;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(24, 226);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(133, 41);
            this.rjButton1.TabIndex = 59;
            this.rjButton1.Text = "Sửa";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // rjButton5
            // 
            this.rjButton5.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.rjButton5.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.rjButton5.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton5.BorderRadius = 20;
            this.rjButton5.BorderSize = 0;
            this.rjButton5.FlatAppearance.BorderSize = 0;
            this.rjButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton5.ForeColor = System.Drawing.Color.White;
            this.rjButton5.Location = new System.Drawing.Point(24, 172);
            this.rjButton5.Name = "rjButton5";
            this.rjButton5.Size = new System.Drawing.Size(133, 41);
            this.rjButton5.TabIndex = 60;
            this.rjButton5.Text = "Thêm mới";
            this.rjButton5.TextColor = System.Drawing.Color.White;
            this.rjButton5.UseVisualStyleBackColor = false;
            this.rjButton5.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // txtmamon
            // 
            this.txtmamon.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtmamon.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtmamon.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtmamon.BorderThickness = 1;
            this.txtmamon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtmamon.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtmamon.ForeColor = System.Drawing.Color.White;
            this.txtmamon.isPassword = false;
            this.txtmamon.Location = new System.Drawing.Point(131, 72);
            this.txtmamon.Margin = new System.Windows.Forms.Padding(4);
            this.txtmamon.Name = "txtmamon";
            this.txtmamon.Size = new System.Drawing.Size(190, 26);
            this.txtmamon.TabIndex = 61;
            this.txtmamon.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtname
            // 
            this.txtname.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtname.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtname.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtname.BorderThickness = 1;
            this.txtname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtname.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtname.ForeColor = System.Drawing.Color.White;
            this.txtname.isPassword = false;
            this.txtname.Location = new System.Drawing.Point(131, 116);
            this.txtname.Margin = new System.Windows.Forms.Padding(4);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(190, 26);
            this.txtname.TabIndex = 61;
            this.txtname.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnout_sj
            // 
            this.btnout_sj.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnout_sj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnout_sj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnout_sj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnout_sj.BorderRadius = 0;
            this.btnout_sj.ButtonText = "Xuất ra file Excel";
            this.btnout_sj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnout_sj.DisabledColor = System.Drawing.Color.Gray;
            this.btnout_sj.Iconcolor = System.Drawing.Color.Transparent;
            this.btnout_sj.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnout_sj.Iconimage")));
            this.btnout_sj.Iconimage_right = null;
            this.btnout_sj.Iconimage_right_Selected = null;
            this.btnout_sj.Iconimage_Selected = null;
            this.btnout_sj.IconMarginLeft = 0;
            this.btnout_sj.IconMarginRight = 0;
            this.btnout_sj.IconRightVisible = true;
            this.btnout_sj.IconRightZoom = 0D;
            this.btnout_sj.IconVisible = true;
            this.btnout_sj.IconZoom = 50D;
            this.btnout_sj.IsTab = false;
            this.btnout_sj.Location = new System.Drawing.Point(95, 405);
            this.btnout_sj.Name = "btnout_sj";
            this.btnout_sj.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnout_sj.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnout_sj.OnHoverTextColor = System.Drawing.Color.White;
            this.btnout_sj.selected = false;
            this.btnout_sj.Size = new System.Drawing.Size(144, 33);
            this.btnout_sj.TabIndex = 64;
            this.btnout_sj.Text = "Xuất ra file Excel";
            this.btnout_sj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnout_sj.Textcolor = System.Drawing.Color.White;
            this.btnout_sj.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnout_sj.Click += new System.EventHandler(this.btnout_sj_Click);
            // 
            // subject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(77)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnout_sj);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtmamon);
            this.Controls.Add(this.rjButton6);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.rjButton5);
            this.Controls.Add(this.datasubject);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "subject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Môn Học";
            this.Load += new System.EventHandler(this.subject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datasubject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView datasubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private RJButton rjButton6;
        private RJButton rjButton1;
        private RJButton rjButton5;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtmamon;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtname;
        private Bunifu.Framework.UI.BunifuFlatButton btnout_sj;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}