using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationBruteForce
{
    internal class TestCase
    {
        private int[] variables;
        public ReadOnlyCollection<int> Variables { get => Array.AsReadOnly<int>(variables); }
        public int Result { get; }

        public TestCase(int[] variables, int result)
        {
            this.variables = variables;
            Result = result;
        }
    }
}
