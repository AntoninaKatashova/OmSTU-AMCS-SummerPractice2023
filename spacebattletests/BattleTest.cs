using spacebattle;
using TechTalk.SpecFlow;
namespace spacebattletests;

[Binding]
public class BattleTest
{
    private double[] Speed = new double[2];
    private double InitialVolume;
    private double InitialAngle;
    private double[] Position = new double[2];
    private double FlowRate;
    private double AngularSpeed;
    private bool ChangeOfPosition = true, InstantaneousSpeed = true, ShuttlePosition = true, ExistenceAngle = true, ExistenceSpeed = true, PossibleChange = true;
    private double[] Location = new double[2];
    private double Fuel;
    private double Corner;

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

    [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
    public void Космический_Корабль_Имеет_Топливо_В_Объеме(double fuel)
    {
        InitialVolume = fuel;
    }

    [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
    public void Имеет_Скорость_Расхода_Топлива_При_Движении(double expenditure)
    {
        FlowRate = expenditure;
    }

    [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
    public void Космический_Корабль_Имеет_Угол_Наклона(double Corner)
    {
        InitialAngle = Corner;
    }

    [Given(@"имеет мгновенную угловую скорость (.*) град")]
    public void Имеет_Мгновенную_Угловую_Скорость(double AngularVelocity)
    {
        AngularSpeed = AngularVelocity;
    }

    [Given(@"космический корабль, угол наклона которого невозможно определить")]
    public void Космический_Корабль_Угол_Наклона_Которого_Определить_Невозможно()
    {
        ExistenceAngle = false;
    }

    [Given(@"мгновенную угловую скорость невозможно определить")]
    public void Мгновенную_Угловую_Скорость_Невозможно_Определить()
    {
        ExistenceSpeed = false;
    }

    [Given(@"невозможно изменить угол наклона к оси OX космического корабля")]
    public void Невозможно_Изменить_Угол_Наклона_К_Оси()
    {
        PossibleChange = false;
    }

    [When(@"происходит прямолинейное равномерное движение без деформации")]
    public void Происходит_Прямолинейное_Равномерное_Движение_Без_Деформации()
    {
        try
        {
            Location = Battle.ShuttleMovement(ChangeOfPosition, InstantaneousSpeed, ShuttlePosition, Speed, Position);
            Fuel = Battle.MovementFromFuel(InitialVolume, FlowRate);
        }
        catch {}
    }

    [When(@"происходит вращение вокруг собственной оси")]
    public void Происходит_Вращение_Вокруг_Собственной_Оси()
    {
        try
        {
            Corner = Battle.InclinationAngle(ExistenceAngle, ExistenceSpeed, PossibleChange, InitialAngle, AngularSpeed);
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
        if (!ChangeOfPosition || !InstantaneousSpeed || !ShuttlePosition)
        {
            Assert.Throws<Exception>(() => Battle.ShuttleMovement(ChangeOfPosition, InstantaneousSpeed, ShuttlePosition, Speed, Position));
        }
        else if (InitialVolume < FlowRate)
        {    
            Assert.Throws<Exception>(() => Battle.MovementFromFuel(InitialVolume, FlowRate));
        }
        else if (!ExistenceAngle || !ExistenceSpeed || !PossibleChange)
        {
            Assert.Throws<Exception>(() => Battle.InclinationAngle(ExistenceAngle, ExistenceSpeed, PossibleChange, InitialAngle, AngularSpeed));
        }
    }

    [Then(@"новый объем топлива космического корабля равен (.*) ед")]
    public void Новый_Объем_Топлива_Космического_Корабля_Равен(double volume)
    {
        double expected = volume;
        Assert.Equal(expected, Fuel);
    }

    [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
    public void Угол_Наклона_Космического_Корабля_К_Оси(double x)
    {
        double expected = x;
        Assert.Equal(expected, Corner);
    }
}
