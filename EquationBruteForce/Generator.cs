using EquationBruteForce.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationBruteForce
{
    internal class Generator
    {
        public static List<Generator> IterationOrder = new List<Generator>();
        public int IterationLength { get => 4 + variables.Length + constants.Length; }

        private int iteration = 0;
        public int Iteration { get => iteration; set => iteration = value; }
        public int State { get => iteration % IterationLength; }
        
        
        private Variable[] variables;
        private Constant[] constants;
        
        Generator left;
        Generator right;

        public Generator(Variable[] variables, Constant[] constants)
        {
            this.variables = variables;
            this.constants = constants;
            IterationOrder.Add(this);
        }

        public void Increment()
        {
            Iteration++;
        }

        public int Run()
        {
            int vl = variables.Length;
            int cl = constants.Length;
            if (State < vl) return variables[State].Execute();
            else if (State - vl < cl) return constants[State - variables.Length].Execute();
            else
            {
                if (left == null) left = new Generator(variables, constants);
                if (right == null) right = new Generator(variables, constants);

                if (State - vl - cl == 0) return left.Run() + right.Run();
                else if (State - vl - cl == 1) return left.Run() - right.Run();
                else if (State - vl - cl == 2) return left.Run() * right.Run();
                else if (State - vl - cl == 3)
                {
                    var r = right.Run();
                    if (r == 0) return 0;
                    return left.Run() / right.Run();
                }
            }

            throw new Exception();
        }

        public override string ToString()
        {
            int vl = variables.Length;
            int cl = constants.Length;

            if (State < vl) return variables[State].ToString();
            else if (State - vl < constants.Length) return constants[State - variables.Length].ToString();
            else
            {
                if (left == null) left = new Generator(variables, constants);
                if (right == null) right = new Generator(variables, constants);

                if (State - vl - cl == 0) return $"({left} + {right})";
                if (State - vl - cl == 1) return $"({left} - {right})";
                if (State - vl - cl == 2) return $"{left} * {right}";
                if (State - vl - cl == 3) return $"{left} / {right}";
            }
            throw new Exception();
        }
    }
}
