namespace SearchHandler;

public static class Search
{
    private static int recursiveComparisons = 0;
    
    public static int BinarySearch(List<long> inputList, long searchValue)
    {
        int midPoint;
        var firstVal = 0;
        var lastVal = inputList.Count - 1;
        var comparisons = 0;
        
        var found = false;
        var moreToSearch = firstVal <= lastVal;

        while (moreToSearch && !found)
        {
            comparisons++;
            
            midPoint = (firstVal + lastVal) / 2;

            if (searchValue < inputList[midPoint])
            {
                lastVal = midPoint - 1;
                moreToSearch = firstVal <= lastVal;
            }
            else if (searchValue > inputList[midPoint])
            {
                firstVal = midPoint + 1;
                moreToSearch = firstVal <= lastVal;
            }
            else
            {
                found = true;
            }
        }

        return comparisons;
    }

    public static int ForgetfulBinarySearch(List<long> inputList, long searchValue)
    {
        var left = 0;
        var right = inputList.Count - 1;
        var comparisons = 0;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            comparisons++;

            if (inputList[mid] == searchValue)
            {
                return comparisons;
            }

            if (inputList[mid] < searchValue)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }

            var forgetIndex = mid - (int)Math.Sqrt(right - left + 1);
            if (forgetIndex >= left && forgetIndex <= right)
            {
                left = forgetIndex + 1;
            }
        }

        return -1;
    }

    public static int RecognisingEqualityBinarySearch(List<long> inputList, long searchValue)
    {
        var comparisons = 0;

        var left = 0;
        var right = inputList.Count - 1;

        while (left <= right)
        {

            var mid = left + (right - left) / 2;

            comparisons++;

            if (inputList[mid] == searchValue)
            {
                return comparisons;
            }
            
            if (inputList[mid] < searchValue)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }
    
    public static int RecursiveBinary(List<long> list, int left, int right, long target)
    {
        var comp = 0;
        if (right >= left)
        {
            var mid = left + (right - left) / 2;
            recursiveComparisons++; // Increment count for the comparison made in this step
            if (list[mid] == target)
            {
                comp = recursiveComparisons;
                recursiveComparisons = 0;
                return comp;
            }
            if (list[mid] > target)
                return RecursiveBinary(list, left, mid - 1, target) + 1; // Increment count for current comparison
            return RecursiveBinary(list, mid + 1, right, target) + 1; // Increment count for current comparison
        }

        comp = recursiveComparisons;
        recursiveComparisons = 0;
        return comp; // Return the count of comparisons made
    }
    
}