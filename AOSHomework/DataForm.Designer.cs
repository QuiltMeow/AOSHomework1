namespace AOSHomework
{
    partial class DataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataForm));
            this.labelPageFault = new System.Windows.Forms.Label();
            this.labelInterrupt = new System.Windows.Forms.Label();
            this.labelDiskWrite = new System.Windows.Forms.Label();
            this.txtPageFault = new System.Windows.Forms.TextBox();
            this.txtInterrupt = new System.Windows.Forms.TextBox();
            this.txtDiskWrite = new System.Windows.Forms.TextBox();
            this.btnData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPageFault
            // 
            this.labelPageFault.AutoSize = true;
            this.labelPageFault.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelPageFault.Location = new System.Drawing.Point(15, 15);
            this.labelPageFault.Name = "labelPageFault";
            this.labelPageFault.Size = new System.Drawing.Size(124, 20);
            this.labelPageFault.TabIndex = 0;
            this.labelPageFault.Text = "Page Fault 資料";
            // 
            // labelInterrupt
            // 
            this.labelInterrupt.AutoSize = true;
            this.labelInterrupt.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelInterrupt.Location = new System.Drawing.Point(400, 15);
            this.labelInterrupt.Name = "labelInterrupt";
            this.labelInterrupt.Size = new System.Drawing.Size(73, 20);
            this.labelInterrupt.TabIndex = 2;
            this.labelInterrupt.Text = "中斷資料";
            // 
            // labelDiskWrite
            // 
            this.labelDiskWrite.AutoSize = true;
            this.labelDiskWrite.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelDiskWrite.Location = new System.Drawing.Point(780, 15);
            this.labelDiskWrite.Name = "labelDiskWrite";
            this.labelDiskWrite.Size = new System.Drawing.Size(105, 20);
            this.labelDiskWrite.TabIndex = 4;
            this.labelDiskWrite.Text = "磁碟寫入資料";
            // 
            // txtPageFault
            // 
            this.txtPageFault.BackColor = System.Drawing.Color.White;
            this.txtPageFault.Location = new System.Drawing.Point(19, 50);
            this.txtPageFault.Multiline = true;
            this.txtPageFault.Name = "txtPageFault";
            this.txtPageFault.ReadOnly = true;
            this.txtPageFault.Size = new System.Drawing.Size(300, 200);
            this.txtPageFault.TabIndex = 1;
            // 
            // txtInterrupt
            // 
            this.txtInterrupt.BackColor = System.Drawing.Color.White;
            this.txtInterrupt.Location = new System.Drawing.Point(404, 50);
            this.txtInterrupt.Multiline = true;
            this.txtInterrupt.Name = "txtInterrupt";
            this.txtInterrupt.ReadOnly = true;
            this.txtInterrupt.Size = new System.Drawing.Size(300, 200);
            this.txtInterrupt.TabIndex = 3;
            // 
            // txtDiskWrite
            // 
            this.txtDiskWrite.BackColor = System.Drawing.Color.White;
            this.txtDiskWrite.Location = new System.Drawing.Point(784, 50);
            this.txtDiskWrite.Multiline = true;
            this.txtDiskWrite.Name = "txtDiskWrite";
            this.txtDiskWrite.ReadOnly = true;
            this.txtDiskWrite.Size = new System.Drawing.Size(300, 200);
            this.txtDiskWrite.TabIndex = 5;
            // 
            // btnData
            // 
            this.btnData.Location = new System.Drawing.Point(1009, 16);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(75, 23);
            this.btnData.TabIndex = 6;
            this.btnData.Text = "資料格式";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1124, 281);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.txtDiskWrite);
            this.Controls.Add(this.txtInterrupt);
            this.Controls.Add(this.txtPageFault);
            this.Controls.Add(this.labelDiskWrite);
            this.Controls.Add(this.labelInterrupt);
            this.Controls.Add(this.labelPageFault);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "DataForm";
            this.Text = "統計原始資料";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelPageFault;
        private System.Windows.Forms.Label labelInterrupt;
        private System.Windows.Forms.Label labelDiskWrite;
        public System.Windows.Forms.TextBox txtPageFault;
        public System.Windows.Forms.TextBox txtInterrupt;
        public System.Windows.Forms.TextBox txtDiskWrite;
        private System.Windows.Forms.Button btnData;
    }
}