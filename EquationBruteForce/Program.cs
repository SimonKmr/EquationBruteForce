using EquationBruteForce;
using EquationBruteForce.Operations;

List<IOperation> Register = new List<IOperation>();

var v1 = new Variable("x") { Value = 568 };
var v2 = new Variable("n") { Value = 57800 };

var c1 = new Constant(1);
var c2 = new Constant(2);

Register.Add(v1);
Register.Add(v2);
Register.Add(c1);
Register.Add(c2);

int target = 65223144;
Generator generator = new Generator(Register.ToArray());
var iterationOrder = Generator.IterationOrder;
int i = 0;
while (true)
{
    for(int j = 0; j < iterationOrder.Count; j++)
        iterationOrder[j].Iteration = i / (int)Math.Pow(generator.IterationLength, j);
    var res = generator.Run();
    var genStr = generator.ToString();
        
    if (res == target)
    {
        Console.WriteLine($"{genStr} = {res}");
        break;
    }
    i++;
}

