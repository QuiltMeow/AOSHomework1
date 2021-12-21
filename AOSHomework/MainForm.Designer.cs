namespace AOSHomework
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.btnConsole = new System.Windows.Forms.Button();
            this.labelPageFault = new System.Windows.Forms.Label();
            this.labelInterrupt = new System.Windows.Forms.Label();
            this.labelDiskWrite = new System.Windows.Forms.Label();
            this.chartInterrupt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPageFault = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDiskWrite = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelExecute = new System.Windows.Forms.Label();
            this.btnGraphData = new System.Windows.Forms.Button();
            this.pbExecute = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartInterrupt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPageFault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiskWrite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExecute)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(1250, 60);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 23);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "產生記憶體參照字串檔案";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(47, 105);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(678, 50);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "開始進行模擬";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(650, 65);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "瀏覽";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.White;
            this.txtPath.Location = new System.Drawing.Point(205, 67);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(400, 22);
            this.txtPath.TabIndex = 2;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(45, 70);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(137, 12);
            this.labelPath.TabIndex = 1;
            this.labelPath.Text = "記憶體參照字串檔案路徑";
            // 
            // btnConsole
            // 
            this.btnConsole.Location = new System.Drawing.Point(1350, 21);
            this.btnConsole.Name = "btnConsole";
            this.btnConsole.Size = new System.Drawing.Size(100, 23);
            this.btnConsole.TabIndex = 5;
            this.btnConsole.Text = "主控台開關";
            this.btnConsole.UseVisualStyleBackColor = true;
            this.btnConsole.Click += new System.EventHandler(this.btnConsole_Click);
            // 
            // labelPageFault
            // 
            this.labelPageFault.AutoSize = true;
            this.labelPageFault.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelPageFault.Location = new System.Drawing.Point(43, 210);
            this.labelPageFault.Name = "labelPageFault";
            this.labelPageFault.Size = new System.Drawing.Size(124, 20);
            this.labelPageFault.TabIndex = 8;
            this.labelPageFault.Text = "Page Fault 圖表";
            // 
            // labelInterrupt
            // 
            this.labelInterrupt.AutoSize = true;
            this.labelInterrupt.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelInterrupt.Location = new System.Drawing.Point(516, 210);
            this.labelInterrupt.Name = "labelInterrupt";
            this.labelInterrupt.Size = new System.Drawing.Size(73, 20);
            this.labelInterrupt.TabIndex = 10;
            this.labelInterrupt.Text = "中斷圖表";
            // 
            // labelDiskWrite
            // 
            this.labelDiskWrite.AutoSize = true;
            this.labelDiskWrite.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelDiskWrite.Location = new System.Drawing.Point(991, 210);
            this.labelDiskWrite.Name = "labelDiskWrite";
            this.labelDiskWrite.Size = new System.Drawing.Size(105, 20);
            this.labelDiskWrite.TabIndex = 12;
            this.labelDiskWrite.Text = "磁碟寫入圖表";
            // 
            // chartInterrupt
            // 
            chartArea1.AxisX.Interval = 30D;
            chartArea1.AxisX.Maximum = 150D;
            chartArea1.AxisX.Minimum = 30D;
            chartArea1.Name = "ChartArea";
            this.chartInterrupt.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend";
            this.chartInterrupt.Legends.Add(legend1);
            this.chartInterrupt.Location = new System.Drawing.Point(520, 245);
            this.chartInterrupt.Name = "chartInterrupt";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend";
            series1.Name = "FIFO";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend";
            series2.Name = "Optimal";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend";
            series3.Name = "ARB";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend";
            series4.Name = "Custom";
            this.chartInterrupt.Series.Add(series1);
            this.chartInterrupt.Series.Add(series2);
            this.chartInterrupt.Series.Add(series3);
            this.chartInterrupt.Series.Add(series4);
            this.chartInterrupt.Size = new System.Drawing.Size(455, 460);
            this.chartInterrupt.TabIndex = 11;
            this.chartInterrupt.Text = "中斷圖表";
            // 
            // chartPageFault
            // 
            chartArea2.AxisX.Interval = 30D;
            chartArea2.AxisX.Maximum = 150D;
            chartArea2.AxisX.Minimum = 30D;
            chartArea2.Name = "ChartArea";
            this.chartPageFault.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend";
            this.chartPageFault.Legends.Add(legend2);
            this.chartPageFault.Location = new System.Drawing.Point(47, 245);
            this.chartPageFault.Name = "chartPageFault";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend";
            series5.Name = "FIFO";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend";
            series6.Name = "Optimal";
            series7.BorderWidth = 2;
            series7.ChartArea = "ChartArea";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend";
            series7.Name = "ARB";
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartArea";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend";
            series8.Name = "Custom";
            this.chartPageFault.Series.Add(series5);
            this.chartPageFault.Series.Add(series6);
            this.chartPageFault.Series.Add(series7);
            this.chartPageFault.Series.Add(series8);
            this.chartPageFault.Size = new System.Drawing.Size(455, 460);
            this.chartPageFault.TabIndex = 9;
            this.chartPageFault.Text = "Page Fault 圖表";
            // 
            // chartDiskWrite
            // 
            chartArea3.AxisX.Interval = 30D;
            chartArea3.AxisX.Maximum = 150D;
            chartArea3.AxisX.Minimum = 30D;
            chartArea3.Name = "ChartArea";
            this.chartDiskWrite.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend";
            this.chartDiskWrite.Legends.Add(legend3);
            this.chartDiskWrite.Location = new System.Drawing.Point(995, 245);
            this.chartDiskWrite.Name = "chartDiskWrite";
            series9.BorderWidth = 2;
            series9.ChartArea = "ChartArea";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Legend = "Legend";
            series9.Name = "FIFO";
            series10.BorderWidth = 2;
            series10.ChartArea = "ChartArea";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Legend = "Legend";
            series10.Name = "Optimal";
            series11.BorderWidth = 2;
            series11.ChartArea = "ChartArea";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Legend = "Legend";
            series11.Name = "ARB";
            series12.BorderWidth = 2;
            series12.ChartArea = "ChartArea";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Legend = "Legend";
            series12.Name = "Custom";
            this.chartDiskWrite.Series.Add(series9);
            this.chartDiskWrite.Series.Add(series10);
            this.chartDiskWrite.Series.Add(series11);
            this.chartDiskWrite.Series.Add(series12);
            this.chartDiskWrite.Size = new System.Drawing.Size(455, 460);
            this.chartDiskWrite.TabIndex = 13;
            this.chartDiskWrite.Text = "磁碟寫入圖表";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTitle.Location = new System.Drawing.Point(15, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(202, 27);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "高等作業系統 作業 1";
            // 
            // labelExecute
            // 
            this.labelExecute.AutoSize = true;
            this.labelExecute.Location = new System.Drawing.Point(890, 22);
            this.labelExecute.Name = "labelExecute";
            this.labelExecute.Size = new System.Drawing.Size(77, 12);
            this.labelExecute.TabIndex = 14;
            this.labelExecute.Text = "正在執行中 ...";
            this.labelExecute.Visible = false;
            // 
            // btnGraphData
            // 
            this.btnGraphData.Location = new System.Drawing.Point(1300, 100);
            this.btnGraphData.Name = "btnGraphData";
            this.btnGraphData.Size = new System.Drawing.Size(150, 23);
            this.btnGraphData.TabIndex = 7;
            this.btnGraphData.Text = "顯示統計原始資料";
            this.btnGraphData.UseVisualStyleBackColor = true;
            this.btnGraphData.Click += new System.EventHandler(this.btnGraphData_Click);
            // 
            // pbExecute
            // 
            this.pbExecute.Image = global::AOSHomework.Properties.Resources.Spin;
            this.pbExecute.Location = new System.Drawing.Point(855, 15);
            this.pbExecute.Name = "pbExecute";
            this.pbExecute.Size = new System.Drawing.Size(27, 27);
            this.pbExecute.TabIndex = 14;
            this.pbExecute.TabStop = false;
            this.pbExecute.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1474, 731);
            this.Controls.Add(this.btnGraphData);
            this.Controls.Add(this.pbExecute);
            this.Controls.Add(this.labelExecute);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.chartDiskWrite);
            this.Controls.Add(this.chartPageFault);
            this.Controls.Add(this.chartInterrupt);
            this.Controls.Add(this.labelDiskWrite);
            this.Controls.Add(this.labelInterrupt);
            this.Controls.Add(this.labelPageFault);
            this.Controls.Add(this.btnConsole);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnGenerate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Homework 1";
            ((System.ComponentModel.ISupportInitialize)(this.chartInterrupt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPageFault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiskWrite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExecute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button btnConsole;
        private System.Windows.Forms.Label labelPageFault;
        private System.Windows.Forms.Label labelInterrupt;
        private System.Windows.Forms.Label labelDiskWrite;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartInterrupt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPageFault;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDiskWrite;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelExecute;
        private System.Windows.Forms.PictureBox pbExecute;
        private System.Windows.Forms.Button btnGraphData;
    }
}