using SquareEquationLib;
using TechTalk.SpecFlow;
namespace BDD.Test;

[Binding]
class UnitTest1
{
    double coef_a, coef_b, coef_c;
    double[] answer = new double[]{};

    [Given ("Квадратное уравнение с коэффициентами ((.*), (.*), (.*))")]
    public void SetOfCoefficients1(double a, double b, double c)
    {
        coef_a = a;
        coef_b = b;
        coef_c = c;
    }

    [When("вычисляются корни квадратного уравнения")]
    public void Condition1()
    {
        answer = SquareEquation.Solve(coef_a, coef_b, coef_c);
    }

    [Then("квадратное уравнение имеет два корня ((.*), (.*)) кратности один")]
}