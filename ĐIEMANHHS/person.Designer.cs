
namespace ĐIEMANHHS
{
    partial class person
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(person));
            this.dataperson = new System.Windows.Forms.DataGridView();
            this.btnadd = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTH = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtBT = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtGK = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtmon = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnsua = new Bunifu.Framework.UI.BunifuThinButton2();
            ((System.ComponentModel.ISupportInitialize)(this.dataperson)).BeginInit();
            this.SuspendLayout();
            // 
            // dataperson
            // 
            this.dataperson.AllowUserToAddRows = false;
            this.dataperson.AllowUserToResizeColumns = false;
            this.dataperson.AllowUserToResizeRows = false;
            this.dataperson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataperson.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataperson.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.dataperson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataperson.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataperson.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(110)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(110)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataperson.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataperson.ColumnHeadersHeight = 30;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(66)))), ((int)(((byte)(84)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(127)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataperson.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataperson.EnableHeadersVisualStyles = false;
            this.dataperson.Location = new System.Drawing.Point(336, 13);
            this.dataperson.Margin = new System.Windows.Forms.Padding(4);
            this.dataperson.Name = "dataperson";
            this.dataperson.ReadOnly = true;
            this.dataperson.RowHeadersVisible = false;
            this.dataperson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataperson.Size = new System.Drawing.Size(718, 448);
            this.dataperson.TabIndex = 16;
            // 
            // btnadd
            // 
            this.btnadd.ActiveBorderThickness = 1;
            this.btnadd.ActiveCornerRadius = 20;
            this.btnadd.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            this.btnadd.ActiveForecolor = System.Drawing.Color.White;
            this.btnadd.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            this.btnadd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.btnadd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnadd.BackgroundImage")));
            this.btnadd.ButtonText = "Thêm mới";
            this.btnadd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadd.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnadd.IdleBorderThickness = 1;
            this.btnadd.IdleCornerRadius = 20;
            this.btnadd.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(60)))), ((int)(((byte)(97)))));
            this.btnadd.IdleForecolor = System.Drawing.Color.White;
            this.btnadd.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnadd.Location = new System.Drawing.Point(37, 226);
            this.btnadd.Margin = new System.Windows.Forms.Padding(5);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(107, 36);
            this.btnadd.TabIndex = 4;
            this.btnadd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Mã lớp theo môn:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(64, 11);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(209, 19);
            this.label9.TabIndex = 29;
            this.label9.Text = "Thông Tin Nhập % Điểm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "% Điểm thực hành:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(18, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "% Điểm bài tập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "% Điểm giữa";
            // 
            // txtTH
            // 
            this.txtTH.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtTH.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTH.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTH.BorderThickness = 1;
            this.txtTH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTH.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTH.ForeColor = System.Drawing.Color.White;
            this.txtTH.isPassword = false;
            this.txtTH.Location = new System.Drawing.Point(150, 86);
            this.txtTH.Margin = new System.Windows.Forms.Padding(4);
            this.txtTH.Name = "txtTH";
            this.txtTH.Size = new System.Drawing.Size(176, 26);
            this.txtTH.TabIndex = 1;
            this.txtTH.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtBT
            // 
            this.txtBT.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtBT.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBT.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBT.BorderThickness = 1;
            this.txtBT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBT.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBT.ForeColor = System.Drawing.Color.White;
            this.txtBT.isPassword = false;
            this.txtBT.Location = new System.Drawing.Point(150, 126);
            this.txtBT.Margin = new System.Windows.Forms.Padding(4);
            this.txtBT.Name = "txtBT";
            this.txtBT.Size = new System.Drawing.Size(176, 26);
            this.txtBT.TabIndex = 2;
            this.txtBT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtGK
            // 
            this.txtGK.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtGK.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtGK.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtGK.BorderThickness = 1;
            this.txtGK.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGK.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtGK.ForeColor = System.Drawing.Color.White;
            this.txtGK.isPassword = false;
            this.txtGK.Location = new System.Drawing.Point(150, 166);
            this.txtGK.Margin = new System.Windows.Forms.Padding(4);
            this.txtGK.Name = "txtGK";
            this.txtGK.Size = new System.Drawing.Size(176, 26);
            this.txtGK.TabIndex = 3;
            this.txtGK.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtmon
            // 
            this.txtmon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtmon.FormattingEnabled = true;
            this.txtmon.Location = new System.Drawing.Point(150, 51);
            this.txtmon.Name = "txtmon";
            this.txtmon.Size = new System.Drawing.Size(176, 21);
            this.txtmon.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(18, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(292, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Lưu ý: chỉ được tối đa 90% điểm vì 10% còn lại là điểm danh";
            // 
            // btnsua
            // 
            this.btnsua.ActiveBorderThickness = 1;
            this.btnsua.ActiveCornerRadius = 20;
            this.btnsua.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnsua.ActiveForecolor = System.Drawing.Color.White;
            this.btnsua.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnsua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.btnsua.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnsua.BackgroundImage")));
            this.btnsua.ButtonText = "Cập nhật";
            this.btnsua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsua.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnsua.IdleBorderThickness = 1;
            this.btnsua.IdleCornerRadius = 20;
            this.btnsua.IdleFillColor = System.Drawing.Color.Sienna;
            this.btnsua.IdleForecolor = System.Drawing.Color.White;
            this.btnsua.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnsua.Location = new System.Drawing.Point(183, 226);
            this.btnsua.Margin = new System.Windows.Forms.Padding(5);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(107, 36);
            this.btnsua.TabIndex = 61;
            this.btnsua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // person
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1058, 467);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtmon);
            this.Controls.Add(this.txtGK);
            this.Controls.Add(this.txtBT);
            this.Controls.Add(this.txtTH);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataperson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "person";
            this.Text = "MarkHS";
            this.Load += new System.EventHandler(this.person_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataperson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataperson;
        private Bunifu.Framework.UI.BunifuThinButton2 btnadd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtTH;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBT;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtGK;
        private System.Windows.Forms.ComboBox txtmon;
        private System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuThinButton2 btnsua;
    }
}