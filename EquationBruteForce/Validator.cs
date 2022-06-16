using EquationBruteForce.Operations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationBruteForce
{
    internal class Validator : ICollection<TestCase>
    {
        Generator generator;
        Variable[] variables;
        List<TestCase> Tests = new List<TestCase>();
        public Validator(Variable[] variables, Generator generator)
        {
            this.generator = generator;
            this.variables = variables;
        }

        //ICollection
        public int Count => Tests.Count;
        public bool IsReadOnly => throw new NotImplementedException();
        public void Add(TestCase testCase) => Tests.Add(testCase);
        public void Clear() => Tests.Clear();
        public bool Contains(TestCase item) => Tests.Contains(item);
        public void CopyTo(TestCase[] array, int arrayIndex) => Tests.CopyTo(array, arrayIndex);
        public IEnumerator<TestCase> GetEnumerator() => Tests.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public bool Remove(TestCase item) => Tests.Remove(item);


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
