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
}
