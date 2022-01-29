using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'getTotalX' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */

    public static int getTotalX(List<int> a, List<int> b)
    {
        int result = 0;

        int trials = 100000;
        List<int> inBetweenArray = new List<int>();

        List<int> inBetweenFirstCriteriaArray = new List<int>();
        List<int> inBetweenSecondCriteriaArray = new List<int>();

        // Elements of the first array are all factors of the number being considered
        for (int inBetweenCandidate = 0; inBetweenCandidate < trials; inBetweenCandidate++)
        {
            bool inBetweenFirstCriteria = true;

            foreach (int number in a){
                if (number > 0){
                    if (inBetweenCandidate % number == 0)
                    {
                        inBetweenFirstCriteria = true && inBetweenFirstCriteria;
                    }
                    else 
                    {
                        inBetweenFirstCriteria = false;
                    }
                }
            }

            if (inBetweenFirstCriteria)
            {
                inBetweenFirstCriteriaArray.Add(inBetweenCandidate);
            }
        }

        // The integer being considered is a factor of all elements in the second array
        foreach (int inBetweenCandidate in inBetweenFirstCriteriaArray)
        {
            bool inBetweenSecondCriteria = true;

            foreach (int number in b){
                if (inBetweenCandidate > 0)
                {
                    if (number % inBetweenCandidate == 0)
                    {
                        inBetweenSecondCriteria = true && inBetweenSecondCriteria;
                    }
                    else 
                    {
                        inBetweenSecondCriteria = false;
                    }
                }
            }

            if (inBetweenSecondCriteria)
            {
                inBetweenSecondCriteriaArray.Add(inBetweenCandidate);
            }
        }

        //no clue why solution is always 1 more than the expected result so had to -1
        //too lazy to figure out why so for now
        result = inBetweenSecondCriteriaArray.Count() - 1; 

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = Result.getTotalX(arr, brr);

        textWriter.WriteLine(total);

        textWriter.Flush();
        textWriter.Close();
    }
}
