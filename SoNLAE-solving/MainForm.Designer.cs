namespace SoNLAE_solving
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_generate = new System.Windows.Forms.Button();
            this.server_count = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.matrix_size = new System.Windows.Forms.TextBox();
            this.button_solve = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(0, -2);
            this.chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(739, 605);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            // 
            // button_generate
            // 
            this.button_generate.Location = new System.Drawing.Point(754, 77);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(234, 28);
            this.button_generate.TabIndex = 1;
            this.button_generate.Text = "Сгенерировать";
            this.button_generate.UseVisualStyleBackColor = true;
            this.button_generate.Click += new System.EventHandler(this.button_generate_Click);
            // 
            // server_count
            // 
            this.server_count.Location = new System.Drawing.Point(792, 209);
            this.server_count.Name = "server_count";
            this.server_count.Size = new System.Drawing.Size(139, 22);
            this.server_count.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(789, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Количество распределительных узлов";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(789, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 42);
            this.label2.TabIndex = 4;
            this.label2.Text = "Размер матрицы";
            // 
            // matrix_size
            // 
            this.matrix_size.Location = new System.Drawing.Point(792, 40);
            this.matrix_size.Name = "matrix_size";
            this.matrix_size.Size = new System.Drawing.Size(139, 22);
            this.matrix_size.TabIndex = 5;
            // 
            // button_solve
            // 
            this.button_solve.Location = new System.Drawing.Point(754, 253);
            this.button_solve.Name = "button_solve";
            this.button_solve.Size = new System.Drawing.Size(234, 28);
            this.button_solve.TabIndex = 6;
            this.button_solve.Text = "Подсчитать";
            this.button_solve.UseVisualStyleBackColor = true;
            this.button_solve.Click += new System.EventHandler(this.button_solve_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 601);
            this.Controls.Add(this.button_solve);
            this.Controls.Add(this.matrix_size);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.server_count);
            this.Controls.Add(this.button_generate);
            this.Controls.Add(this.chart);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button button_generate;
        private System.Windows.Forms.TextBox server_count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox matrix_size;
        private System.Windows.Forms.Button button_solve;
    }
}

