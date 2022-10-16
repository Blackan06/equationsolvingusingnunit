namespace EquationSolving;


public class LinearEquation
{
    public static double[] LinearEquationSolve(double a, double b)
    {
        if (a == 0)
        {
            if (b != 0)
            {
                throw new ArgumentOutOfRangeException("The 1st coefficient must not be 0");
            }
            return new double[] { b };
        }
        else
        {
            if (b == 0)
            {
                return new double[] { 0 };
            }
            else
            {
                return new double[] { -b / a };
            }
        }
    }
}
public class QuadraticEquation { 
    public static double[] Solve(double A, double B, double C)
    {
        if (A == 0) throw new ArgumentOutOfRangeException("The 1st coefficient must not be 0");
        double delta = B * B - 4 * A * C;
        if(delta < 0)
        {
            return new double[] {};
        }
        if (delta == 0)
        {
            return new double[] { (-B) / (2 * A) };
        }
        else
        {
            return new double[] { ((-B + (double)Math.Sqrt(delta)) / (2 * A)), ((-B - (double)Math.Sqrt(delta)) / (2 * A)) };

        }
    }
}


public class CubicEquation{
}

public class Program
{
    public static void Main()
    {
        QuadraticEquation eq = new QuadraticEquation();
        double[] result = new double[2];
        result = QuadraticEquation.Solve(4,8,99);
        foreach (double x in result)
        {
            Console.WriteLine(x);
        }
        Console.ReadLine();
    }
}



