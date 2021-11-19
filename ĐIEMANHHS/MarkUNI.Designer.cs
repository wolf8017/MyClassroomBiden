
namespace ĐIEMANHHS
{
    partial class MarkUNI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarkUNI));
            this.datamark = new System.Windows.Forms.DataGridView();
            this.cbclass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnout = new Bunifu.Framework.UI.BunifuFlatButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnoutput = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.datamark)).BeginInit();
            this.SuspendLayout();
            // 
            // datamark
            // 
            this.datamark.AllowUserToAddRows = false;
            this.datamark.AllowUserToResizeColumns = false;
            this.datamark.AllowUserToResizeRows = false;
            this.datamark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datamark.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datamark.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.datamark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datamark.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.datamark.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(110)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(110)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datamark.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datamark.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(77)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datamark.DefaultCellStyle = dataGridViewCellStyle2;
            this.datamark.EnableHeadersVisualStyles = false;
            this.datamark.Location = new System.Drawing.Point(13, 13);
            this.datamark.Margin = new System.Windows.Forms.Padding(4);
            this.datamark.Name = "datamark";
            this.datamark.ReadOnly = true;
            this.datamark.RowHeadersVisible = false;
            this.datamark.RowTemplate.Height = 30;
            this.datamark.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datamark.Size = new System.Drawing.Size(790, 471);
            this.datamark.TabIndex = 15;
            // 
            // cbclass
            // 
            this.cbclass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbclass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbclass.FormattingEnabled = true;
            this.cbclass.Location = new System.Drawing.Point(83, 497);
            this.cbclass.Name = "cbclass";
            this.cbclass.Size = new System.Drawing.Size(121, 21);
            this.cbclass.TabIndex = 16;
            this.cbclass.SelectedIndexChanged += new System.EventHandler(this.cbclass_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 500);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tìm theo:";
            // 
            // btnout
            // 
            this.btnout.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnout.BorderRadius = 0;
            this.btnout.ButtonText = "Xuất ra file Excel";
            this.btnout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnout.DisabledColor = System.Drawing.Color.Gray;
            this.btnout.Iconcolor = System.Drawing.Color.Transparent;
            this.btnout.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnout.Iconimage")));
            this.btnout.Iconimage_right = null;
            this.btnout.Iconimage_right_Selected = null;
            this.btnout.Iconimage_Selected = null;
            this.btnout.IconMarginLeft = 0;
            this.btnout.IconMarginRight = 0;
            this.btnout.IconRightVisible = true;
            this.btnout.IconRightZoom = 0D;
            this.btnout.IconVisible = true;
            this.btnout.IconZoom = 50D;
            this.btnout.IsTab = false;
            this.btnout.Location = new System.Drawing.Point(228, 491);
            this.btnout.Name = "btnout";
            this.btnout.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnout.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnout.OnHoverTextColor = System.Drawing.Color.White;
            this.btnout.selected = false;
            this.btnout.Size = new System.Drawing.Size(144, 33);
            this.btnout.TabIndex = 18;
            this.btnout.Text = "Xuất ra file Excel";
            this.btnout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnout.Textcolor = System.Drawing.Color.White;
            this.btnout.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnout.Click += new System.EventHandler(this.btnout_Click);
            // 
            // btnoutput
            // 
            this.btnoutput.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnoutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnoutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnoutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnoutput.BorderRadius = 0;
            this.btnoutput.ButtonText = "Xuất ra file PDF";
            this.btnoutput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnoutput.DisabledColor = System.Drawing.Color.Gray;
            this.btnoutput.Iconcolor = System.Drawing.Color.Transparent;
            this.btnoutput.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnoutput.Iconimage")));
            this.btnoutput.Iconimage_right = null;
            this.btnoutput.Iconimage_right_Selected = null;
            this.btnoutput.Iconimage_Selected = null;
            this.btnoutput.IconMarginLeft = 0;
            this.btnoutput.IconMarginRight = 0;
            this.btnoutput.IconRightVisible = true;
            this.btnoutput.IconRightZoom = 0D;
            this.btnoutput.IconVisible = true;
            this.btnoutput.IconZoom = 45D;
            this.btnoutput.IsTab = false;
            this.btnoutput.Location = new System.Drawing.Point(400, 491);
            this.btnoutput.Name = "btnoutput";
            this.btnoutput.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnoutput.OnHovercolor = System.Drawing.Color.Black;
            this.btnoutput.OnHoverTextColor = System.Drawing.Color.White;
            this.btnoutput.selected = false;
            this.btnoutput.Size = new System.Drawing.Size(139, 33);
            this.btnoutput.TabIndex = 18;
            this.btnoutput.Text = "Xuất ra file PDF";
            this.btnoutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnoutput.Textcolor = System.Drawing.Color.White;
            this.btnoutput.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnoutput.Click += new System.EventHandler(this.btnoutput_Click);
            // 
            // MarkUNI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(816, 533);
            this.Controls.Add(this.btnoutput);
            this.Controls.Add(this.btnout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbclass);
            this.Controls.Add(this.datamark);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MarkUNI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MarkUNI";
            this.Load += new System.EventHandler(this.MarkUNI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datamark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datamark;
        private System.Windows.Forms.ComboBox cbclass;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton btnout;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Bunifu.Framework.UI.BunifuFlatButton btnoutput;
    }
}