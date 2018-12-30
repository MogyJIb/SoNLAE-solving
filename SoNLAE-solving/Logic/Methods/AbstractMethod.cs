using SoNLAE_solving.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Methods
{
    public abstract class AbstractMethod : SOLAEMethodInterface<double>
    {
        protected MatrixInterface<double> matrix { get; set; }
        public String name { get; set; }
        MatrixInterface<double> SOLAEMethodInterface<double>.Matrix { get => matrix; set => matrix = value; }

        public AbstractMethod(MatrixInterface<Double> matrix, String name)
        {
            this.name = name;
            if (matrix.ColumnCount - 1 != matrix.RowCount)
                throw new ArgumentException("Matrix should has the  same makeWork of variables and equations.");

            this.matrix = matrix;
        }


        public string GetName()
        {
            return name;
        }

        public abstract void Solve();
        public abstract VectorInterface<double> GetSolution();
    }
}
