/* This code is made by Anneshu Nag, Student ID- 2210994760  */
/*                    Dated- 27/09/2023                      */

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace BoxOfCoins
{
    public class BoxOfCoins
    {
       public static int Solve(int[] boxes)
        {
             // Finding the total sum of all box values
            int totalSum = 0; 
            for(int i = 0; i <= boxes.Length - 1; i++)
            {
                totalSum += boxes[i];
            }  

            // Finding the sum that Alex will get
            int sumAlex = AlexSum(boxes, boxes.Length); 
            
            // Finding Cindy's sum using Alex's
            int sumCindy = totalSum - sumAlex; 

            // Resultant sum i.e., Alex Sum - Cindy Sum
            int resultSum = sumAlex - sumCindy;  
            return resultSum;
        }

        // Private method needed to find Alex's sum
        private static int AlexSum(int[] boxes, int noOfBoxes) 
        {
            // Table to store the maximum sum for Alex in different scenarios
            int[,] tableSum = new int[noOfBoxes, noOfBoxes]; 

            for(int i = 1; i <= noOfBoxes; i++)   // To loop over the subarrays
            {
                for(int startIdx = 0; startIdx <= noOfBoxes - i; startIdx++)
                {
                    int endIdx = i - 1 + startIdx; // Represents the end index
                    int sumAtLeftBox, sumAfterSkippingOneBox, sumAfterSkippingTwoBox;
                    
                    // Maximum sum if Alex chooses the left box (opponent will get)
                    if (startIdx + 1 < noOfBoxes && endIdx - 1 >= 0) 
                        sumAtLeftBox = tableSum[startIdx + 1, endIdx - 1];

                    else
                        sumAtLeftBox = 0;
                    
                    // Maximum sum if Alex chooses the right box, skipping one box on the left 
                    if (startIdx + 2 < noOfBoxes) 
                        sumAfterSkippingOneBox = tableSum[startIdx + 2, endIdx];

                    else
                        sumAfterSkippingOneBox = 0;

                    // Maximum sum if Alex chooses the right box, skipping two boxes on the left (before endIdx i.e. 2 left of last)
                    if (endIdx - 2 >= 0) 
                        sumAfterSkippingTwoBox = tableSum[startIdx,endIdx-2];

                    else
                        sumAfterSkippingTwoBox = 0;

                    // The maximum sum Alex can achieve
                    tableSum[startIdx, endIdx] = Math.Max(boxes[startIdx] + Math.Min(sumAtLeftBox, sumAfterSkippingOneBox) , boxes[endIdx] + Math.Min(sumAtLeftBox, sumAfterSkippingTwoBox)); 
                }
            }
            // Maximum sum that Alex can achieve when all boxes are in tableSum[0, noOfBoxes-1]
            return tableSum[0, noOfBoxes - 1]; 
        }
    }
}

