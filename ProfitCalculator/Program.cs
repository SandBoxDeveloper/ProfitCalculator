using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProfitCalculator
{

    public class RangeFinder
    {
 
        /// <summary>
        /// Performs a search to find the start and end of the "best" period and the
        /// total amount of sales over that period.
        /// </summary>
        /// <param name="data">the data to be examined</param>
        /// <param name="bestStart">the start point found by the search</param>
        /// <param name="bestEnd">the end point found by the search</param>
        /// <param name="bestTotal">the total sales over that period</param>
        /// <param name="loops">the number of executions of the inner loop</param>
        public static void Search(double [] data, out int bestStart,
              out int bestEnd, out double bestTotal, out int loops)
        {

            //For every possible start position // every array index
            //For every possible end position // rest of array from current start
            //{
            //    Set subtotal to 0
            //    For every value in subseq // between current start and end
            //        Add profit value to subtotal
            //    Update subseq info when subtotal exceeds current best total
            //}

            bestTotal = 0 ;
            bestStart = 0;
            bestEnd = 0;
            loops = 0;
            double subTotal = 0;
            // TODO - put your search code here

            for (int i = data.Length; i >= 0; i--) //For every possible start position
            { 
                for (int j = i;  j < data.Length; j++) //For every possible end position
                {
                    subTotal = 0; // Set subtotal to 0
                    for (int k = i; k <= j; k++) //For every value in subseq
                    {
                        subTotal += data[k]; //Add profit value to subtotal  

                        if (subTotal > bestTotal) //Update subseq info when subtotal exceeds current best total
                        {
                            bestTotal = subTotal;
                            bestStart = i;
                            bestEnd = j;
                        }
                        loops += 1;
                    }   
                }
            }
        }
    }

    

///<summary>
/// Tests the Profits Calculator
///</summary>
class Test
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>

    static void Main()
    {
        double [] data;
        int bestStart, bestEnd;
        double bestTotal;
        int loops;

        ///name of the file and the number of readings
        string filename = "week52.txt";
        int items=26;

        data = new double [items];

        try
        {
            TextReader textIn = new StreamReader(filename);
            for( int i=0 ; i < items ; i++ )
            {
                string line = textIn.ReadLine();
                data[i] = double.Parse(line);
            }
            textIn.Close();
        }
        catch
        {
            Console.WriteLine ("File Read Failed");
            return;
        }

        
        RangeFinder.Search(
            data, out bestStart, out bestEnd, out bestTotal, out loops);

        Console.WriteLine ( "Start : {0} End : {1} Total {2} Loops {3}",
            bestStart, bestEnd, bestTotal, loops);
        }
    }
}

