/* This code is made by Anneshu Nag, Student ID- 2210994760*/
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

/* Overall documentation of the task */
/*  This is a variation of the coin change problem in DP
	This is task based on dynamic programming that uses Memoization and recusion with Dictionary 
    Here the larger value is computed using smaller values and ae stored in dictionary for later 
    use. If the vlaue has been computed once then it can be directly returned for future use 
    rather than computing it again and again.

    In this task, the sum is represented with the range of 1 and 10^18, also sum=0 is put down as
    the base case to compute sum = 2.

    Coming to the scenarios:
    1. Return 1 if the sum is 0 or 1
    2. For even number we will be adding number of combinations for sum / 2 & sum / 2 - 1 (using dp)
    3. For odd number we will be adding sum - 1 / 2 

	Ref= https://youtu.be/L27_JpN6Z1Q?si=mCCU3Dre5xOJfa1h 
	*/

namespace CoinRepresentation
{
    /* Provided the summary here as there is not document type sumission available */
    /*                                SUMMARY                                      */
	/*     Class Coin Representation has a Dictionary and a method for solving
          problem of representing a value SUM, a long integer between 1 and 10^18 
         using special coins of value 2^0, 2^1, ..., 2^k, with each value having 
                            exactly 2 coins; For example:
	        Input: SUM = 1, return 1 as only possible combination is {1}.
	        Input SUM = 2, return 2 as possible combinations are {1,1}, {2}.
	        Input SUM = 4, return 3 as possible combinations are {1,1,2}, {2,2}, {4}. */
    public class CoinRepresentation
    {
		// The Dictionary namely mainDictionary store the key-value pairs generated with in the method//
		private static Dictionary<long, long> mainDictionay = new Dictionary<long,long>();
		public static long Solve(long sum)
		{
			// Base cases
			if (sum == 0 || sum == 1)
			{
				return 1;
			}
			// If already recorded in dictionary, just return the value with specified key
			if (mainDictionay.ContainsKey(sum))
			{
				return mainDictionay[sum];
			}
			// If not, add it to the dictionary and return
			else
            {
				// Handle case of even number
				if (sum % 2 is 0)
				{
					mainDictionay.Add(sum, Solve(sum / 2) + Solve(sum / 2 - 1));
				}
				// Handle case of odd number
				else
				{
					mainDictionay.Add(sum, Solve((sum - 1) / 2));
				}
				return mainDictionay[sum];
			}
		}
	}
}

/* ----- Discussing the Time Complexity -----
The overall time complexity of this  algorithm is reduced from taditional recusion based problems 
where the time complexity is  mostly n^2. Due the memoization of sum values each sum is only being 
considered once and their sum is stored in the table and when they are needed they are called directly
from the dictionary. Coming to sum, for each new sum if they are even then they are recursivley called twice
and if they are odd then they are recursively called only once.

Overall what's happening is that the sum after calling a new sum recursively in already present in the dictionary
so it is taken directly from there and then used. This makes the overall time complexity near about O ((sum)log(sum))
as with each call the sum is effectively halved.*/