/* ------------------------------------------------------------My Output-----------------------------------------------------------------
Attempting test instance 0 with [7, 2] as the argument and 5 as the expected answer
 :: SUCCESS

Attempting test instance 1 with [2, 7, 3] as the argument and -2 as the expected answer
 :: SUCCESS

Attempting test instance 2 with [1000, 1000, 1000, 1000, 1000] as the argument and 1000 as the expected answer
 :: SUCCESS

Attempting test instance 3 with [823, 912, 345, 100000, 867, 222, 991, 3, 40000] as the argument and -58111 as the expected answer
 :: SUCCESS

Attempting test instance 4 with [23, 35, 12, 100000, 99234, 86123, 3245] as the argument and -83644 as the expected answer
 :: SUCCESS

Attempting test instance 5 with [23, 35, 12, 100000, 99234, 86123, 3245, 1] as the argument and 83645 as the expected answer
 :: SUCCESS

Attempting test instance 6 with [7, 7, 7, 7, 7, 7, 80, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7] as the argument and -66 as the expected answer
 :: SUCCESS

Attempting test instance 7 with [7, 7, 7, 7, 7, 7, 7, 80, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7] as the argument and 73 as the expected answer
 :: SUCCESS

Attempting test instance 8 with [91, 56, 23, 45, 87, 65, 45, 45, 78, 23, 20, 41, 17, 54, 51, 51, 94, 62, 74, 42, 76, 76] as the argument and 96 as the expected answer
 :: SUCCESS

Attempting test instance 9 with [92834, 95461, 15911, 56189, 6369, 80545, 31811, 51263, 30076, 68867, 36905, 32499, 59799, 334, 82991, 46636, 98741, 66601] as the argument and 42958 as the expected answer
 :: SUCCESS

Attempting test instance 10 with [129] as the argument and 129 as the expected answer
 :: SUCCESS

Attempting test instance 11 with [35463, 88121, 4362, 94457, 86235, 83680, 72686, 6003, 93069, 2015, 10436, 2139, 93162, 30380, 19067, 76335, 78941, 48620, 55887, 15679] as the argument and 101879 as the expected answer
 :: SUCCESS

Attempting test instance 12 with [19335, 97643, 11468, 86267, 79718, 59584, 12129, 52642, 86575, 62307, 11545, 52658, 72377, 39986, 74850, 1992, 86928] as the argument and 1846 as the expected answer
 :: SUCCESS

Attempting test instance 13 with [91883, 97793, 54567, 64714, 98624] as the argument and 82567 as the expected answer
 :: SUCCESS

Attempting test instance 14 with [98473, 41866, 71129, 65936, 42626, 9194, 46718, 96921, 45613, 47677, 8763, 54634, 47259, 71448, 9918, 22666, 32711, 21692, 40207, 2017, 23040, 86083, 77809, 15472, 30718, 39085, 87911, 54827, 41686, 28354, 37203, 6548, 74184, 3043, 43961, 95189, 1238, 22002, 93507, 63546, 32527, 42778, 31614] as the argument and -14953 as the expected answer
 :: SUCCESS

Attempting test instance 15 with [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50] as the argument and 25 as the expected answer
 :: SUCCESS

Attempting test instance 16 with [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1] as the argument and 0 as the expected answer
 :: SUCCESS

Attempting test instance 17 with [1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 11, 11, 11, 11, 111, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 112, 312, 312, 123, 123, 123, 123, 123, 123, 123, 123, 123, 123, 123, 123, 123, 123, 231, 31, 312] as the argument and 316 as the expected answer
 :: SUCCESS

Attempting test instance 18 with [1234, 1233, 12, 312, 32, 23, 434, 12, 312, 45, 1234, 1233, 12, 312, 32, 23, 434, 12, 312, 45, 1234, 1233, 12, 312, 32, 23, 434, 12, 312, 45, 1234, 1233, 12, 312, 32, 23, 434, 12, 312, 45, 1234, 1233, 12, 312, 32, 23, 434, 12, 312, 45] as the argument and 1995 as the expected answer
 :: SUCCESS

Attempting test instance 19 with [1, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3] as the argument and 1 as the expected answer
 :: SUCCESS

Attempting test instance 20 with [9, 100, 1, 8] as the argument and 98 as the expected answer
 :: SUCCESS

Attempting test instance 21 with [1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 66, 5, 4, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 6, 5, 4, 5, 6, 3, 4, 4, 5, 6, 3, 4, 5, 6, 3, 4, 5, 6, 3, 4, 5, 6, 3, 4, 5, 6] as the argument and 68 as the expected answer
 :: SUCCESS

Attempting test instance 22 with [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 1, 2, 3, 4, 65, 67, 2, 3, 4, 7, 2, 3, 4, 6, 6, 7, 2, 3, 4, 7, 78, 8, 82, 2, 3, 4, 7, 2, 2, 34, 4, 6, 7, 3, 2] as the argument and 128 as the expected answer
 :: SUCCESS

Attempting test instance 23 with [100, 10, 10] as the argument and 100 as the expected answer
 :: SUCCESS

Attempting test instance 24 with [1] as the argument and 1 as the expected answer
 :: SUCCESS

Attempting test instance 25 with [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 2, 4, 3, 5, 4, 6, 7, 5, 6, 10, 2, 5, 4, 3, 4, 5, 6, 7, 9, 10] as the argument and 28 as the expected answer
 :: SUCCESS

Attempting test instance 26 with [6, 4, 3, 5, 8, 8] as the argument and 2 as the expected answer
 :: SUCCESS

Attempting test instance 27 with [1, 5, 20, 2, 1] as the argument and -13 as the expected answer
 :: SUCCESS

Attempting test instance 28 with [1, 2, 3, 4, 5, 6, 6, 7, 8, 767, 765, 111, 76576, 5, 64, 654, 64, 7, 7657, 76575, 64, 65, 6454, 64, 654, 65464, 7, 5435, 65, 746, 7, 546, 7, 654, 7, 5435, 547, 6, 6, 7, 6547, 7654, 6, 754, 54353, 65, 7, 8] as the argument and 118231 as the expected answer
 :: SUCCESS

Summary: 29 tests out of 29 passed
Tests passed (0 to 29): 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28
Tests failed (0 to 29): none */