namespace Result.Pestcide;

public class Pesticide
{
    public static int Solve(int[] pesticides)
    {
        int n = pesticides.Length;
        Stack<int> stack = new Stack<int>();
        int maxDays = 0;

        // Array to store the number of days after which each plant dies
        int[] daysToDie = new int[n];

        for (int i = 0; i < n; i++)
        {
            int currentDays = 0;

            // While current plant has more pesticide than the one on stack top
            while (stack.Count > 0 && pesticides[stack.Peek()] >= pesticides[i])
            {
                // The current plant might kill plants to its left over multiple days
                currentDays = Math.Max(currentDays, daysToDie[stack.Pop()]);
            }

            // If there's still a plant to the left, current plant will die
            if (stack.Count > 0)
            {
                daysToDie[i] = currentDays + 1;
                maxDays = Math.Max(maxDays, daysToDie[i]);
            }
            else
            {
                daysToDie[i] = 0; // This plant survives (no left neighbor)
            }

            stack.Push(i);
        }

        return maxDays;
    }
}

// Alternative approach using linked list (more intuitive but less efficient)
public class AlternativeSolution
{
    public static int SolveWithSimulation(int[] pesticides)
    {
        List<int> plants = new List<int>(pesticides);
        int days = 0;
        bool plantsDied;

        do
        {
            plantsDied = false;
            List<int> survivors = new List<int> { plants[0] };

            for (int i = 1; i < plants.Count; i++)
            {
                if (plants[i] <= plants[i - 1])
                {
                    survivors.Add(plants[i]);
                }
                else
                {
                    plantsDied = true;
                }
            }

            if (plantsDied)
            {
                days++;
                plants = survivors;
            }

        } while (plantsDied);

        return days;
    }
}

// Test program
public class Program
{
    public static void Main()
    {
        // Test cases
        int[] test1 = { 6, 5, 8, 4, 7, 10, 9 };
        int[] test2 = { 3, 6, 2, 7, 5 };
        int[] test3 = { 4, 3, 7, 5, 6, 4, 2 };

        Console.WriteLine($"Test 1: {Solution.Solve(test1)}"); // Expected: 2
        Console.WriteLine($"Test 2: {Solution.Solve(test2)}"); // Expected: 2
        Console.WriteLine($"Test 3: {Solution.Solve(test3)}"); // Expected: 3

        // Verify with alternative approach
        Console.WriteLine($"\nVerification with simulation:");
        Console.WriteLine($"Test 1: {AlternativeSolution.SolveWithSimulation(test1)}");
        Console.WriteLine($"Test 2: {AlternativeSolution.SolveWithSimulation(test2)}");
        Console.WriteLine($"Test 3: {AlternativeSolution.SolveWithSimulation(test3)}");
    }
}