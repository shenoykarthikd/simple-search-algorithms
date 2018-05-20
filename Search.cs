using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    //Linear And Binary Search O(n) Comparison for sorted arrays.
    class Search
    {

        static void Main(string[] args)
        {
            //Input array to be searched
            int[] arrNum = { 2, 4, 6, 8, 10, 12, 14, 16, 18 };

            //Element to be searched in the array
            int element = 16;

            //Index in the array that is returned if the value is found
            int index = -1;

            Console.WriteLine("Element to be found: " + element);

            Search ls = new Search();

            Console.WriteLine("\nLinear Search - ");
            index = ls.GetIndexWithLinearSearch(arrNum, element);
            ls.printSolution(index, element);

            Console.WriteLine("\nBinary Search - ");
            index = ls.GetIndexWithBinarySearch(arrNum, 0, arrNum.Length - 1, element, 0);
            ls.printSolution(index, element);
        }

        //Linear Search - Worst case - O(n) 
        int GetIndexWithLinearSearch(int[] arrNum, int element)
        {
            for(int i = 0; i < arrNum.Length; i++)
            {
                Console.WriteLine("Search Number: " + (i + 1));
                if (arrNum[i] == element)
                {
                    return i;
                }
            }
            return -1;
        }

        //Binary Search - Worst case - O(log N)
        int GetIndexWithBinarySearch(int[] arrNum, int fromIndex, int toIndex, int element, int searchNumber)
        {
            searchNumber += 1;
            Console.WriteLine("Search Number: " + searchNumber);
            Console.Write("\t\t From Index: {0}; To Index: {1}; ", fromIndex, toIndex);

            if (toIndex >= fromIndex)
            { 
                //Calculate the middle Index based on the FromIndex and ToIndex of the subarray.
                int midIndex = (fromIndex + toIndex) / 2;

                Console.WriteLine("Middle Index: {0}", midIndex);

                //If element is equal to the value in the middle index, the search is successful
                //Else if the element is less than the value in the middle index, repeat search for the first part of the subarray
                //Else if the element is greater than the value in the middle index, repeat search for the second part of the subarray
                if (arrNum[midIndex] == element)
                {
                    return midIndex;
                }
                else if(arrNum[midIndex] > element)
                {
                    //Repeat search by reducing ToIndex to the index before the middle Index
                    toIndex = midIndex - 1;
                    return GetIndexWithBinarySearch(arrNum, fromIndex, toIndex, element, searchNumber);
                }
                else if (arrNum[midIndex] < element)
                {
                    //Repeat search by increasing FromIndex to the index after the middle Index
                    fromIndex = midIndex + 1;
                    return GetIndexWithBinarySearch(arrNum, fromIndex, toIndex, element, searchNumber);
                }
            }
            return -1;
        }
        
        //Print whether the element was searched
        void printSolution(int index, int element)
        {
            if (index == -1)
            {
                Console.WriteLine("\n\t\t Element {0} not found", element);
            }
            else
            {
                Console.WriteLine("\n\t\t Element {0} found at index {1}", element, index);
            }
        }
    }
}
