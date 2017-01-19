namespace WindowsFormsApplication1
{
    partial class REPORTE_BIENES
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORTE_BIENES));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIMPRIMIR = new System.Windows.Forms.Button();
            this.btnFILTRARBIEN = new System.Windows.Forms.Button();
            this.cboCLASEBIEN = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFECHAFINAL = new System.Windows.Forms.DateTimePicker();
            this.txtFECHAINI = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLISTARBIENES = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTOTCANTIDAD = new System.Windows.Forms.Label();
            this.LBLTOTAL = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLISTARBIENES)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnIMPRIMIR);
            this.groupBox1.Controls.Add(this.btnFILTRARBIEN);
            this.groupBox1.Controls.Add(this.cboCLASEBIEN);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFECHAFINAL);
            this.groupBox1.Controls.Add(this.txtFECHAINI);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Enabled = false;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(711, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BUSQUEDA";
            // 
            // btnIMPRIMIR
            // 
            this.btnIMPRIMIR.BackColor = System.Drawing.Color.Transparent;
            this.btnIMPRIMIR.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnIMPRIMIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIMPRIMIR.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIMPRIMIR.Image = global::WindowsFormsApplication1.Properties.Resources.impresora__1_;
            this.btnIMPRIMIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIMPRIMIR.Location = new System.Drawing.Point(544, 55);
            this.btnIMPRIMIR.Name = "btnIMPRIMIR";
            this.btnIMPRIMIR.Size = new System.Drawing.Size(147, 43);
            this.btnIMPRIMIR.TabIndex = 7;
            this.btnIMPRIMIR.Text = "IMPRIMIR";
            this.btnIMPRIMIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIMPRIMIR.UseVisualStyleBackColor = false;
            // 
            // btnFILTRARBIEN
            // 
            this.btnFILTRARBIEN.BackColor = System.Drawing.Color.Transparent;
            this.btnFILTRARBIEN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFILTRARBIEN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFILTRARBIEN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFILTRARBIEN.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFILTRARBIEN.Image = global::WindowsFormsApplication1.Properties.Resources.buscando3;
            this.btnFILTRARBIEN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFILTRARBIEN.Location = new System.Drawing.Point(544, 111);
            this.btnFILTRARBIEN.Name = "btnFILTRARBIEN";
            this.btnFILTRARBIEN.Size = new System.Drawing.Size(147, 44);
            this.btnFILTRARBIEN.TabIndex = 6;
            this.btnFILTRARBIEN.Text = "BUSCAR";
            this.btnFILTRARBIEN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFILTRARBIEN.UseVisualStyleBackColor = false;
            this.btnFILTRARBIEN.Click += new System.EventHandler(this.btnFILTRARBIEN_Click);
            // 
            // cboCLASEBIEN
            // 
            this.cboCLASEBIEN.FormattingEnabled = true;
            this.cboCLASEBIEN.Location = new System.Drawing.Point(168, 136);
            this.cboCLASEBIEN.Name = "cboCLASEBIEN";
            this.cboCLASEBIEN.Size = new System.Drawing.Size(272, 28);
            this.cboCLASEBIEN.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "CLASE BIEN:";
            // 
            // txtFECHAFINAL
            // 
            this.txtFECHAFINAL.Location = new System.Drawing.Point(168, 90);
            this.txtFECHAFINAL.Name = "txtFECHAFINAL";
            this.txtFECHAFINAL.Size = new System.Drawing.Size(318, 27);
            this.txtFECHAFINAL.TabIndex = 3;
            // 
            // txtFECHAINI
            // 
            this.txtFECHAINI.Location = new System.Drawing.Point(168, 41);
            this.txtFECHAINI.Name = "txtFECHAINI";
            this.txtFECHAINI.Size = new System.Drawing.Size(318, 27);
            this.txtFECHAINI.TabIndex = 2;
            this.txtFECHAINI.Value = new System.DateTime(2017, 1, 19, 16, 22, 4, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "FECHA FINAL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "FECHA INICIAL :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(235, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "REPORTE DE BIENES";
            // 
            // dgvLISTARBIENES
            // 
            this.dgvLISTARBIENES.AllowUserToAddRows = false;
            this.dgvLISTARBIENES.AllowUserToDeleteRows = false;
            this.dgvLISTARBIENES.BackgroundColor = System.Drawing.Color.Brown;
            this.dgvLISTARBIENES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLISTARBIENES.Location = new System.Drawing.Point(12, 281);
            this.dgvLISTARBIENES.Name = "dgvLISTARBIENES";
            this.dgvLISTARBIENES.ReadOnly = true;
            this.dgvLISTARBIENES.Size = new System.Drawing.Size(711, 395);
            this.dgvLISTARBIENES.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(105, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "RESUMEN: ";
            // 
            // lblTOTCANTIDAD
            // 
            this.lblTOTCANTIDAD.AutoSize = true;
            this.lblTOTCANTIDAD.BackColor = System.Drawing.Color.Transparent;
            this.lblTOTCANTIDAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTOTCANTIDAD.ForeColor = System.Drawing.Color.Yellow;
            this.lblTOTCANTIDAD.Location = new System.Drawing.Point(225, 255);
            this.lblTOTCANTIDAD.Name = "lblTOTCANTIDAD";
            this.lblTOTCANTIDAD.Size = new System.Drawing.Size(105, 24);
            this.lblTOTCANTIDAD.TabIndex = 4;
            this.lblTOTCANTIDAD.Text = "CANTIDAD";
            // 
            // LBLTOTAL
            // 
            this.LBLTOTAL.AutoSize = true;
            this.LBLTOTAL.BackColor = System.Drawing.Color.Transparent;
            this.LBLTOTAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLTOTAL.ForeColor = System.Drawing.Color.Yellow;
            this.LBLTOTAL.Location = new System.Drawing.Point(347, 254);
            this.LBLTOTAL.Name = "LBLTOTAL";
            this.LBLTOTAL.Size = new System.Drawing.Size(80, 25);
            this.LBLTOTAL.TabIndex = 5;
            this.LBLTOTAL.Text = "TOTAL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(225, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 18);
            this.label8.TabIndex = 6;
            this.label8.Text = "CANTIDAD";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(349, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 18);
            this.label9.TabIndex = 7;
            this.label9.Text = "TOTAL";
            // 
            // REPORTE_BIENES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.abstract_background_red_1024x7681;
            this.ClientSize = new System.Drawing.Size(738, 683);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LBLTOTAL);
            this.Controls.Add(this.lblTOTCANTIDAD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvLISTARBIENES);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "REPORTE_BIENES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORTE_BIENES";
            this.Load += new System.EventHandler(this.REPORTE_BIENES_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLISTARBIENES)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCLASEBIEN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.DateTimePicker txtFECHAFINAL;
        public System.Windows.Forms.DateTimePicker txtFECHAINI;
        public System.Windows.Forms.DataGridView dgvLISTARBIENES;
        public System.Windows.Forms.Button btnIMPRIMIR;
        public System.Windows.Forms.Button btnFILTRARBIEN;
        public System.Windows.Forms.Label lblTOTCANTIDAD;
        public System.Windows.Forms.Label LBLTOTAL;
    }
}