using SoNLAE_solving.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Methods
{
    public interface SOLAEMethodInterface<T>
    {
        void Solve();

        VectorInterface<T> GetSolution();

        MatrixInterface<T> Matrix { get; set; }

        String GetName();
    }

}
