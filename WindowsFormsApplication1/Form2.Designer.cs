namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.txtCODIGO = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCANCEL = new System.Windows.Forms.Button();
            this.lblCODIGO = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCODIGO
            // 
            this.txtCODIGO.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCODIGO.ForeColor = System.Drawing.Color.Orange;
            this.txtCODIGO.Location = new System.Drawing.Point(38, 55);
            this.txtCODIGO.Name = "txtCODIGO";
            this.txtCODIGO.Size = new System.Drawing.Size(234, 29);
            this.txtCODIGO.TabIndex = 0;
            this.txtCODIGO.UseSystemPasswordChar = true;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(25, 120);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(114, 50);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // btnCANCEL
            // 
            this.btnCANCEL.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCANCEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCANCEL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCANCEL.ForeColor = System.Drawing.Color.White;
            this.btnCANCEL.Location = new System.Drawing.Point(181, 120);
            this.btnCANCEL.Name = "btnCANCEL";
            this.btnCANCEL.Size = new System.Drawing.Size(110, 50);
            this.btnCANCEL.TabIndex = 2;
            this.btnCANCEL.Text = "CANCEL";
            this.btnCANCEL.UseVisualStyleBackColor = false;
            this.btnCANCEL.Click += new System.EventHandler(this.btnCANCEL_Click);
            // 
            // lblCODIGO
            // 
            this.lblCODIGO.AutoSize = true;
            this.lblCODIGO.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCODIGO.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCODIGO.Location = new System.Drawing.Point(14, 20);
            this.lblCODIGO.Name = "lblCODIGO";
            this.lblCODIGO.Size = new System.Drawing.Size(283, 21);
            this.lblCODIGO.TabIndex = 3;
            this.lblCODIGO.Text = "INGRESE CODIGO DE AUTORIZACION";
            this.lblCODIGO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(309, 183);
            this.Controls.Add(this.lblCODIGO);
            this.Controls.Add(this.btnCANCEL);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCODIGO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCODIGO;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCANCEL;
        public System.Windows.Forms.Label lblCODIGO;
    }
}