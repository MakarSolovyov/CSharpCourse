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

            Console.WriteLine("Let's fill the list with objects.\n");
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

            _ = Console.ReadKey();

            Console.WriteLine("Print the information about objects.\n");
            foreach (var tmpMotion in motionList)
            {
                Console.WriteLine(tmpMotion.Info);
                Console.WriteLine();
            }

            _ = Console.ReadKey();

            Console.WriteLine("Calculate coordinate.\n");
            foreach (var tmpMotion in motionList)
            {
                Console.WriteLine($"Motion type : {tmpMotion.GetType()}.\n" +
                    $"Coordinate = {tmpMotion.Coordinate}.\n");
                Console.WriteLine();
            }

            _ = Console.ReadKey();

            /*Console.Write($"Coordinate value: " +
                $"{uniformMotion.Coordinate}");*/

            Console.WriteLine("Choose the motion type and input" +
                " values to calculate coordinate.");

            MotionBase motionObject = new UniformMotion();

            Action actionMotionType = new Action(() =>
            {
                Console.WriteLine("1 - uniform motion,\n" +
                "2 - uniformly accelerated motion,\n" +
                "3 - oscillating motion.");
                Console.Write("Chosen motion type: ");

                int motionType = int.Parse(Console.ReadLine());

                switch (motionType)
                {
                    case 1:
                        {
                            motionObject = new UniformMotion();
                            break;
                        }

                    case 2:
                        {
                            motionObject = new UniformAccelMotion();
                            break;
                        }

                    case 3:
                        {
                            motionObject = new OscilMotion();
                            break;
                        }

                    default:
                        {
                            throw new ArgumentException
                                ("Please, enter only designated digits.");
                        }
                }
            });

            ActionHandler(actionMotionType, "Motion");

            var actionUniformMotion = new List<(Action, string)>
            {
                (new Action(() =>
                {
                    UniformMotion uniformMotion =
                            (UniformMotion)motionObject;
                    Console.Write("Enter the speed value: ");
                    uniformMotion.Speed =
                        double.Parse(Console.ReadLine());
                }), "UniformMotion : Speed"),

                (new Action(() =>
                {
                    UniformMotion uniformMotion =
                            (UniformMotion)motionObject;
                    Console.Write("Enter the initial coordinate" +
                            " value: ");
                    uniformMotion.InitCoordinate =
                        double.Parse(Console.ReadLine());
                }), "UniformMotion : InitCoordinate"),

                (new Action(() =>
                {
                    UniformMotion uniformMotion =
                            (UniformMotion)motionObject;
                    Console.Write("Enter the time value: ");
                    uniformMotion.Time =
                        double.Parse(Console.ReadLine());
                }), "UniformMotion : Time")
            };

            var actionUniformAccelMotion = new List<(Action, string)>
            {
                (new Action(() =>
                {
                    UniformAccelMotion uniformMotion =
                            (UniformAccelMotion)motionObject;
                    Console.Write("Enter the speed value: ");
                    uniformMotion.Speed =
                        double.Parse(Console.ReadLine());
                }), "UniformAccelMotion : Speed"),

                (new Action(() =>
                {
                    UniformAccelMotion uniformMotion =
                            (UniformAccelMotion)motionObject;
                    Console.Write("Enter the initial coordinate" +
                            " value: ");
                    uniformMotion.InitCoordinate =
                        double.Parse(Console.ReadLine());
                }), "UniformAccelMotion : InitCoordinate"),

                (new Action(() =>
                {
                    UniformAccelMotion uniformMotion =
                            (UniformAccelMotion)motionObject;
                    Console.Write("Enter the acceleration" +
                            " value: ");
                    uniformMotion.Acceleration =
                        double.Parse(Console.ReadLine());
                }), "UniformAccelMotion : Acceleration"),

                (new Action(() =>
                {
                    UniformAccelMotion uniformMotion =
                            (UniformAccelMotion)motionObject;
                    Console.Write("Enter the time value: ");
                    uniformMotion.Time =
                        double.Parse(Console.ReadLine());
                }), "UniformAccelMotion : Time")
            };

            var actionOscilMotion = new List<(Action, string)>
            {
                (new Action(() =>
                {
                    OscilMotion uniformMotion =
                            (OscilMotion)motionObject;
                    Console.Write("Enter the amplitude value: ");
                    uniformMotion.Amplitude =
                        double.Parse(Console.ReadLine());
                }), "OscilMotion : Speed"),

                (new Action(() =>
                {
                    OscilMotion uniformMotion =
                            (OscilMotion)motionObject;
                    Console.Write("Enter the cyclic frequency" +
                            " value: ");
                    uniformMotion.CyclFrequency =
                        double.Parse(Console.ReadLine());
                }), "OscilMotion : InitCoordinate"),

                (new Action(() =>
                {
                    OscilMotion uniformMotion =
                            (OscilMotion)motionObject;
                    Console.Write("Enter the initial phase" +
                            " value: ");
                    uniformMotion.InitPhase =
                        double.Parse(Console.ReadLine());
                }), "OscilMotion : Acceleration"),

                (new Action(() =>
                {
                    OscilMotion uniformMotion =
                            (OscilMotion)motionObject;
                    Console.Write("Enter the time value: ");
                    uniformMotion.Time =
                        double.Parse(Console.ReadLine());
                }), "OscilMotion : Time")
            };

            switch (motionObject)
            {
                case UniformMotion:
                    {
                        foreach (var action in actionUniformMotion)
                        {
                            ActionHandler(action.Item1, action.Item2);
                        }

                        Console.Write($"Coordinate value: " +
                            $"{motionObject.Coordinate}");

                        _ = Console.ReadKey();

                        break;
                    }

                case UniformAccelMotion:
                    {
                        foreach (var action in actionUniformAccelMotion)
                        {
                            ActionHandler(action.Item1, action.Item2);
                        }

                        Console.Write($"Coordinate value: " +
                            $"{motionObject.Coordinate}");

                        _ = Console.ReadKey();

                        break;
                    }

                case OscilMotion:
                    {
                        foreach (var action in actionOscilMotion)
                        {
                            ActionHandler(action.Item1, action.Item2);
                        }

                        Console.Write($"Coordinate value: " +
                            $"{motionObject.Coordinate}");

                        _ = Console.ReadKey();

                        break;
                    }

                default:
                    break;
            }
        }

        /// <summary>
        /// Method which is used for doing actions from the list.
        /// </summary>
        /// <param name="action">A certain action.</param>
        /// <param name="propertyName">Additional parameter
        /// for exception.</param>
        private static void ActionHandler
            (Action action, string propertyName)
        {

            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception exception)
                {
                    if (exception.GetType()
                        == typeof(ArgumentOutOfRangeException)
                        || exception.GetType() == typeof(FormatException)
                        || exception.GetType() == typeof(ArgumentException))
                    {
                        Console.WriteLine($"Incorrect info in " +
                            $"{propertyName}." +
                        $" Error: {exception.Message}");
                    }
                    else
                    {
                        throw exception;
                    }
                }
            }
        }
    }
}
