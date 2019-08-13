using System;

namespace Ranges
{
    class Program
    {
        public static void PrintNums(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }

            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            var nums = new int[]
            {
                      // index from start    index from end
                0,    // 0                   ^9
                1,    // 1                   ^8
                2,    // 2                   ^7
                3,    // 3                   ^6
                4,    // 4                   ^5
                5,    // 5                   ^4
                6,    // 6                   ^3
                7,    // 7                   ^2
                8     // 8                   ^1
            };        // 9 (or words.Length) ^0

            #region Range 1..4
            Range range1 = 1..4;
            int[] slice1 = nums[1..4];

            Console.WriteLine("Range 1..4");
            PrintNums(slice1); // => 1, 2, 3
            #endregion

            #region Range 1..^3
            Range range2 = 1..^3;
            int[] slice2 = nums[1..^3];

            Console.WriteLine("Range 1..^3");
            PrintNums(slice2); // => 1, 2, 3, 4, 5
            #endregion

            #region Index
            Index index1 = 4;
            Index index2 = ^3;

            int num1 = nums[4];
            int num2 = nums[^3];

            Console.WriteLine($"Using index from start: {nameof(num1)}: {num1}"); // => 4
            Console.WriteLine($"Using index from end: {nameof(num2)}: {num2}"); // => 6
            Console.WriteLine();
            #endregion

            #region [First..Last]
            Index first = 0;
            Index last = ^0;
            int[] allNums1 = nums[first..last];

            Console.WriteLine("Printing nums from first to last using Indexes");
            PrintNums(allNums1); // => 0, 1, 2, 3, 4, 5, 6, 7, 8
            #endregion

            #region Open ended ranges
            var allNums2 = nums[..]; 
            Console.WriteLine("Open ended: all nums");
            PrintNums(allNums2); // => 0, 1, 2, 3, 4, 5, 6, 7, 8

            var first4Nums = nums[..4];
            Console.WriteLine("Open ended: first 4 nums");
            PrintNums(first4Nums); // => 0, 1, 2, 3

            var last3Nums = nums[6..];
            Console.WriteLine("Open enede: last 3 nums");
            PrintNums(last3Nums); // => 6, 7, 8
            #endregion
        }
    }
}
