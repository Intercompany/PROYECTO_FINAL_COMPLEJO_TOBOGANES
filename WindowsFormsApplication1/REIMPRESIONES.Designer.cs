﻿namespace WindowsFormsApplication1
{
    partial class REIMPRESIONES
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtRUCDNI = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNOMCLIENTE = new System.Windows.Forms.TextBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.txtNUMERODOC = new System.Windows.Forms.TextBox();
            this.txtIDVENTA = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dgvDETREIMPRESION = new System.Windows.Forms.DataGridView();
            this.btnLIMPIAR = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDETREIMPRESION)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(407, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "REIMPRESIONES";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cboTipoDoc);
            this.groupBox2.Controls.Add(this.lblBuscar);
            this.groupBox2.Controls.Add(this.txtRUCDNI);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtNOMCLIENTE);
            this.groupBox2.Controls.Add(this.dgvClientes);
            this.groupBox2.Controls.Add(this.txtNUMERODOC);
            this.groupBox2.Controls.Add(this.txtIDVENTA);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1093, 632);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(255, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 21);
            this.label8.TabIndex = 20;
            this.label8.Text = "TIPO DOC";
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoDoc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoDoc.FormattingEnabled = true;
            this.cboTipoDoc.Location = new System.Drawing.Point(206, 69);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(176, 21);
            this.cboTipoDoc.TabIndex = 19;
            this.cboTipoDoc.SelectedIndexChanged += new System.EventHandler(this.cboTipoDoc_SelectedIndexChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color.Gold;
            this.lblBuscar.Location = new System.Drawing.Point(14, 12);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(266, 23);
            this.lblBuscar.TabIndex = 18;
            this.lblBuscar.Text = "Busqueda automatica llenar campos ....";
            // 
            // txtRUCDNI
            // 
            this.txtRUCDNI.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRUCDNI.Location = new System.Drawing.Point(901, 68);
            this.txtRUCDNI.Name = "txtRUCDNI";
            this.txtRUCDNI.Size = new System.Drawing.Size(176, 22);
            this.txtRUCDNI.TabIndex = 16;
            this.txtRUCDNI.Tag = "";
            this.txtRUCDNI.TextChanged += new System.EventHandler(this.txtRUCDNI_TextChanged);
            this.txtRUCDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRUCDNI_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(921, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 21);
            this.label6.TabIndex = 15;
            this.label6.Text = "RUC/DNI CLIENTE";
            // 
            // txtNOMCLIENTE
            // 
            this.txtNOMCLIENTE.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNOMCLIENTE.Location = new System.Drawing.Point(623, 69);
            this.txtNOMCLIENTE.Name = "txtNOMCLIENTE";
            this.txtNOMCLIENTE.Size = new System.Drawing.Size(257, 22);
            this.txtNOMCLIENTE.TabIndex = 14;
            this.txtNOMCLIENTE.Tag = "";
            this.txtNOMCLIENTE.TextChanged += new System.EventHandler(this.txtNOMCLIENTE_TextChanged);
            this.txtNOMCLIENTE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNOMCLIENTE_KeyPress);
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToResizeColumns = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.Firebrick;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Salmon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientes.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvClientes.Location = new System.Drawing.Point(4, 117);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.Size = new System.Drawing.Size(1084, 509);
            this.dgvClientes.TabIndex = 13;
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick);
            this.dgvClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellContentClick);
            // 
            // txtNUMERODOC
            // 
            this.txtNUMERODOC.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNUMERODOC.Location = new System.Drawing.Point(417, 69);
            this.txtNUMERODOC.Name = "txtNUMERODOC";
            this.txtNUMERODOC.Size = new System.Drawing.Size(176, 22);
            this.txtNUMERODOC.TabIndex = 7;
            this.txtNUMERODOC.Tag = "";
            this.txtNUMERODOC.TextChanged += new System.EventHandler(this.txtNUMERODOC_TextChanged);
            // 
            // txtIDVENTA
            // 
            this.txtIDVENTA.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDVENTA.Location = new System.Drawing.Point(13, 69);
            this.txtIDVENTA.Name = "txtIDVENTA";
            this.txtIDVENTA.Size = new System.Drawing.Size(157, 22);
            this.txtIDVENTA.TabIndex = 6;
            this.txtIDVENTA.Tag = "";
            this.txtIDVENTA.TextChanged += new System.EventHandler(this.txtIDVENTA_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(676, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "NOMBRE CLIENTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(441, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "NUMERO DOC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(52, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID VENTA";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.OrangeRed;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(884, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 50);
            this.button2.TabIndex = 17;
            this.button2.Text = "<< VOLVER";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.OrangeRed;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(1080, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(34, 31);
            this.button4.TabIndex = 63;
            this.button4.Text = "-";
            this.button4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgvDETREIMPRESION
            // 
            this.dgvDETREIMPRESION.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDETREIMPRESION.Location = new System.Drawing.Point(1038, 27);
            this.dgvDETREIMPRESION.Name = "dgvDETREIMPRESION";
            this.dgvDETREIMPRESION.Size = new System.Drawing.Size(51, 38);
            this.dgvDETREIMPRESION.TabIndex = 21;
            this.dgvDETREIMPRESION.Visible = false;
            // 
            // btnLIMPIAR
            // 
            this.btnLIMPIAR.BackColor = System.Drawing.Color.OrangeRed;
            this.btnLIMPIAR.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.btnLIMPIAR.FlatAppearance.BorderSize = 2;
            this.btnLIMPIAR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon;
            this.btnLIMPIAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLIMPIAR.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLIMPIAR.ForeColor = System.Drawing.Color.White;
            this.btnLIMPIAR.Location = new System.Drawing.Point(66, 15);
            this.btnLIMPIAR.Name = "btnLIMPIAR";
            this.btnLIMPIAR.Size = new System.Drawing.Size(130, 50);
            this.btnLIMPIAR.TabIndex = 64;
            this.btnLIMPIAR.Text = "LIMPIAR";
            this.btnLIMPIAR.UseVisualStyleBackColor = false;
            this.btnLIMPIAR.Click += new System.EventHandler(this.btnLIMPIAR_Click);
            // 
            // REIMPRESIONES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.abstract_background_red_1024x768;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1113, 712);
            this.Controls.Add(this.btnLIMPIAR);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDETREIMPRESION);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "REIMPRESIONES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCAR_CLIENTE";
            this.Load += new System.EventHandler(this.BUSCAR_CLIENTE_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDETREIMPRESION)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBuscar;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.TextBox txtNUMERODOC;
        public System.Windows.Forms.TextBox txtIDVENTA;
        public System.Windows.Forms.TextBox txtNOMCLIENTE;
        public System.Windows.Forms.TextBox txtRUCDNI;
        public System.Windows.Forms.ComboBox cboTipoDoc;
        private System.Windows.Forms.DataGridView dgvDETREIMPRESION;
        private System.Windows.Forms.Button btnLIMPIAR;
    }
}