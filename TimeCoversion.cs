using Internal;
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
     * Complete the 'timeConversion' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string timeConversion(string s)
    {
        string suffix = s.Substring(s.Length - 2);
        string time = s.Substring(0, s.Length - 2);
        string[] timeSplit = time.Split(':');
        string convertedTime = string.Empty;

        if (suffix == "AM")
        {
            if (int.Parse(timeSplit[0]) < 12) 
            {
                convertedTime = time;
            }
            else 
            {
                convertedTime = "00:" + timeSplit[1] + ":" + timeSplit[2];
            }
        }

        else // PM
        {
            if (int.Parse(timeSplit[0]) < 12) 
            {
                int convertedHour = int.Parse(timeSplit[0]) + 12;
                convertedTime = convertedHour.ToString() + ":" + timeSplit[1] + ":" + timeSplit[2];
            }
            else 
            {
                convertedTime = time;
            }
        }

        return convertedTime;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.timeConversion(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
