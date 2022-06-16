using EquationBruteForce;
using EquationBruteForce.Operations;

List<Variable> variables = new List<Variable>();
var v1 = new Variable("x");
var v2 = new Variable("n");

variables.Add(v1);
variables.Add(v2);


List<Constant> constants = new List<Constant>();
var c1 = new Constant(1);
var c2 = new Constant(2);

constants.Add(c1);
constants.Add(c2);

Generator generator = new Generator(variables.ToArray(),constants.ToArray());
Validator validator = new Validator(variables.ToArray(), generator);

validator.Add(new TestCase(new int[] { 1, 3 }, 0));
validator.Add(new TestCase(new int[] { 2, 2 }, 2));
validator.Add(new TestCase(new int[] { 12, 12 }, 132));
validator.Add(new TestCase(new int[] { 568, 57800 }, 65223144));


for (int i = 0; true; i++)
{
    for(int j = 0; j < Generator.IterationOrder.Count; j++)
        Generator.IterationOrder[j].Iteration = i / (int)Math.Pow(generator.IterationLength, j);

    if (validator.Validate())
    {
        var res = generator.Run();
        var genStr = generator.ToString();
        Console.WriteLine($"f(?) = {genStr}");
    }
    i++;
}

