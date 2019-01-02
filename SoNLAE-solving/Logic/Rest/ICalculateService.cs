using SoNLAE_solving.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Rest
{
    public interface ICalculateService
    {
        Task<RestDTO> Calculate(RestDTO restDTO);
    }
}
