public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Plan:
        // 1. Create a new array of doubles with size 'length' to hold the results.
        // 2. Loop from i = 0 up to (but not including) 'length'.
        // 3. On each iteration, the next multiple is 'number' times (i + 1),
        //    since the first multiple (i = 0) should be 1x the number, the
        //    second multiple (i = 1) should be 2x the number, and so on.
        // 4. Store that multiple in the array at index i.
        // 5. After the loop finishes, return the completed array.

        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Plan:
        // 1. Figure out where the split point is. The last 'amount' items need to
        //    move to the front, so the split point is at index (data.Count - amount).
        // 2. Use GetRange to pull out the last 'amount' items (the "tail") into
        //    their own list, starting at the split point and going to the end.
        // 3. Remove those same items from the end of the original list, using
        //    RemoveRange starting at the split point.
        // 4. Insert the tail list back at the very beginning (index 0) of data
        //    using InsertRange, which pushes the remaining original items after it.
        // 5. Because we modified 'data' directly (not returning a new list),
        //    no return statement is needed.

        int splitIndex = data.Count - amount;
        List<int> tail = data.GetRange(splitIndex, amount);
        data.RemoveRange(splitIndex, amount);
        data.InsertRange(0, tail);
    }
}