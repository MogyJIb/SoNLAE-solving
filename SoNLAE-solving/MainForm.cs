using SoNLAE_solving.Logic.Methods;
using SoNLAE_solving.Logic.Models;
using SoNLAE_solving.Logic.Statistic;
using SoNLAE_solving.Logic.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoNLAE_solving
{
    public partial class MainForm : Form
    {
        const double DEFAULT_MAX_VALUE = 100;
        const int DEFAULT_MATRIX_SIZE = 100;
        const int DEFAULT_SERVER_COUNT = 5;


        private DoubleMatrix matrix;
        private Dictionary<int, long> gaussStatistics;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            int matrixSize = DEFAULT_MATRIX_SIZE;
            try
            {
                matrixSize = int.Parse(matrix_size.Text);
            }
            catch(Exception exc) { }

            matrix = Rand.DoubleMatrix(DEFAULT_MAX_VALUE, matrixSize, matrixSize + 1);
        }

        private void button_solve_Click(object sender, EventArgs e)
        {
            int serverCount = DEFAULT_SERVER_COUNT;
            try
            {
                serverCount = int.Parse(server_count.Text);
            }
            catch (Exception exc) { }


            try
            {
                GaussStatisticsMaker gaussStatisticsMaker = new GaussStatisticsMaker(matrix, 1, 2, 3, 4);
                gaussStatisticsMaker.MakeStatistic();
                gaussStatistics = gaussStatisticsMaker.GetWorkStatistic();
                DrawChart();

                GaussMethod gaussMethod = new GaussMethod(matrix);
                gaussMethod.Solve();
                VectorInterface<double> result = gaussMethod.GetSolution();

                FileHandler.WriteMatrix(matrix);
                FileHandler.WriteSolution(result);
            }
            catch (Exception exc) { }

        }

        private void DrawChart()
        {
            if (gaussStatistics == null) return;

            chart.Series[0].Points.Clear();

            foreach (var entry in gaussStatistics)
                chart.Series[0].Points.AddXY(entry.Key, entry.Value / 1000000.0);

            chart.Update();
        }

    }
}
