namespace appSSRS.Desktop
{
    partial class frmMain
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
            this.gbxSQL = new System.Windows.Forms.GroupBox();
            this.btnOpenFileDialog = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbReportData = new System.Windows.Forms.GroupBox();
            this.dgvReportData = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.dialogSQL = new System.Windows.Forms.OpenFileDialog();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnGetTypes = new System.Windows.Forms.Button();
            this.gbxSQL.SuspendLayout();
            this.gbReportData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportData)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxSQL
            // 
            this.gbxSQL.Controls.Add(this.btnOpenFileDialog);
            this.gbxSQL.Controls.Add(this.txtPath);
            this.gbxSQL.Controls.Add(this.label1);
            this.gbxSQL.Location = new System.Drawing.Point(8, 12);
            this.gbxSQL.Name = "gbxSQL";
            this.gbxSQL.Size = new System.Drawing.Size(773, 59);
            this.gbxSQL.TabIndex = 0;
            this.gbxSQL.TabStop = false;
            this.gbxSQL.Text = "SQL";
            // 
            // btnOpenFileDialog
            // 
            this.btnOpenFileDialog.Location = new System.Drawing.Point(727, 23);
            this.btnOpenFileDialog.Name = "btnOpenFileDialog";
            this.btnOpenFileDialog.Size = new System.Drawing.Size(34, 23);
            this.btnOpenFileDialog.TabIndex = 2;
            this.btnOpenFileDialog.Text = "...";
            this.btnOpenFileDialog.UseVisualStyleBackColor = true;
            this.btnOpenFileDialog.Click += new System.EventHandler(this.btnOpenFileDialog_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(79, 23);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(641, 20);
            this.txtPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Archivo SQL";
            // 
            // gbReportData
            // 
            this.gbReportData.Controls.Add(this.dgvReportData);
            this.gbReportData.Location = new System.Drawing.Point(8, 77);
            this.gbReportData.Name = "gbReportData";
            this.gbReportData.Size = new System.Drawing.Size(773, 268);
            this.gbReportData.TabIndex = 1;
            this.gbReportData.TabStop = false;
            this.gbReportData.Text = "Report Data";
            // 
            // dgvReportData
            // 
            this.dgvReportData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportData.Location = new System.Drawing.Point(6, 19);
            this.dgvReportData.Name = "dgvReportData";
            this.dgvReportData.Size = new System.Drawing.Size(755, 244);
            this.dgvReportData.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(700, 351);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(619, 351);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 3;
            this.btnGetData.Text = "Get &Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnGetTypes
            // 
            this.btnGetTypes.Location = new System.Drawing.Point(538, 351);
            this.btnGetTypes.Name = "btnGetTypes";
            this.btnGetTypes.Size = new System.Drawing.Size(75, 23);
            this.btnGetTypes.TabIndex = 4;
            this.btnGetTypes.Text = "Get &Types";
            this.btnGetTypes.UseVisualStyleBackColor = true;
            this.btnGetTypes.Click += new System.EventHandler(this.btnGetTypes_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 386);
            this.Controls.Add(this.btnGetTypes);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.gbReportData);
            this.Controls.Add(this.gbxSQL);
            this.Name = "frmMain";
            this.Text = "Report Tester";
            this.gbxSQL.ResumeLayout(false);
            this.gbxSQL.PerformLayout();
            this.gbReportData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSQL;
        private System.Windows.Forms.GroupBox gbReportData;
        private System.Windows.Forms.DataGridView dgvReportData;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOpenFileDialog;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog dialogSQL;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnGetTypes;
    }
}

