using Model;

namespace ConsoleApp
{
    /// <summary>
    /// Class Program.
    /// </summary>
    public static class Program
    {
        private static void Main()
        {
            var motionList = new List<MotionBase>();
            var rnd = new Random();

            for (var i = 0; i < 10; i++)
            {
                var chosenMotionType = rnd.Next(3);
                switch (chosenMotionType)
                {
                    case 0:
                        motionList.Add(UniformMotion.GetRandomMotion());
                        break;
                    case 1:
                        motionList.Add(UniformAccelMotion.GetRandomMotion());
                        break;
                    case 2:
                        motionList.Add(OscilMotion.GetRandomMotion());
                        break;
                    default:
                        Console.WriteLine("Unknown type of motion.");
                        break;
                }
            }

            foreach (var tmpMotion in motionList)
            {
                Console.WriteLine(tmpMotion.Info);
                Console.WriteLine();
            }

            foreach (var tmpMotion in motionList)
            {
                Console.WriteLine($"Motion type :{tmpMotion.GetType()}.\n" +
                    $"Coordinate = {tmpMotion.Coordinate}.\n");
            }
        }
    }
}
