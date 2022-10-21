using EquationSolving;
using System.Net;
using static EquationSolving.QuadraticEquation;

namespace EquationSolvingTests
{
    public class QuadraticEquationTests 
    { 
    [TestFixture]
    public class QuadraticEquationBaseTests
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Console.WriteLine("Set up fixture");
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("Tear down fixture");
        }
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Begin test");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("End of test");
        }

        [Test, Ignore("For demo only")]
        public void TestAssertions()
        {
            Assert.That(new double[] { 6, 2 }, Is.Ordered.Descending);
            Assert.That(new int[] { 1, 2, 1 }, Is.Not.Unique);
        }

        [Test, Sequential, Category("Should return correct roots")]
        public void TestSolveGivenRightArgumentsReturnsWell(
            [Values(4, 5, 1)] double a,
            [Values(8, 2, 0)] double b,
            [Values(3, 10, 0)] double c,
            [Values(new double[] { -1.5, -0.5 },
                    new double[] {},
                    new double[] { 0 })] double[] expected)
        {
            Assert.That(Solve(a, b, c), Is.EquivalentTo(expected));
        }

        [TestCase(0, 5, 9)]
        [TestCase(0, 5, 0)]
        public void TestSolveGivenWrongArgumentsThrowsException(double x, double y, double z)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { Solve(x, y, z); });
        }

        [TestCase(0, 5, 9), Category("a == 0 -> Should throw exception")]
        [TestCase(0, 5, 0), Category("a == 0 -> Should throw exception")]
        public void TestSolveGivenWrongArgumentsThrowsException2(double a, double b, double c)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { Solve(a, b, c); }, "Should have thrown {0}", nameof(ArgumentOutOfRangeException));
        }


        public struct Values
        {
            public double A { get; set; }
            public double B { get; set; }
            public double C { get; set; }
            public double[] Roots { get; set; }
        }

        [Datapoints]
        private Values[] _values = new Values[]
    {
        new Values{A=20, B=10, C=0, Roots=new double[] { -1/2d, 0d} },
        new Values{A=10, B=0, C=2, Roots=new double[] { }},
        new Values{A=0, B=2, C=2, Roots=new double[] {1,1,1,1,0,0,0,0}},
    };

        [Theory]
        public void TestSolveInAllCases(Values values)
        {
            Assume.That(values.A, Is.Not.EqualTo(0));

            Assert.That(Solve(values.A, values.B, values.C), Is.EquivalentTo(values.Roots));
        }
    }

    [TestFixture]
    class PoShenLohTests
    {


        [TestCase(4, 8, 3, new double[] { -1.5, -0.5 })]
        [TestCase(1, 2, 1, new double[] { -1 })]
        [TestCase(9, -0, 9, new double[] { })]
        public void TestSolvePoShenLohGivenRightArgumentsReturnsWell(double a, double b, double c, double[] expected)
        {
            Assert.That(Solve_Po_Shen_Loh(a, b, c), Is.EquivalentTo(expected));
        }

        private static readonly object[][] Coefficients = new object[][]
        {
            new object[] {0d, 8d, 6565d},
            new object[] {0d, 9.215454d, -66662.1d },
            new object[] {0d, 0d, 0d },
            new object[] {0d, -35451515d, 69995965d}
        };

        [Test]
        public void TestSolvePoShenLohGivenWrongArgumentsThrowsException([ValueSource(nameof(Coefficients))] object[] coeffs)
        {
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => { Solve_Po_Shen_Loh((double)coeffs[0], (double)coeffs[1], (double)coeffs[2]); });
            Assert.Catch<Exception>(() => { Solve_Po_Shen_Loh((double)coeffs[0], (double)coeffs[1], (double)coeffs[2]); });
            Assert.That(ex.Message, Does.Contain("quadratic term cannot be 0"));
        }

    }
}
        public class LinearEquationTests
        {
            [SetUp]
            public void Setup()
            {

            }
            [Test]
            public void LinearEquationSolveGivenArguments()
            {
                Assert.AreEqual(new double[] {-2}, Program1.LinearEquationSolve(-2,3));
            }
        }


        public class CubicEquationTests        
    {
            [SetUp]
            public void Setup()
            {

            }


            [Test, Sequential]//Test case 1
            public void TestSolvePTB3GivenRightArgumentsReturnsWell(
                [Values(1, 0, 1)] double x,
                [Values(1, 2, 0)] double y,
                [Values(-3, 0, 0)] double z,
                [Values(1, 2, 0)] double t,
                [Values(new [] {1, 0.41421356237282331, -2.414213562373142},
                    new double[] {0.0, -0.0,-0.0},
                    new double[] {0}
            )] double[] expected) => Assert.That(expected, Is.EquivalentTo(PTB3.SolvePT3(x, y, z, t)));

        }
    
}


