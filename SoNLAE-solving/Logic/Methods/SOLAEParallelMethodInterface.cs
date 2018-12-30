using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Methods
{
    public interface SOLAEParallelMethodInterface<T>
        : SOLAEMethodInterface<T>, Parallelizable {
    }
}
