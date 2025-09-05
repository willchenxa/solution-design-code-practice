using Result.LargestRectangle;
/************* Largest Rectangle *************/
//Time Complexity: O(n) - Each element is processed exactly twice (once for left pass, once for right pass)

// Space Complexity: O(n) - Two arrays of size n (leftSmaller, rightSmaller) and a stack that can grow up to size n

int n = Convert.ToInt32(Console.ReadLine().Trim());

List<int> h = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(hTemp => Convert.ToInt32(hTemp)).ToList();

long result = LargestRectangle.largestRectangle(h);

Console.WriteLine(result);
Console.Clear();
/************* Largest Rectangle *************/

