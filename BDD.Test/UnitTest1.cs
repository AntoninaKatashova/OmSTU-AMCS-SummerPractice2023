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
    public void КвадратноеУравнениеСКоэффициентами(double a, double b, double c)
    {
        coef_a = a;
        coef_b = b;
        coef_c = c;
    }

    [When(@"вычисляются корни квадратного уравнения")]
    public void ВычисляютсяКорниКвадратногоУравнения()
    {
        actual = SquareEquation.Solve(coef_a, coef_b, coef_c);
    }

    [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
         public void ТоКвадратноеУравнениеИмеетДваКорняКратностиОдин(double one_number, double two_number)
         {
            double[] expected = {one_number, two_number};
            Assert.True(expected.Length == actual.Length);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.Equal(expected[i], actual[i], precision);
            }
         }


    [Then(@"квадратное уравнение имеет один корень 1 кратности два")]
    public void ТоКвадратноеУравнениеИмеетОдинКореньКратностиДва()
    {
        Assert.Equal(1, actual[0], precision);
    }

    [Then(@"множество корней квадратного уравнения пустое")]
    public void ТоМножествоКорнейКвадратногоУравненияПустое()
    {
        Assert.Empty(actual);
    }

    [Given(@"Квадратное уравнение с коэффициентами \(NaN, (.*), (.*)\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеAНеМожетБытьОпределено(double b, double c)
    {
        coef_a = double.NaN;
        coef_b = b;
        coef_c = c;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), NaN, (.*)\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеBНеМожетБытьОпределено(double a, double c)
    {
        coef_a = a;
        coef_b = double.NaN;
        coef_c = c;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), NaN\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеCНеМожетБытьОпределено(double a, double b)
    {
        coef_a = a;
        coef_b = b;
        coef_c = double.NaN;
    }

    [Given(@"Квадратное уравнение с коэффициентами \(Double\.PositiveInfinity, (.*), (.*)\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеAНеМожетБытьПоложительнойБесконечностью(double b, double c)
    {
        coef_a = double.PositiveInfinity;
        coef_b = b;
        coef_c = c;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.PositiveInfinity, (.*)\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеBНеМожетБытьПоложительнойБесконечностью(double a, double c)
    {
        coef_a = a;
        coef_b = double.PositiveInfinity;
        coef_c = c;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.PositiveInfinity\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеCНеМожетБытьПоложительнойБесконечностью(double a, double b)
    {
        coef_a = a;
        coef_b = b;
        coef_c = double.PositiveInfinity;
    }

    [Given(@"Квадратное уравнение с коэффициентами \(Double\.NegativeInfinity, (.*), (.*)\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеAНеМожетБытьОтрицательнойБесконечностью(double b, double c)
    {
        coef_a = double.NegativeInfinity;
        coef_b = b;
        coef_c = c;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.NegativeInfinity, (.*)\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеBНеМожетБытьОтрицательнойБесконечностью(double a, double c)
    {
        coef_a = a;
        coef_b = double.NegativeInfinity;
        coef_c = c;
    }

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.NegativeInfinity\)")]
    public void КвадратноеУравнениеСКоэффициентамиГдеCНеМожетБытьОтрицательнойБесконечностью(double a, double b)
    {
        coef_a = a;
        coef_b = b;
        coef_c = double.NegativeInfinity;
    }

    [Then(@"выбрасывается исключение ArgumentException")]
    public void SolvingTheProblem4()
    {
        Assert.Throws<ArgumentException>(() => actual);
    }


}