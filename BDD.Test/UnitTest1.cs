using SquareEquationLib;
using TechTalk.SpecFlow;
namespace BDD.Test;

[Binding]
class UnitTest1
{
    
    double coef_a, coef_b, coef_c;
    double[] answer = new double[]{};

    private readonly SquareEquation _squareEquation;
    public UnitTest1(double coef_a, double coef_b, double coef_c)
    {
        _squareEquation = new SquareEquation();
    }

    [Given ("Квадратное уравнение с коэффициентами ((.*), (.*), (.*))")]
    public 
}