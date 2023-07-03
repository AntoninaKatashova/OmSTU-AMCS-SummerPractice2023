using SquareEquationLib;
using TechTalk.SpecFlow;
namespace BDD.Test;

[Binding]
class UnitTest1
{
    double coef_a, coef_b, coef_c;
    int precision = 9;
    double[] actual = new double[]{};

    [Given (@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
    public void SetOfCoefficients(double a, double b, double c)
    {
        coef_a = a;
        coef_b = b;
        coef_c = c;
    }

    [When(@"вычисляются корни квадратного уравнения")]
    public void Condition()
    {
        actual = SquareEquation.Solve(coef_a, coef_b, coef_c);
    }

    [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
    public void SolvingTheProblem1(double one_number, double two_number)
    {
        double[] expected = {one_number, two_number};
        Assert.True(expected.Length == actual.Length);
        for (int i = 0; i < actual.Length; i++)
        {
            Assert.Equal(expected[i], actual[i], precision);
        }
    }

    [Then(@"квадратное уравнение имеет один корень 1 кратности два")]
    public void SolvingTheProblem2()
    {
        Assert.Equal(1, actual[0], precision);
    }

    [Then(@"множество корней квадратного уравнения пустое")]
    public void SolvingTheProblem3()
    {
        Assert.Empty(actual);
    }



    [Then(@"выбрасывается исключение ArgumentException")]
    public void SolvingTheProblem4()
    {
        Assert.Throws<ArgumentException>(() => actual);
    }


}