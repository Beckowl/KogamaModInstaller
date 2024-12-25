namespace KogamaModInstaller;

partial class KogamaModInstaller
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
        lbl_modPath = new Label();
        tb_modPath = new TextBox();
        btn_browseMod = new Button();
        lbl_gameServer = new Label();
        lbl_modInvalid = new Label();
        rb_serverBR = new RadioButton();
        rb_serverFriends = new RadioButton();
        rb_serverWWW = new RadioButton();
        rb_serverCustom = new RadioButton();
        tb_customInstallPath = new TextBox();
        btn_browseInstallPath = new Button();
        btn_install = new Button();
        btn_uninstall = new Button();
        progressBar = new ProgressBar();
        lbl_installInvalid = new Label();
        SuspendLayout();
        // 
        // lbl_modPath
        // 
        lbl_modPath.AutoSize = true;
        lbl_modPath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        lbl_modPath.Location = new Point(12, 9);
        lbl_modPath.Name = "lbl_modPath";
        lbl_modPath.Size = new Size(76, 21);
        lbl_modPath.TabIndex = 0;
        lbl_modPath.Text = "Mod Path";
        // 
        // tb_modPath
        // 
        tb_modPath.Location = new Point(12, 33);
        tb_modPath.Name = "tb_modPath";
        tb_modPath.Size = new Size(392, 23);
        tb_modPath.TabIndex = 1;
        tb_modPath.TextChanged += tb_modPath_TextChanged;
        // 
        // btn_browseMod
        // 
        btn_browseMod.Location = new Point(410, 33);
        btn_browseMod.Name = "btn_browseMod";
        btn_browseMod.Size = new Size(75, 23);
        btn_browseMod.TabIndex = 2;
        btn_browseMod.Text = "Browse...";
        btn_browseMod.UseVisualStyleBackColor = true;
        btn_browseMod.Click += btn_browseMod_Click;
        // 
        // lbl_gameServer
        // 
        lbl_gameServer.AutoSize = true;
        lbl_gameServer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        lbl_gameServer.Location = new Point(12, 74);
        lbl_gameServer.Name = "lbl_gameServer";
        lbl_gameServer.Size = new Size(100, 21);
        lbl_gameServer.TabIndex = 3;
        lbl_gameServer.Text = "Game Server";
        // 
        // lbl_modInvalid
        // 
        lbl_modInvalid.AutoSize = true;
        lbl_modInvalid.ForeColor = Color.Red;
        lbl_modInvalid.Location = new Point(12, 59);
        lbl_modInvalid.Name = "lbl_modInvalid";
        lbl_modInvalid.Size = new Size(92, 15);
        lbl_modInvalid.TabIndex = 4;
        lbl_modInvalid.Text = "Invalid mod file.";
        lbl_modInvalid.Visible = false;
        // 
        // rb_serverBR
        // 
        rb_serverBR.AutoSize = true;
        rb_serverBR.Location = new Point(17, 98);
        rb_serverBR.Name = "rb_serverBR";
        rb_serverBR.Size = new Size(39, 19);
        rb_serverBR.TabIndex = 5;
        rb_serverBR.Text = "BR";
        rb_serverBR.UseVisualStyleBackColor = true;
        rb_serverBR.CheckedChanged += rb_serverBR_CheckedChanged;
        // 
        // rb_serverFriends
        // 
        rb_serverFriends.AutoSize = true;
        rb_serverFriends.Location = new Point(17, 123);
        rb_serverFriends.Name = "rb_serverFriends";
        rb_serverFriends.Size = new Size(63, 19);
        rb_serverFriends.TabIndex = 6;
        rb_serverFriends.Text = "Friends";
        rb_serverFriends.UseVisualStyleBackColor = true;
        rb_serverFriends.CheckedChanged += rb_serverFriends_CheckedChanged;
        // 
        // rb_serverWWW
        // 
        rb_serverWWW.AutoSize = true;
        rb_serverWWW.Location = new Point(17, 148);
        rb_serverWWW.Name = "rb_serverWWW";
        rb_serverWWW.Size = new Size(58, 19);
        rb_serverWWW.TabIndex = 7;
        rb_serverWWW.Text = "WWW";
        rb_serverWWW.UseVisualStyleBackColor = true;
        rb_serverWWW.CheckedChanged += rb_serverWWW_CheckedChanged;
        // 
        // rb_serverCustom
        // 
        rb_serverCustom.AutoSize = true;
        rb_serverCustom.Location = new Point(17, 173);
        rb_serverCustom.Name = "rb_serverCustom";
        rb_serverCustom.Size = new Size(67, 19);
        rb_serverCustom.TabIndex = 8;
        rb_serverCustom.Text = "Custom";
        rb_serverCustom.UseVisualStyleBackColor = true;
        rb_serverCustom.CheckedChanged += rb_serverCustom_CheckedChanged;
        // 
        // tb_customInstallPath
        // 
        tb_customInstallPath.Enabled = false;
        tb_customInstallPath.Location = new Point(90, 169);
        tb_customInstallPath.Name = "tb_customInstallPath";
        tb_customInstallPath.Size = new Size(314, 23);
        tb_customInstallPath.TabIndex = 9;
        tb_customInstallPath.TextChanged += tb_customInstallPath_TextChanged;
        // 
        // btn_browseInstallPath
        // 
        btn_browseInstallPath.Enabled = false;
        btn_browseInstallPath.Location = new Point(410, 171);
        btn_browseInstallPath.Name = "btn_browseInstallPath";
        btn_browseInstallPath.Size = new Size(75, 23);
        btn_browseInstallPath.TabIndex = 10;
        btn_browseInstallPath.Text = "Browse...";
        btn_browseInstallPath.UseVisualStyleBackColor = true;
        btn_browseInstallPath.Click += btn_browseInstallPath_Click;
        // 
        // btn_install
        // 
        btn_install.Enabled = false;
        btn_install.Location = new Point(12, 218);
        btn_install.Name = "btn_install";
        btn_install.Size = new Size(473, 23);
        btn_install.TabIndex = 11;
        btn_install.Text = "Install";
        btn_install.UseVisualStyleBackColor = true;
        btn_install.Click += btn_install_Click;
        // 
        // btn_uninstall
        // 
        btn_uninstall.Enabled = false;
        btn_uninstall.Location = new Point(12, 247);
        btn_uninstall.Name = "btn_uninstall";
        btn_uninstall.Size = new Size(473, 23);
        btn_uninstall.TabIndex = 12;
        btn_uninstall.Text = "Uninstall";
        btn_uninstall.UseVisualStyleBackColor = true;
        btn_uninstall.Click += btn_uninstall_Click;
        // 
        // progressBar
        // 
        progressBar.Location = new Point(12, 276);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(473, 23);
        progressBar.TabIndex = 13;
        // 
        // lbl_installInvalid
        // 
        lbl_installInvalid.AutoSize = true;
        lbl_installInvalid.ForeColor = Color.Red;
        lbl_installInvalid.Location = new Point(17, 195);
        lbl_installInvalid.Name = "lbl_installInvalid";
        lbl_installInvalid.Size = new Size(133, 15);
        lbl_installInvalid.TabIndex = 14;
        lbl_installInvalid.Text = "Invalid Installation path.";
        lbl_installInvalid.Visible = false;
        // 
        // KogamaModInstaller
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(497, 311);
        Controls.Add(lbl_installInvalid);
        Controls.Add(progressBar);
        Controls.Add(btn_uninstall);
        Controls.Add(btn_install);
        Controls.Add(btn_browseInstallPath);
        Controls.Add(tb_customInstallPath);
        Controls.Add(rb_serverCustom);
        Controls.Add(rb_serverWWW);
        Controls.Add(rb_serverFriends);
        Controls.Add(rb_serverBR);
        Controls.Add(lbl_modInvalid);
        Controls.Add(lbl_gameServer);
        Controls.Add(btn_browseMod);
        Controls.Add(tb_modPath);
        Controls.Add(lbl_modPath);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "KogamaModInstaller";
        Text = "Kogama Mod Installer";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lbl_modPath;
    private TextBox tb_modPath;
    private Button btn_browseMod;
    private Label lbl_gameServer;
    private Label lbl_modInvalid;
    private RadioButton rb_serverBR;
    private RadioButton rb_serverFriends;
    private RadioButton rb_serverWWW;
    private RadioButton rb_serverCustom;
    private TextBox tb_customInstallPath;
    private Button btn_browseInstallPath;
    private Button btn_install;
    private Button btn_uninstall;
    private ProgressBar progressBar;
    private Label lbl_installInvalid;
}