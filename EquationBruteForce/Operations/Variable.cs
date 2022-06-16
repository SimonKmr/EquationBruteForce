using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationBruteForce.Operations
{
    internal class Variable : IOperation
    {
        public Variable(string name)
        {
            
            Name = name;
        }

        public bool HasChildren => false;
        public string Name { get; set; }
        public int Value { get; set; }
        public IOperation Left { get; set; }
        public IOperation Right { get; set; }

        public int Execute()
        {
            return Value;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
