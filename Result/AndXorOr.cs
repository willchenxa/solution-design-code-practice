namespace Result.AndXorOr;

class AndXorOr
{

    /*
     * Complete the 'andXorOr' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static int andXorOr(List<int> a)
    {
        int maxResult = 0;
        Stack<int> stack = new Stack<int>();

        foreach (int num in a)
        {
            while (stack.Count > 0)
            {
                int top = stack.Peek();
                int value = ((top & num) ^ (top | num)) & (top ^ num);
                maxResult = Math.Max(maxResult, value);

                if (num < top)
                    stack.Pop();
                else
                    break;
            }
            stack.Push(num);
        }

        return maxResult;
    }
}
