namespace Result.LargestRectangle;

public static class LargestRectangle
{

    /*
     * Complete the 'largestRectangle' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts INTEGER_ARRAY h as parameter.
     */

    public static long largestRectangle(List<int> h)
    {
        long result = 0;
        int n = h.Count;
        if (h.Count <= 0)
            return result;

        // for(int index = 0; index < h.Count; index ++)
        // {
        // int leftWidth = 0;
        // int rightWidth = 0;
        // for(int left = index -1; left >= 0; left --)
        // {
        //     if(h[left] >= h[index])
        //     {
        //         leftWidth ++;
        //     }
        //     else
        //     {
        //         break;
        //     }
        // }

        // for(int right = index + 1; right <  h.Count; right ++)
        // {
        //     if(h[right] >= h[index])
        //     {
        //         rightWidth ++;
        //     }
        //     else
        //     {
        //         break;
        //     }
        // }

        // int maxArea = h[index]*(rightWidth + leftWidth + 1);
        // result = Math.Max(result, maxArea);    
        //}

        int[] leftSmaller = new int[n];
        int[] rightSmaller = new int[n];
        Stack<int> stack = new Stack<int>();

        // Precompute left smaller indices
        for (int i = 0; i < n; i++)
        {
            // Pop until we find the first smaller element to the left
            while (stack.Count > 0 && h[stack.Peek()] >= h[i])
            {
                stack.Pop();
            }

            leftSmaller[i] = stack.Count == 0 ? -1 : stack.Peek();
            stack.Push(i);
        }

        // Clear the stack for the right pass
        stack.Clear();

        // Precompute right smaller indices
        for (int i = n - 1; i >= 0; i--)
        {
            // Pop until we find the first smaller element to the right
            while (stack.Count > 0 && h[stack.Peek()] >= h[i])
            {
                stack.Pop();
            }

            rightSmaller[i] = stack.Count == 0 ? n : stack.Peek();
            stack.Push(i);
        }

        // Calculate maximum area
        for (int i = 0; i < n; i++)
        {

            int width = rightSmaller[i] - leftSmaller[i] - 1;
            int area = h[i] * width;
            Console.WriteLine($"{i},{h[i]}, {rightSmaller[i]}, {leftSmaller[i]}, {area}");
            result = Math.Max(result, area);
        }

        return result;
    }

    public static long AlternateLargestRectangle(List<int> h)
    {
        int n = h.Count;
        Stack<int> stack = new Stack<int>();
        long maxArea = 0;
        int i = 0;

        while (i < n)
        {
            if (stack.Count == 0 || h[i] >= h[stack.Peek()])
            {
                stack.Push(i++);
            }
            else
            {
                int top = stack.Pop();
                long width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                long area = (long)h[top] * width;
                maxArea = Math.Max(maxArea, area);
            }
        }

        while (stack.Count > 0)
        {
            int top = stack.Pop();
            long width = stack.Count == 0 ? i : i - stack.Peek() - 1;
            long area = (long)h[top] * width;
            maxArea = Math.Max(maxArea, area);
        }

        return maxArea;
    }
}