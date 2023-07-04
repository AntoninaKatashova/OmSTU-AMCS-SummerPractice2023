using spacebattle;
using TechTalk.SpecFlow;
namespace spacebattletests;

[Binding]
public class BattleTest
{
    private double[] Speed = new double[2];
    private double[] Position = new double[2];
    private bool ChangeOfPosition = true, InstantaneousSpeed = true, ShuttlePosition = true;
    private double[] Location = new double[2];

    [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
    public void Космический_Корабль_Находится_В_Точке_Пространства(double x, double y)
    {
        Position = new double[2] {x, y};
    }

    [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
    public void Имеет_Мгновенную_Скорость(double x, double y)
    {
        Speed = new double[2] {x, y};
    }

    [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
    public void Космический_Корабль_Положение_В_Пространстве_Которого_Невозможно_Определить()
    {
        ShuttlePosition = false;
    }

    [Given(@"скорость корабля определить невозможно")]
    public void Скорость_Корабля_Определить_Невозможно()
    {
        InstantaneousSpeed = false;
    }

    [Given(@"изменить положение в пространстве космического корабля невозможно")]
    public void Изменить_Положение_В_Пространстве_Космического_Корабля_Невозможно()
    {
        ChangeOfPosition = false;
    }

    [When(@"происходит прямолинейное равномерное движение без деформации")]
    public void Происходит_Прямолинейное_Равномерное_Движение_Без_Деформации()
    {
        try
        {
            Location = Battle.ShuttleMovement(ChangeOfPosition, InstantaneousSpeed, ShuttlePosition, Speed, Position);
        }
        catch {}
    }

    [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void Космический_Корабль_Перемещается_В_Точку_Пространства_С_Координатами(double x, double y)
    {
        double[] expected = {x, y};
        Assert.Equal(expected, Location);
    }

    [Then(@"возникает ошибка Exception")]
    public void Возникает_Ошибка_Exception()
    {
        Assert.Throws<Exception>(() => Battle.ShuttleMovement(ChangeOfPosition, InstantaneousSpeed, ShuttlePosition, Speed, Position));
    }
}
