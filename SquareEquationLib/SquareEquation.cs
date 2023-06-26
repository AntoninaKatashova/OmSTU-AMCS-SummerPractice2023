namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double D;
        double[] answer = new double[]{};
        var massif = new double[]{double.NaN, double.NegativeInfinity, double.PositiveInfinity};
        if ((a == 0) || (massif.Contains(a)) || (massif.Contains(b)) || (massif.Contains(c)))
            throw new ArgumentException();
        else
        {
            b = b / a;
            c = c / a;
            D = Math.Pow(b,2) - 4 * c;
            if ((D < 0) && (Math.Abs(D) >= double.Epsilon))
            {
                answer = new double[]{};
            }
            else if ((- double.Epsilon < D) && (D < double.Epsilon))
            {
                var x1 = - (b + Math.Sign(b) * Math.Sqrt(D)) / 2;
                answer = new double[]{x1};
            }
            else if (D > 0)
            {
                var x1 = - (b + Math.Sign(b) * Math.Sqrt(D)) / 2;
                var x2 = c / x1;
                answer = new double[]{x1, x2};
            }
            return answer;
        }
    }
}
