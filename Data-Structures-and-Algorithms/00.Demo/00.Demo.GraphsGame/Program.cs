namespace _00.Demo.GraphsGame
{
    public class Program
    {
        public static int GetSeed()
        {
            Random seedRandom = new Random();
            int seed = seedRandom.Next(0, int.MaxValue);
            return seed;
        }

        public static void Main(string[] args)
        {
            int seed = GetSeed();
            Console.WriteLine($"Seed: {seed}");
            Random random = new Random(seed);

            RandomLocationGenerator generator = new RandomLocationGenerator();
            Graph graph = new Graph();

            int initialTownsCount = random.Next(2, 5);
            List<string> initialTowns = generator.GetRandomLocations(initialTownsCount);

            for (int i = 0; i < initialTowns.Count; i++)
            {
                graph.AddNode(initialTowns[i], 0);

                if(i > 0)
                {
                    int distance = random.Next(10, 1000);
                    graph.AddEdge(initialTowns[0], initialTowns[i], distance);
                    graph.AddEdge(initialTowns[i], initialTowns[0], distance);
                }
            }

            string inputLine = string.Empty;
            string currentLocation = initialTowns[0];

            while((inputLine = Console.ReadLine()) != "Exit")
            {
                string[] inputParams = inputLine.Split("|");

                switch(inputParams[0])
                {
                    case "Check":
                        if (graph.GetChildren(currentLocation).Count == 1)
                        {
                            int generatedTownsCount = random.Next(3, 5);
                            List<string> generatedTowns = generator.GetRandomLocations(generatedTownsCount);

                            for (int i = 0; i < generatedTowns.Count; i++)
                            {
                                int distance = random.Next(10, 1000);
                                int flag = random.Next(graph.GetNode(currentLocation).Flag, 10);
                                graph.AddNode(generatedTowns[i], flag);
                                graph.AddEdge(currentLocation, generatedTowns[i], distance);
                                graph.AddEdge(generatedTowns[i], currentLocation, distance);
                            }
                        }

                        Console.WriteLine($"Curreent Location: {currentLocation}");
                        Console.WriteLine($"Adjacent Locations: ");
                        
                        foreach (var item in graph.GetChildren(currentLocation))
                        {
                            if(graph.GetNode(item.Key).Flag >= 0 && graph.GetNode(item.Key).Flag <= 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else if(graph.GetNode(item.Key).Flag >= 3 && graph.GetNode(item.Key).Flag <= 4)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            }
                            else if (graph.GetNode(item.Key).Flag >= 5 && graph.GetNode(item.Key).Flag <= 10)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }

                            Console.WriteLine($"* {item.Key} ({item.Value}km)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                        break;
                    case "Travel":
                        string targetLocation = inputParams[1];
                        
                        if(!graph.GetChildren(currentLocation).ContainsKey(targetLocation))
                        {
                            Console.WriteLine("Target location not found in the vicinity...");
                        }
                        else
                        {
                            currentLocation = targetLocation;
                            Console.WriteLine($"Travelled to: {currentLocation}");

                            if(graph.GetNode(currentLocation).Flag >= 7 && graph.GetNode(currentLocation).Flag <= 10)
                            {
                                Console.WriteLine("You died...");
                                return;
                            }
                        }

                        break;
                    case "Clear":
                        Console.Clear();
                        Console.WriteLine($"Seed: {seed}");
                        break;
                    case "Locations":
                        Console.WriteLine($"All Locations - {graph.Locations.Count}:");

                        foreach (var item in graph.Locations)
                        {
                            Console.WriteLine($"{item.Key} -> {string.Join(", ", item.Value.Children.Keys)}");
                        }

                        break;
                }
            }
        }
    }
}
