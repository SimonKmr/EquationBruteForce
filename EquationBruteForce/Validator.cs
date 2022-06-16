using EquationBruteForce.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationBruteForce
{
    internal class Validator
    {
        Generator generator;
        Variable[] variables;
        List<TestCase> Tests = new List<TestCase>();
        public Validator(Variable[] variables, Generator generator)
        {
            this.generator = generator;
            this.variables = variables;
        }

        public void Add(TestCase testCase)
        {
            Tests.Add(testCase);
        }

        public bool Validate()
        {
            for(int i = 0; i < Tests.Count; i++)
            {
                for (int j = 0; j < variables.Length; j++) variables[j].Value = Tests[i].Variables[j];
                if (generator.Run() != Tests[i].Result) return false;
            }
            return true;
        }
    }
}
