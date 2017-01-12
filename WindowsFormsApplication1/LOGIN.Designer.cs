namespace WindowsFormsApplication1
{
    partial class LOGIN
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOGIN));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.txtDNI_USUARIO = new System.Windows.Forms.TextBox();
            this.btnINGRESAR = new System.Windows.Forms.Button();
            this.txtCLAVE = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblMENSAJE_ERROR = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.GhostWhite;
            this.label4.Location = new System.Drawing.Point(401, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "USUARIO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.GhostWhite;
            this.label3.Location = new System.Drawing.Point(401, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "PUNTO DE VENTA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.GhostWhite;
            this.label5.Location = new System.Drawing.Point(401, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "CONTRASEÑA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.GhostWhite;
            this.label2.Location = new System.Drawing.Point(401, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "SEDE";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(572, 169);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(440, 25);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.GhostWhite;
            this.label1.Location = new System.Drawing.Point(401, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "EMPRESA";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(572, 205);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(440, 25);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.ItemHeight = 17;
            this.comboBox3.Location = new System.Drawing.Point(572, 238);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(440, 25);
            this.comboBox3.TabIndex = 7;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // txtDNI_USUARIO
            // 
            this.txtDNI_USUARIO.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDNI_USUARIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDNI_USUARIO.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNI_USUARIO.Location = new System.Drawing.Point(572, 272);
            this.txtDNI_USUARIO.Name = "txtDNI_USUARIO";
            this.txtDNI_USUARIO.Size = new System.Drawing.Size(440, 25);
            this.txtDNI_USUARIO.TabIndex = 8;
            // 
            // btnINGRESAR
            // 
            this.btnINGRESAR.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnINGRESAR.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnINGRESAR.FlatAppearance.BorderSize = 2;
            this.btnINGRESAR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnINGRESAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnINGRESAR.Font = new System.Drawing.Font("Segoe UI", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnINGRESAR.ForeColor = System.Drawing.Color.Snow;
            this.btnINGRESAR.Location = new System.Drawing.Point(599, 392);
            this.btnINGRESAR.Name = "btnINGRESAR";
            this.btnINGRESAR.Size = new System.Drawing.Size(168, 75);
            this.btnINGRESAR.TabIndex = 11;
            this.btnINGRESAR.Text = "INGRESAR";
            this.btnINGRESAR.UseVisualStyleBackColor = false;
            this.btnINGRESAR.Click += new System.EventHandler(this.btnINGRESAR_Click);
            // 
            // txtCLAVE
            // 
            this.txtCLAVE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCLAVE.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCLAVE.Location = new System.Drawing.Point(572, 305);
            this.txtCLAVE.Name = "txtCLAVE";
            this.txtCLAVE.PasswordChar = '*';
            this.txtCLAVE.Size = new System.Drawing.Size(440, 25);
            this.txtCLAVE.TabIndex = 9;
            this.txtCLAVE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCLAVE_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(820, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 75);
            this.button1.TabIndex = 13;
            this.button1.Text = "SALIR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblMENSAJE_ERROR
            // 
            this.lblMENSAJE_ERROR.AutoSize = true;
            this.lblMENSAJE_ERROR.BackColor = System.Drawing.Color.Transparent;
            this.lblMENSAJE_ERROR.ForeColor = System.Drawing.Color.White;
            this.lblMENSAJE_ERROR.Location = new System.Drawing.Point(692, 356);
            this.lblMENSAJE_ERROR.Name = "lblMENSAJE_ERROR";
            this.lblMENSAJE_ERROR.Size = new System.Drawing.Size(0, 13);
            this.lblMENSAJE_ERROR.TabIndex = 10;
            this.lblMENSAJE_ERROR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(358, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1, 447);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(657, 343);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(47, 215);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(265, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1052, 545);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblMENSAJE_ERROR);
            this.Controls.Add(this.btnINGRESAR);
            this.Controls.Add(this.txtCLAVE);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtDNI_USUARIO);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LOGIN";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LOGIN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox txtDNI_USUARIO;
        private System.Windows.Forms.Button btnINGRESAR;
        private System.Windows.Forms.TextBox txtCLAVE;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMENSAJE_ERROR;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
    }
}

