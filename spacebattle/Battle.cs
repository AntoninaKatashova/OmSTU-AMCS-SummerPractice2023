namespace spacebattle;

public class Battle
{
    public static double[] ShuttleMovement(bool ChangeOfPosition, bool InstantaneousSpeed, bool ShuttlePosition,
    double[] Speed, double[] Position)
    {
        if (!ChangeOfPosition || !InstantaneousSpeed || !ShuttlePosition)
        {
            throw new Exception();
        }
        double[] Result = {Speed[0] + Position[0], Speed[1] + Position[1]};
        return Result;
    }

    public static double MovementFromFuel(double InitialVolume, double FlowRate)
    {
        if (InitialVolume < FlowRate)
        {
            throw new Exception();
        }
        double result = InitialVolume - FlowRate;
        return result;
    }

    public static double InclinationAngle(bool ExistenceAngle, bool ExistenceSpeed, bool PossibleChange, 
    double InitialAngle, double AngularSpeed)
    {
        if (!ExistenceAngle || !ExistenceSpeed || !PossibleChange)
        {
            throw new Exception();
        }
        double TiltResult = InitialAngle + AngularSpeed;
        return TiltResult;
    }
}
