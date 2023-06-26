namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double D;
        double eps = 1e-9;
        double[] answer = new double[]{};
        var massif = new double[]{double.NaN, double.NegativeInfinity, double.PositiveInfinity};
        if ((Math.Abs(a) < eps) || (massif.Contains(a)) || (massif.Contains(b)) || (massif.Contains(c)))
            throw new ArgumentException();
        else
        {
            b = b / a;
            c = c / a;
            D = Math.Pow(b,2) - 4 * c;
            if ((D < -eps))
            {
                answer = new double[]{};
            }
            else if ((-eps < D) && (D < eps))
            {
                var x1 = - (b + Math.Sign(b) * Math.Sqrt(D)) / 2;
                answer = new double[]{x1};
            }
            else
            {
                var x1 = - (b + Math.Sign(b) * Math.Sqrt(D)) / 2;
                var x2 = c / x1;
                answer = new double[]{x1, x2};
            }
            return answer;
        }
    }
}
