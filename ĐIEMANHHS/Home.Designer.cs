
namespace ĐIEMANHHS
{
    partial class Home
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
            this.components = new System.ComponentModel.Container();
            AnimatorNS.Animation animation8 = new AnimatorNS.Animation();
            AnimatorNS.Animation animation7 = new AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.sidebar = new System.Windows.Forms.Panel();
            this.lbrole = new System.Windows.Forms.Label();
            this.lbuser = new System.Windows.Forms.Label();
            this.logo = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnadmin = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnprofile = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnpercent = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btntotal = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnmark = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnroll = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnhome = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnmenu = new FontAwesome.Sharp.IconButton();
            this.header = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.LogoAni = new AnimatorNS.Animator(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.piclogo = new System.Windows.Forms.PictureBox();
            this.PanelAni = new AnimatorNS.Animator(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.header.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.sidebar.Controls.Add(this.lbrole);
            this.sidebar.Controls.Add(this.lbuser);
            this.sidebar.Controls.Add(this.logo);
            this.sidebar.Controls.Add(this.btnadmin);
            this.sidebar.Controls.Add(this.btnprofile);
            this.sidebar.Controls.Add(this.btnpercent);
            this.sidebar.Controls.Add(this.btntotal);
            this.sidebar.Controls.Add(this.btnmark);
            this.sidebar.Controls.Add(this.btnroll);
            this.sidebar.Controls.Add(this.btnhome);
            this.sidebar.Controls.Add(this.btnmenu);
            this.PanelAni.SetDecoration(this.sidebar, AnimatorNS.DecorationType.None);
            this.LogoAni.SetDecoration(this.sidebar, AnimatorNS.DecorationType.None);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 31);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(193, 609);
            this.sidebar.TabIndex = 0;
            // 
            // lbrole
            // 
            this.lbrole.AutoSize = true;
            this.LogoAni.SetDecoration(this.lbrole, AnimatorNS.DecorationType.None);
            this.PanelAni.SetDecoration(this.lbrole, AnimatorNS.DecorationType.None);
            this.lbrole.ForeColor = System.Drawing.Color.White;
            this.lbrole.Location = new System.Drawing.Point(59, 36);
            this.lbrole.Name = "lbrole";
            this.lbrole.Size = new System.Drawing.Size(32, 13);
            this.lbrole.TabIndex = 4;
            this.lbrole.Text = "Role:";
            // 
            // lbuser
            // 
            this.lbuser.AutoSize = true;
            this.LogoAni.SetDecoration(this.lbuser, AnimatorNS.DecorationType.None);
            this.PanelAni.SetDecoration(this.lbuser, AnimatorNS.DecorationType.None);
            this.lbuser.ForeColor = System.Drawing.Color.White;
            this.lbuser.Location = new System.Drawing.Point(59, 15);
            this.lbuser.Name = "lbuser";
            this.lbuser.Size = new System.Drawing.Size(32, 13);
            this.lbuser.TabIndex = 4;
            this.lbuser.Text = "User:";
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.Transparent;
            this.PanelAni.SetDecoration(this.logo, AnimatorNS.DecorationType.None);
            this.LogoAni.SetDecoration(this.logo, AnimatorNS.DecorationType.None);
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.ImageActive = null;
            this.logo.Location = new System.Drawing.Point(5, 9);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(51, 46);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 3;
            this.logo.TabStop = false;
            this.logo.Zoom = 10;
            // 
            // btnadmin
            // 
            this.btnadmin.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnadmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnadmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnadmin.BorderRadius = 0;
            this.btnadmin.ButtonText = "     Trang Quản Trị";
            this.btnadmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoAni.SetDecoration(this.btnadmin, AnimatorNS.DecorationType.None);
            this.PanelAni.SetDecoration(this.btnadmin, AnimatorNS.DecorationType.None);
            this.btnadmin.DisabledColor = System.Drawing.Color.Gray;
            this.btnadmin.Iconcolor = System.Drawing.Color.Transparent;
            this.btnadmin.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnadmin.Iconimage")));
            this.btnadmin.Iconimage_right = null;
            this.btnadmin.Iconimage_right_Selected = null;
            this.btnadmin.Iconimage_Selected = null;
            this.btnadmin.IconMarginLeft = 0;
            this.btnadmin.IconMarginRight = 0;
            this.btnadmin.IconRightVisible = true;
            this.btnadmin.IconRightZoom = 0D;
            this.btnadmin.IconVisible = true;
            this.btnadmin.IconZoom = 45D;
            this.btnadmin.IsTab = true;
            this.btnadmin.Location = new System.Drawing.Point(2, 518);
            this.btnadmin.Name = "btnadmin";
            this.btnadmin.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnadmin.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnadmin.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnadmin.selected = false;
            this.btnadmin.Size = new System.Drawing.Size(189, 41);
            this.btnadmin.TabIndex = 2;
            this.btnadmin.Text = "     Trang Quản Trị";
            this.btnadmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnadmin.Textcolor = System.Drawing.Color.White;
            this.btnadmin.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadmin.Click += new System.EventHandler(this.btnadmin_Click);
            // 
            // btnprofile
            // 
            this.btnprofile.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnprofile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnprofile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnprofile.BorderRadius = 0;
            this.btnprofile.ButtonText = "     Thông Tin";
            this.btnprofile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoAni.SetDecoration(this.btnprofile, AnimatorNS.DecorationType.None);
            this.PanelAni.SetDecoration(this.btnprofile, AnimatorNS.DecorationType.None);
            this.btnprofile.DisabledColor = System.Drawing.Color.Gray;
            this.btnprofile.Iconcolor = System.Drawing.Color.Transparent;
            this.btnprofile.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnprofile.Iconimage")));
            this.btnprofile.Iconimage_right = null;
            this.btnprofile.Iconimage_right_Selected = null;
            this.btnprofile.Iconimage_Selected = null;
            this.btnprofile.IconMarginLeft = 0;
            this.btnprofile.IconMarginRight = 0;
            this.btnprofile.IconRightVisible = true;
            this.btnprofile.IconRightZoom = 0D;
            this.btnprofile.IconVisible = true;
            this.btnprofile.IconZoom = 45D;
            this.btnprofile.IsTab = true;
            this.btnprofile.Location = new System.Drawing.Point(3, 565);
            this.btnprofile.Name = "btnprofile";
            this.btnprofile.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnprofile.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnprofile.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnprofile.selected = false;
            this.btnprofile.Size = new System.Drawing.Size(189, 41);
            this.btnprofile.TabIndex = 2;
            this.btnprofile.Text = "     Thông Tin";
            this.btnprofile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprofile.Textcolor = System.Drawing.Color.White;
            this.btnprofile.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprofile.Click += new System.EventHandler(this.btnprofile_Click);
            // 
            // btnpercent
            // 
            this.btnpercent.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnpercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnpercent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnpercent.BorderRadius = 0;
            this.btnpercent.ButtonText = "     % Điểm";
            this.btnpercent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoAni.SetDecoration(this.btnpercent, AnimatorNS.DecorationType.None);
            this.PanelAni.SetDecoration(this.btnpercent, AnimatorNS.DecorationType.None);
            this.btnpercent.DisabledColor = System.Drawing.Color.Gray;
            this.btnpercent.Iconcolor = System.Drawing.Color.Transparent;
            this.btnpercent.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnpercent.Iconimage")));
            this.btnpercent.Iconimage_right = null;
            this.btnpercent.Iconimage_right_Selected = null;
            this.btnpercent.Iconimage_Selected = null;
            this.btnpercent.IconMarginLeft = 0;
            this.btnpercent.IconMarginRight = 0;
            this.btnpercent.IconRightVisible = true;
            this.btnpercent.IconRightZoom = 0D;
            this.btnpercent.IconVisible = true;
            this.btnpercent.IconZoom = 45D;
            this.btnpercent.IsTab = true;
            this.btnpercent.Location = new System.Drawing.Point(3, 260);
            this.btnpercent.Name = "btnpercent";
            this.btnpercent.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnpercent.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnpercent.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnpercent.selected = false;
            this.btnpercent.Size = new System.Drawing.Size(189, 41);
            this.btnpercent.TabIndex = 2;
            this.btnpercent.Text = "     % Điểm";
            this.btnpercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnpercent.Textcolor = System.Drawing.Color.White;
            this.btnpercent.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpercent.Click += new System.EventHandler(this.btnpercent_Click);
            // 
            // btntotal
            // 
            this.btntotal.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btntotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btntotal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btntotal.BorderRadius = 0;
            this.btntotal.ButtonText = "     Điểm Tổng";
            this.btntotal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoAni.SetDecoration(this.btntotal, AnimatorNS.DecorationType.None);
            this.PanelAni.SetDecoration(this.btntotal, AnimatorNS.DecorationType.None);
            this.btntotal.DisabledColor = System.Drawing.Color.Gray;
            this.btntotal.Iconcolor = System.Drawing.Color.Transparent;
            this.btntotal.Iconimage = ((System.Drawing.Image)(resources.GetObject("btntotal.Iconimage")));
            this.btntotal.Iconimage_right = null;
            this.btntotal.Iconimage_right_Selected = null;
            this.btntotal.Iconimage_Selected = null;
            this.btntotal.IconMarginLeft = 0;
            this.btntotal.IconMarginRight = 0;
            this.btntotal.IconRightVisible = true;
            this.btntotal.IconRightZoom = 0D;
            this.btntotal.IconVisible = true;
            this.btntotal.IconZoom = 45D;
            this.btntotal.IsTab = true;
            this.btntotal.Location = new System.Drawing.Point(1, 213);
            this.btntotal.Name = "btntotal";
            this.btntotal.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btntotal.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btntotal.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btntotal.selected = false;
            this.btntotal.Size = new System.Drawing.Size(189, 41);
            this.btntotal.TabIndex = 2;
            this.btntotal.Text = "     Điểm Tổng";
            this.btntotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntotal.Textcolor = System.Drawing.Color.White;
            this.btntotal.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntotal.Click += new System.EventHandler(this.btntotal_Click);
            // 
            // btnmark
            // 
            this.btnmark.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnmark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnmark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnmark.BorderRadius = 0;
            this.btnmark.ButtonText = "     Điểm Chi Tiết";
            this.btnmark.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoAni.SetDecoration(this.btnmark, AnimatorNS.DecorationType.None);
            this.PanelAni.SetDecoration(this.btnmark, AnimatorNS.DecorationType.None);
            this.btnmark.DisabledColor = System.Drawing.Color.Gray;
            this.btnmark.Iconcolor = System.Drawing.Color.Transparent;
            this.btnmark.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnmark.Iconimage")));
            this.btnmark.Iconimage_right = null;
            this.btnmark.Iconimage_right_Selected = null;
            this.btnmark.Iconimage_Selected = null;
            this.btnmark.IconMarginLeft = 0;
            this.btnmark.IconMarginRight = 0;
            this.btnmark.IconRightVisible = true;
            this.btnmark.IconRightZoom = 0D;
            this.btnmark.IconVisible = true;
            this.btnmark.IconZoom = 50D;
            this.btnmark.IsTab = true;
            this.btnmark.Location = new System.Drawing.Point(1, 166);
            this.btnmark.Name = "btnmark";
            this.btnmark.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnmark.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnmark.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnmark.selected = false;
            this.btnmark.Size = new System.Drawing.Size(189, 41);
            this.btnmark.TabIndex = 2;
            this.btnmark.Text = "     Điểm Chi Tiết";
            this.btnmark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnmark.Textcolor = System.Drawing.Color.White;
            this.btnmark.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmark.Click += new System.EventHandler(this.btnmark_Click);
            // 
            // btnroll
            // 
            this.btnroll.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnroll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnroll.BorderRadius = 0;
            this.btnroll.ButtonText = "     Điểm Danh";
            this.btnroll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoAni.SetDecoration(this.btnroll, AnimatorNS.DecorationType.None);
            this.PanelAni.SetDecoration(this.btnroll, AnimatorNS.DecorationType.None);
            this.btnroll.DisabledColor = System.Drawing.Color.Gray;
            this.btnroll.Iconcolor = System.Drawing.Color.Transparent;
            this.btnroll.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnroll.Iconimage")));
            this.btnroll.Iconimage_right = null;
            this.btnroll.Iconimage_right_Selected = null;
            this.btnroll.Iconimage_Selected = null;
            this.btnroll.IconMarginLeft = 0;
            this.btnroll.IconMarginRight = 0;
            this.btnroll.IconRightVisible = true;
            this.btnroll.IconRightZoom = 0D;
            this.btnroll.IconVisible = true;
            this.btnroll.IconZoom = 45D;
            this.btnroll.IsTab = true;
            this.btnroll.Location = new System.Drawing.Point(1, 119);
            this.btnroll.Name = "btnroll";
            this.btnroll.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnroll.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnroll.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnroll.selected = false;
            this.btnroll.Size = new System.Drawing.Size(189, 41);
            this.btnroll.TabIndex = 2;
            this.btnroll.Text = "     Điểm Danh";
            this.btnroll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnroll.Textcolor = System.Drawing.Color.White;
            this.btnroll.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnroll.Click += new System.EventHandler(this.btnroll_Click);
            // 
            // btnhome
            // 
            this.btnhome.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnhome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnhome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnhome.BorderRadius = 0;
            this.btnhome.ButtonText = "     HOME";
            this.btnhome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoAni.SetDecoration(this.btnhome, AnimatorNS.DecorationType.None);
            this.PanelAni.SetDecoration(this.btnhome, AnimatorNS.DecorationType.None);
            this.btnhome.DisabledColor = System.Drawing.Color.Gray;
            this.btnhome.Iconcolor = System.Drawing.Color.Transparent;
            this.btnhome.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnhome.Iconimage")));
            this.btnhome.Iconimage_right = null;
            this.btnhome.Iconimage_right_Selected = null;
            this.btnhome.Iconimage_Selected = null;
            this.btnhome.IconMarginLeft = 0;
            this.btnhome.IconMarginRight = 0;
            this.btnhome.IconRightVisible = true;
            this.btnhome.IconRightZoom = 0D;
            this.btnhome.IconVisible = true;
            this.btnhome.IconZoom = 45D;
            this.btnhome.IsTab = true;
            this.btnhome.Location = new System.Drawing.Point(2, 72);
            this.btnhome.Name = "btnhome";
            this.btnhome.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnhome.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnhome.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnhome.selected = true;
            this.btnhome.Size = new System.Drawing.Size(190, 41);
            this.btnhome.TabIndex = 2;
            this.btnhome.Text = "     HOME";
            this.btnhome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhome.Textcolor = System.Drawing.Color.White;
            this.btnhome.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhome.Click += new System.EventHandler(this.btnhome_Click);
            // 
            // btnmenu
            // 
            this.btnmenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmenu.BackColor = System.Drawing.Color.Transparent;
            this.PanelAni.SetDecoration(this.btnmenu, AnimatorNS.DecorationType.None);
            this.LogoAni.SetDecoration(this.btnmenu, AnimatorNS.DecorationType.None);
            this.btnmenu.FlatAppearance.BorderSize = 0;
            this.btnmenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnmenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnmenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmenu.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.btnmenu.IconColor = System.Drawing.Color.White;
            this.btnmenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnmenu.IconSize = 30;
            this.btnmenu.Location = new System.Drawing.Point(156, 5);
            this.btnmenu.Name = "btnmenu";
            this.btnmenu.Size = new System.Drawing.Size(31, 26);
            this.btnmenu.TabIndex = 1;
            this.btnmenu.UseVisualStyleBackColor = false;
            this.btnmenu.Click += new System.EventHandler(this.btnmenu_Click);
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.header.Controls.Add(this.iconButton1);
            this.PanelAni.SetDecoration(this.header, AnimatorNS.DecorationType.None);
            this.LogoAni.SetDecoration(this.header, AnimatorNS.DecorationType.None);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1141, 31);
            this.header.TabIndex = 1;
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BackColor = System.Drawing.Color.Transparent;
            this.PanelAni.SetDecoration(this.iconButton1, AnimatorNS.DecorationType.None);
            this.LogoAni.SetDecoration(this.iconButton1, AnimatorNS.DecorationType.None);
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(1107, 3);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(31, 26);
            this.iconButton1.TabIndex = 1;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // LogoAni
            // 
            this.LogoAni.AnimationType = AnimatorNS.AnimationType.Scale;
            this.LogoAni.Cursor = null;
            animation8.AnimateOnlyDifferences = true;
            animation8.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation8.BlindCoeff")));
            animation8.LeafCoeff = 0F;
            animation8.MaxTime = 1F;
            animation8.MinTime = 0F;
            animation8.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation8.MosaicCoeff")));
            animation8.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation8.MosaicShift")));
            animation8.MosaicSize = 0;
            animation8.Padding = new System.Windows.Forms.Padding(0);
            animation8.RotateCoeff = 0F;
            animation8.RotateLimit = 0F;
            animation8.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation8.ScaleCoeff")));
            animation8.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation8.SlideCoeff")));
            animation8.TimeCoeff = 0F;
            animation8.TransparencyCoeff = 0F;
            this.LogoAni.DefaultAnimation = animation8;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.piclogo);
            this.PanelAni.SetDecoration(this.panelMain, AnimatorNS.DecorationType.None);
            this.LogoAni.SetDecoration(this.panelMain, AnimatorNS.DecorationType.None);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(193, 31);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(948, 609);
            this.panelMain.TabIndex = 2;
            // 
            // piclogo
            // 
            this.LogoAni.SetDecoration(this.piclogo, AnimatorNS.DecorationType.None);
            this.PanelAni.SetDecoration(this.piclogo, AnimatorNS.DecorationType.None);
            this.piclogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.piclogo.Image = ((System.Drawing.Image)(resources.GetObject("piclogo.Image")));
            this.piclogo.Location = new System.Drawing.Point(0, 0);
            this.piclogo.Name = "piclogo";
            this.piclogo.Size = new System.Drawing.Size(948, 609);
            this.piclogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.piclogo.TabIndex = 0;
            this.piclogo.TabStop = false;
            // 
            // PanelAni
            // 
            this.PanelAni.AnimationType = AnimatorNS.AnimationType.ScaleAndHorizSlide;
            this.PanelAni.Cursor = null;
            animation7.AnimateOnlyDifferences = true;
            animation7.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation7.BlindCoeff")));
            animation7.LeafCoeff = 0F;
            animation7.MaxTime = 1F;
            animation7.MinTime = 0F;
            animation7.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation7.MosaicCoeff")));
            animation7.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation7.MosaicShift")));
            animation7.MosaicSize = 0;
            animation7.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            animation7.RotateCoeff = 0F;
            animation7.RotateLimit = 0F;
            animation7.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation7.ScaleCoeff")));
            animation7.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation7.SlideCoeff")));
            animation7.TimeCoeff = 0F;
            animation7.TransparencyCoeff = 0F;
            this.PanelAni.DefaultAnimation = animation7;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.header;
            this.bunifuDragControl1.Vertical = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1141, 640);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.header);
            this.PanelAni.SetDecoration(this, AnimatorNS.DecorationType.None);
            this.LogoAni.SetDecoration(this, AnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.header.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Panel header;
        private FontAwesome.Sharp.IconButton btnmenu;
        private Bunifu.Framework.UI.BunifuFlatButton btnhome;
        private AnimatorNS.Animator LogoAni;
        private Bunifu.Framework.UI.BunifuFlatButton btnmark;
        private Bunifu.Framework.UI.BunifuFlatButton btnroll;
        private Bunifu.Framework.UI.BunifuFlatButton btntotal;
        private Bunifu.Framework.UI.BunifuFlatButton btnadmin;
        private Bunifu.Framework.UI.BunifuFlatButton btnprofile;
        private System.Windows.Forms.Panel panelMain;
        private AnimatorNS.Animator PanelAni;
        private System.Windows.Forms.Label lbrole;
        private System.Windows.Forms.Label lbuser;
        private Bunifu.Framework.UI.BunifuImageButton logo;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.PictureBox piclogo;
        private Bunifu.Framework.UI.BunifuFlatButton btnpercent;
    }
}