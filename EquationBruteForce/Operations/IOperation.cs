using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationBruteForce.Operations
{
    internal interface IOperation
    {
        public bool HasChildren { get; }
        public IOperation Left { get; set; }
        public IOperation Right { get; set; }

        public int Execute();

    }
}
