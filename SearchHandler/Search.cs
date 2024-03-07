namespace SearchHandler;

public static class Search
{
    private static int _recursiveComparisons = 0;
    
    public static long BinarySearch(List<long> inputList, long searchValue, out int comparisons)
    {
        var firstVal = 0;
        var lastVal = inputList.Count - 1;
        comparisons = 0;

        var found = false;
        var moreToSearch = firstVal <= lastVal;

        while (moreToSearch && !found)
        {
            comparisons++;

            var midPoint = (firstVal + lastVal) / 2;

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

        if (found)
        {
            return inputList[(firstVal + lastVal) / 2];
        }
        else
        {
            return -1;
        }
    }


    public static long ForgetfulBinarySearch(List<long> list, long item, out int comparisons)
    {
        var first = 0;
        var last = list.Count - 1;
        comparisons = 0; // Initialize comparisons counter

        while (first < last)
        {
            var midPoint = (first + last) / 2;
            comparisons++; // Increment comparisons counter

            if (item > list[midPoint])
                first = midPoint + 1;
            else
                last = midPoint;
        }

        if (last == -1)
        {
            return -1;
        }

        if (item == list[first])
        {
            return list[first];
        }

        return -1;
    }



    public static long RecognisingEqualityBinarySearch(List<long> inputList, long searchValue, out int comparisons)
    {
        comparisons = 0;

        var left = 0;
        var right = inputList.Count - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            comparisons++;

            if (inputList[mid] == searchValue)
            {
                return inputList[mid];
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

        // If the loop exits without finding the search value, return -1
        return -1;
    }
 
    public static (int index, int comparisons) RecursiveBinary(List<long> list, int left, int right, long target)
    {
        int comp = 0;
        if (right >= left)
        {
            int mid = left + (right - left) / 2;
            _recursiveComparisons++; // Increment count for the comparison made in this step
            if (list[mid] == target)
            {
                comp = _recursiveComparisons;
                _recursiveComparisons = 0;
                return (mid, comp); // Return the index where target was found and the number of comparisons
            }
            if (list[mid] > target)
            {
                var result = RecursiveBinary(list, left, mid - 1, target);
                return (result.index, _recursiveComparisons); // Return the index found or -1 if nothing found and the total number of comparisons
            }
            var result2 = RecursiveBinary(list, mid + 1, right, target);
            return (result2.index, _recursiveComparisons); // Return the index found or -1 if nothing found and the total number of comparisons
        }

        comp = _recursiveComparisons;
        _recursiveComparisons = 0;
        return (-1, comp); // Return -1 if target is not found and the number of comparisons
    }

    
    /*public static int RecursiveBinary(List<long> list, int left, int right, long target)
    {
        var comp = 0;
        if (right >= left)
        {
            var mid = left + (right - left) / 2;
            _recursiveComparisons++; // Increment count for the comparison made in this step
            if (list[mid] == target)
            {
                comp = _recursiveComparisons;
                _recursiveComparisons = 0;
                return comp;
            }
            if (list[mid] > target)
                return RecursiveBinary(list, left, mid - 1, target) + 1; // Increment count for current comparison
            return RecursiveBinary(list, mid + 1, right, target) + 1; // Increment count for current comparison
        }

        comp = _recursiveComparisons;
        _recursiveComparisons = 0;
        return comp; // Return the count of comparisons made
    }
    
}*/
}