/* --------------------------------------------My Output-------------------------------------------------
Attempting test instance 0 with 1 as the argument and 1 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0013544)

Attempting test instance 1 with 6 as the argument and 3 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0095518)

Attempting test instance 2 with 47 as the argument and 2 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0013552)

Attempting test instance 3 with 256 as the argument and 9 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000124)

Attempting test instance 4 with 8489289 as the argument and 6853 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000530)

Attempting test instance 5 with 1000000000 as the argument and 73411 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000457)

Attempting test instance 6 with 100 as the argument and 19 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000069)

Attempting test instance 7 with 128 as the argument and 8 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000018)

Attempting test instance 8 with 1073741824 as the argument and 31 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000500)

Attempting test instance 9 with 6370 as the argument and 175 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000148)

Attempting test instance 10 with 10 as the argument and 5 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000041)

Attempting test instance 11 with 2 as the argument and 2 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000019)

Attempting test instance 12 with 3 as the argument and 1 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000019)

Attempting test instance 13 with 4 as the argument and 3 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000018)

Attempting test instance 14 with 2000000000 as the argument and 81034 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000053)

Attempting test instance 15 with 999999999 as the argument and 7623 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000019)

Attempting test instance 16 with 1000000000000000000 as the argument and 554817437 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0001656)

Attempting test instance 17 with 576460752303423488 as the argument and 60 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000654)

Attempting test instance 18 with 640 as the argument and 23 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000192)

Attempting test instance 19 with 785 as the argument and 34 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000085)

Attempting test instance 20 with 1022 as the argument and 10 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000071)

Attempting test instance 21 with 962 as the argument and 38 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000051)

Attempting test instance 22 with 640 as the argument and 23 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000014)

Attempting test instance 23 with 1099510542205 as the argument and 17863 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000220)

Attempting test instance 24 with 944875173846 as the argument and 1243789 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000700)

Attempting test instance 25 with 672031828383 as the argument and 500073 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000254)

Attempting test instance 26 with 893915235088 as the argument and 243779 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000266)

Attempting test instance 27 with 1088385987371 as the argument and 4634234 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000256)

Attempting test instance 28 with 347905064087584832 as the argument and 5150282 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000430)

Attempting test instance 29 with 309341003709448449 as the argument and 19102955 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000414)

Attempting test instance 30 with 263810380166378775 as the argument and 4693345949 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0001118)

Attempting test instance 31 with 361431780114432130 as the argument and 94727263 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000390)

Attempting test instance 32 with 378311177695920400 as the argument and 20702253 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000417)

Attempting test instance 33 with 290553370434404484 as the argument and 146293655 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000391)

Attempting test instance 34 with 423901414250789313 as the argument and 292614203 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000405)

Attempting test instance 35 with 438190581230404958 as the argument and 6012372582 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000411)

Attempting test instance 36 with 293666568548731467 as the argument and 3648043185 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000395)

Attempting test instance 37 with 392393882169705920 as the argument and 3341296806 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000428)

Attempting test instance 38 with 376370659955075108 as the argument and 3279511256 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000403)

Attempting test instance 39 with 412658913555584867 as the argument and 3498747798 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0007001)

Attempting test instance 40 with 999999999999999999 as the argument and 29665503 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000046)

Attempting test instance 41 with 410054521552536292 as the argument and 26030230909 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0002485)

Attempting test instance 42 with 416860608518791589 as the argument and 8015276820 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000507)

Attempting test instance 43 with 393014244375683364 as the argument and 16905456859 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0001146)

Attempting test instance 44 with 518010418436963490 as the argument and 15340957057 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000593)

Attempting test instance 45 with 576460730781662959 as the argument and 794365 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0001628)

Attempting test instance 46 with 565764701561028461 as the argument and 2186952 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000579)

Attempting test instance 47 with 571954850028252927 as the argument and 7287457 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000530)

Attempting test instance 48 with 558161296277634687 as the argument and 1416255 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000526)

Attempting test instance 49 with 504314853196816127 as the argument and 6183662 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000561)

Attempting test instance 50 with 123456789 as the argument and 51639 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000194)

Attempting test instance 51 with 768614336404564650 as the argument and 2504730781961 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000580)

Attempting test instance 52 with 384307168202282325 as the argument and 956722026041 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000012)

Attempting test instance 53 with 384307168202282324 as the argument and 1548008755920 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000010)

Attempting test instance 54 with 192153584101141162 as the argument and 956722026041 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000011)

Attempting test instance 55 with 196657183728511722 as the argument and 502131822759 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000404)

Attempting test instance 56 with 193349852752161450 as the argument and 484936992181 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000507)

Attempting test instance 57 with 196731950519200426 as the argument and 350312970581 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000419)

Attempting test instance 58 with 192153584101141166 as the argument and 644603021052 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000028)

Attempting test instance 59 with 10000000000000000 as the argument and 17165857 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000601)

Attempting test instance 60 with 200 as the argument and 26 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000051)

Attempting test instance 61 with 93459834598323452 as the argument and 317400926 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000410)

Attempting test instance 62 with 1717161617181871 as the argument and 69493195 as the expected answer
 :: SUCCESS (Time elapsed 00:00:00.0000307)

Summary: 63 tests out of 63 passed
Tests passed (0 to 63): 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62
Tests failed (0 to 63): none */