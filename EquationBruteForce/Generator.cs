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
        public int IterationLength { get => 4 + operations.Length; }

        private int iteration = 0;
        public int Iteration { get => iteration; set => iteration = value; }
        public int State { get => iteration % IterationLength; }
        
        
        private IOperation[] operations;
        
        Generator left;
        Generator right;

        public Generator(IOperation[] operations)
        {
            this.operations = operations;
            IterationOrder.Add(this);
        }

        public void Increment()
        {
            Iteration++;
        }

        public int Run()
        {
            if (State < operations.Length) return operations[State].Execute();
            else
            {
                if (left == null) left = new Generator(operations);
                if (right == null) right = new Generator(operations);

                if (State - operations.Length == 0) return left.Run() + right.Run();
                else if (State - operations.Length == 1) return left.Run() - right.Run();
                else if (State - operations.Length == 2) return left.Run() * right.Run();
                else if (State - operations.Length == 3)
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
            if (State < operations.Length) return operations[State].ToString();
            else
            {
                if (left == null) left = new Generator(operations);
                if (right == null) right = new Generator(operations);

                if (State - operations.Length == 0) return $"({left} + {right})";
                if (State - operations.Length == 1) return $"({left} - {right})";
                if (State - operations.Length == 2) return $"{left} * {right}";
                if (State - operations.Length == 3) return $"{left} / {right}";
            }
            throw new Exception();
        }
    }
}
