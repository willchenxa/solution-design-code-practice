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

        if (a.Count <= 0)
            return maxResult;

        int index = 0;
        do
        {
            maxResult = Math.Max(cal(a[index], a[index + 1]), maxResult);
            //Console.WriteLine($"{maxResult}, {a[index]}, {a[index +1]}");
            index++;
        } while (index + 1 < a.Count);

        return maxResult;
    }

    private static int cal(int element, int nextElement)
    {
        return ((element & nextElement) ^ (element | nextElement)) & (element ^ nextElement);
    }
}
