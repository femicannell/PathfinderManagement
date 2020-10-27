using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathfinderManagement.Business
{
    public interface ITextFileOperations
    {
        IEnumerable<string> LoadPathfinderInfo();
    }
}
