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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REPORTE_BIENES));
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
            this.btnSAlir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLISTARBIENES)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIMPRIMIR
            // 
            this.btnIMPRIMIR.BackColor = System.Drawing.Color.Transparent;
            this.btnIMPRIMIR.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnIMPRIMIR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnIMPRIMIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIMPRIMIR.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIMPRIMIR.ForeColor = System.Drawing.Color.White;
            this.btnIMPRIMIR.Image = global::WindowsFormsApplication1.Properties.Resources.impresora__1_;
            this.btnIMPRIMIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIMPRIMIR.Location = new System.Drawing.Point(541, 147);
            this.btnIMPRIMIR.Name = "btnIMPRIMIR";
            this.btnIMPRIMIR.Size = new System.Drawing.Size(150, 43);
            this.btnIMPRIMIR.TabIndex = 7;
            this.btnIMPRIMIR.Text = "IMPRIMIR";
            this.btnIMPRIMIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIMPRIMIR.UseVisualStyleBackColor = false;
            this.btnIMPRIMIR.Click += new System.EventHandler(this.btnIMPRIMIR_Click);
            // 
            // btnFILTRARBIEN
            // 
            this.btnFILTRARBIEN.BackColor = System.Drawing.Color.Transparent;
            this.btnFILTRARBIEN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFILTRARBIEN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFILTRARBIEN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnFILTRARBIEN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFILTRARBIEN.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFILTRARBIEN.ForeColor = System.Drawing.Color.White;
            this.btnFILTRARBIEN.Image = global::WindowsFormsApplication1.Properties.Resources.buscando3;
            this.btnFILTRARBIEN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFILTRARBIEN.Location = new System.Drawing.Point(541, 208);
            this.btnFILTRARBIEN.Name = "btnFILTRARBIEN";
            this.btnFILTRARBIEN.Size = new System.Drawing.Size(150, 44);
            this.btnFILTRARBIEN.TabIndex = 6;
            this.btnFILTRARBIEN.Text = "BUSCAR";
            this.btnFILTRARBIEN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFILTRARBIEN.UseVisualStyleBackColor = false;
            this.btnFILTRARBIEN.Click += new System.EventHandler(this.btnFILTRARBIEN_Click);
            // 
            // cboCLASEBIEN
            // 
            this.cboCLASEBIEN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCLASEBIEN.FormattingEnabled = true;
            this.cboCLASEBIEN.Location = new System.Drawing.Point(181, 175);
            this.cboCLASEBIEN.Name = "cboCLASEBIEN";
            this.cboCLASEBIEN.Size = new System.Drawing.Size(223, 29);
            this.cboCLASEBIEN.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(38, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "CLASE BIEN :";
            // 
            // txtFECHAFINAL
            // 
            this.txtFECHAFINAL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFECHAFINAL.Location = new System.Drawing.Point(181, 131);
            this.txtFECHAFINAL.Name = "txtFECHAFINAL";
            this.txtFECHAFINAL.Size = new System.Drawing.Size(318, 29);
            this.txtFECHAFINAL.TabIndex = 3;
            // 
            // txtFECHAINI
            // 
            this.txtFECHAINI.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFECHAINI.Location = new System.Drawing.Point(181, 88);
            this.txtFECHAINI.Name = "txtFECHAINI";
            this.txtFECHAINI.Size = new System.Drawing.Size(318, 29);
            this.txtFECHAINI.TabIndex = 2;
            this.txtFECHAINI.Value = new System.DateTime(2017, 1, 19, 16, 22, 4, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(38, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "FECHA FINAL :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(38, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "FECHA INICIAL :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 27.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(195, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "REPORTE DE BIENES";
            // 
            // dgvLISTARBIENES
            // 
            this.dgvLISTARBIENES.AllowUserToAddRows = false;
            this.dgvLISTARBIENES.AllowUserToDeleteRows = false;
            this.dgvLISTARBIENES.AllowUserToResizeColumns = false;
            this.dgvLISTARBIENES.AllowUserToResizeRows = false;
            this.dgvLISTARBIENES.BackgroundColor = System.Drawing.Color.Brown;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLISTARBIENES.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLISTARBIENES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLISTARBIENES.Location = new System.Drawing.Point(12, 281);
            this.dgvLISTARBIENES.Name = "dgvLISTARBIENES";
            this.dgvLISTARBIENES.ReadOnly = true;
            this.dgvLISTARBIENES.RowHeadersVisible = false;
            this.dgvLISTARBIENES.Size = new System.Drawing.Size(711, 395);
            this.dgvLISTARBIENES.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(102, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 30);
            this.label5.TabIndex = 3;
            this.label5.Text = "RESUMEN: ";
            // 
            // lblTOTCANTIDAD
            // 
            this.lblTOTCANTIDAD.AutoSize = true;
            this.lblTOTCANTIDAD.BackColor = System.Drawing.Color.Transparent;
            this.lblTOTCANTIDAD.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTOTCANTIDAD.ForeColor = System.Drawing.Color.Yellow;
            this.lblTOTCANTIDAD.Location = new System.Drawing.Point(225, 241);
            this.lblTOTCANTIDAD.Name = "lblTOTCANTIDAD";
            this.lblTOTCANTIDAD.Size = new System.Drawing.Size(122, 30);
            this.lblTOTCANTIDAD.TabIndex = 4;
            this.lblTOTCANTIDAD.Text = "CANTIDAD";
            // 
            // LBLTOTAL
            // 
            this.LBLTOTAL.AutoSize = true;
            this.LBLTOTAL.BackColor = System.Drawing.Color.Transparent;
            this.LBLTOTAL.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLTOTAL.ForeColor = System.Drawing.Color.Yellow;
            this.LBLTOTAL.Location = new System.Drawing.Point(355, 240);
            this.LBLTOTAL.Name = "LBLTOTAL";
            this.LBLTOTAL.Size = new System.Drawing.Size(76, 30);
            this.LBLTOTAL.TabIndex = 5;
            this.LBLTOTAL.Text = "TOTAL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, -4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 25);
            this.label8.TabIndex = 6;
            this.label8.Text = "CANTIDAD";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(133, -4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 25);
            this.label9.TabIndex = 7;
            this.label9.Text = "TOTAL";
            // 
            // btnSAlir
            // 
            this.btnSAlir.BackColor = System.Drawing.Color.Transparent;
            this.btnSAlir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSAlir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSAlir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSAlir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSAlir.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAlir.ForeColor = System.Drawing.Color.White;
            this.btnSAlir.Image = global::WindowsFormsApplication1.Properties.Resources.salida;
            this.btnSAlir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSAlir.Location = new System.Drawing.Point(541, 81);
            this.btnSAlir.Name = "btnSAlir";
            this.btnSAlir.Size = new System.Drawing.Size(150, 44);
            this.btnSAlir.TabIndex = 8;
            this.btnSAlir.Text = "SALIR";
            this.btnSAlir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSAlir.UseVisualStyleBackColor = false;
            this.btnSAlir.Click += new System.EventHandler(this.btnSAlir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(221, 215);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 23);
            this.panel1.TabIndex = 9;
            // 
            // REPORTE_BIENES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.abstract_background_red_1024x7681;
            this.ClientSize = new System.Drawing.Size(738, 683);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSAlir);
            this.Controls.Add(this.cboCLASEBIEN);
            this.Controls.Add(this.btnFILTRARBIEN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnIMPRIMIR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LBLTOTAL);
            this.Controls.Add(this.lblTOTCANTIDAD);
            this.Controls.Add(this.txtFECHAFINAL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFECHAINI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLISTARBIENES);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "REPORTE_BIENES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORTE_BIENES";
            this.Load += new System.EventHandler(this.REPORTE_BIENES_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLISTARBIENES)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        public System.Windows.Forms.Button btnSAlir;
        private System.Windows.Forms.Panel panel1;
    }
}