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
                var tmpMotion = new RandomMotionFactory();
                var motionType = MotionType.UniformMotion;
                switch (chosenMotionType)
                {
                    case 0:
                        motionType = MotionType.UniformMotion;
                        break;
                    case 1:
                        motionType = MotionType.UniformAccelMotion;
                        break;
                    case 2:
                        motionType = MotionType.OscilMotion;
                        break;
                    default:
                        Console.WriteLine("Unknown type of motion.");
                        break;
                }

                motionList.Add(tmpMotion.GetInstance(motionType));
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

            ActionHandler(actionMotionType, "Motion type");

            var actionUniformMotion = new List<(Action, string)>
            {
                (new Action(() =>
                {
                    UniformMotion uniformMotion =
                            (UniformMotion)motionObject;
                    uniformMotion.Speed =
                        double.Parse(Console.ReadLine());
                }), "Speed"),

                (new Action(() =>
                {
                    UniformMotion uniformMotion =
                            (UniformMotion)motionObject;
                    uniformMotion.InitCoordinate =
                        double.Parse(Console.ReadLine());
                }), "InitCoordinate"),

                (new Action(() =>
                {
                    UniformMotion uniformMotion =
                            (UniformMotion)motionObject;
                    uniformMotion.Time =
                        double.Parse(Console.ReadLine());
                }), "Time")
            };

            var actionUniformAccelMotion = new List<(Action, string)>
            {
                (new Action(() =>
                {
                    UniformAccelMotion uniformMotion =
                            (UniformAccelMotion)motionObject;
                    uniformMotion.Speed =
                        double.Parse(Console.ReadLine());
                }), "Speed"),

                (new Action(() =>
                {
                    UniformAccelMotion uniformMotion =
                            (UniformAccelMotion)motionObject;
                    uniformMotion.InitCoordinate =
                        double.Parse(Console.ReadLine());
                }), "InitCoordinate"),

                (new Action(() =>
                {
                    UniformAccelMotion uniformMotion =
                            (UniformAccelMotion)motionObject;
                    uniformMotion.Acceleration =
                        double.Parse(Console.ReadLine());
                }), "Acceleration"),

                (new Action(() =>
                {
                    UniformAccelMotion uniformMotion =
                            (UniformAccelMotion)motionObject;
                    uniformMotion.Time =
                        double.Parse(Console.ReadLine());
                }), "Time")
            };

            var actionOscilMotion = new List<(Action, string)>
            {
                (new Action(() =>
                {
                    OscilMotion uniformMotion =
                            (OscilMotion)motionObject;
                    uniformMotion.Amplitude =
                        double.Parse(Console.ReadLine());
                }), "Amplitude"),

                (new Action(() =>
                {
                    OscilMotion uniformMotion =
                            (OscilMotion)motionObject;
                    uniformMotion.CyclFrequency =
                        double.Parse(Console.ReadLine());
                }), "CyclFrequency"),

                (new Action(() =>
                {
                    OscilMotion uniformMotion =
                            (OscilMotion)motionObject;
                    uniformMotion.InitPhase =
                        double.Parse(Console.ReadLine());
                }), "InitPhase"),

                (new Action(() =>
                {
                    OscilMotion uniformMotion =
                            (OscilMotion)motionObject;
                    uniformMotion.Time =
                        double.Parse(Console.ReadLine());
                }), "Time")
            };

            var actionDictionary = new Dictionary
                <Type, List<(Action, string)>>
            {
                {typeof(UniformMotion), actionUniformMotion },
                {typeof(UniformAccelMotion), actionUniformAccelMotion },
                {typeof(OscilMotion), actionOscilMotion },
            };

            var tmpActionsCollection = actionDictionary
                [motionObject.GetType()];
            foreach (var action in tmpActionsCollection)
            {
                ActionHandler(action.Item1, action.Item2);
            }

            Console.Write($"Coordinate value: " +
                $"{motionObject.Coordinate}");

            _ = Console.ReadKey();

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
                    Console.Write($"Enter the {propertyName} value: ");
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
