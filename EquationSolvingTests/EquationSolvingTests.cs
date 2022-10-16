using EquationSolving;

namespace EquationSolvingTests
{
    public class LinearEquationTests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        [TestCase(1, -3, new double[] { 3 })]
        [TestCase(1, 5, new double[] { -5 })]
        public void LinearEquationSolveGivenWrongArguments(double a, double b, double[] expected)
        {
            Assert.That(LinearEquation.LinearEquationSolve(a, b), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0, 5)]
        [TestCase(1, 5)]
        [TestCase(0, 0)]
        public void LinearEquationSolveGivenWrongArgumentsThrowsException(double a, double b)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { LinearEquation.LinearEquationSolve(a, b); });
        }
    }


    public class QuadracticEquationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, Sequential]
        public void TestSolveGivenRightArgumentsReturnsWell(
            [Values(4, 5, 1)] double x,
            [Values(8, 2, 0)] double y,
            [Values(3, 10, 0)] double z,
            [Values(new double[] { -1.5, -0.5 },
                    new double[] {},
                    new double[] { 0 })] double[] expected)
        {
            /*Assert.AreEqual(new double[] { -1.5, -0.5 }, QuadraticEquation.Solve(x, y, z));*/
            Assert.That(expected, Is.EquivalentTo(QuadraticEquation.Solve(x, y, z)));
        }

        [Test]
        [TestCase(0, 5, 9)]
        [TestCase(0, 5, 0)]
        [TestCase(0, 0, 9)]
        [TestCase(0, 0, 0)]
        public void TestSolveGivenWrongArgumentsThrowsException(double x, double y, double z)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { QuadraticEquation.Solve(x, y, z); });
        }

    }

    public class CubicEquationTests
    {

    }
}