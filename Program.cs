using System;

namespace HeapSolution
{
    class Program
    {
        static void Main(string[] args)
        {

            //HeapTree heapTree = new HeapTree();
            ////heapTree.Push(8);
            ////heapTree.Push(5);
            ////heapTree.Push(6);
            ////heapTree.Push(4);
            ////heapTree.Push(2);
            ////heapTree.Push(9);
            ////heapTree.Push(3);
            ////heapTree.Push(12);
            ////heapTree.Push(10);
            ////heapTree.Push(7);
            ////heapTree.Push(1);
            ////heapTree.Push(14);
            //heapTree.Push(9);
            //heapTree.Push(7);
            //heapTree.Push(8);
            //heapTree.Push(4);
            //heapTree.Push(2);
            //heapTree.Push(6);
            //foreach (var item in heapTree.HeapContents)
            //{
            //    Console.Write($"{item}\t");
            //}

            //heapTree.Pop();
            //heapTree.Pop();
            //Console.WriteLine();
            //Console.WriteLine($"Count is {heapTree.Count}");
            //foreach (var item in heapTree.HeapContents)
            //{
            //    Console.Write($"{item}\t");
            //}

            int[] arr = { 74, 19, 24, 5, 8, 79, 42, 15, 20, 53, 11 };

            foreach (var item in arr)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();
            Console.WriteLine("Applying Heap Sort....");
            HeapSort(arr);
            foreach (var item in arr)
            {
                Console.Write($"{item}\t");
            }
            Console.ReadLine();
        }

        static void HeapSort(int[] arrayToBeSorted)
        {
            int lengthOfArray = arrayToBeSorted.Length;

            // Build a max-heap from an unordered array.
            // we do NOT need to consider leaf nodes. that's why we start from  lengthOfArray / 2 - 1
            // this will set max element at 0th index
            for ( int counter = lengthOfArray / 2 - 1;  counter >= 0; counter--)
            {
                Heapify(arrayToBeSorted, lengthOfArray, counter);
            }

            // now pop up the last element. swap the last element with the max element that is the 0th index
            for (int counter = lengthOfArray - 1; counter >= 0; counter--)
            {
                int temp = arrayToBeSorted[0];
                arrayToBeSorted[0] = arrayToBeSorted[counter];
                arrayToBeSorted[counter] = temp;
                // Now run Heapify on the heap in case the new root causes a violation of the max-heap property. (Its children will still be max-heaps.)
                Heapify(arrayToBeSorted, counter, 0);
            }
        }
        static void Heapify(int[] arrayToBeSorted, int lengthOfArray, int indexOfLargestElement)
        {
            // Step - 1: grab the index of largest element and its children
            int indexOfCurrentLargestElement = indexOfLargestElement;
            int leftChildIndex = 2 * indexOfLargestElement + 1;
            int rightChildIndex = 2 * indexOfLargestElement + 2;

            // Step - 2: check if left child is bigger than the largest element? set index of current largest element  to left child's index
            // set left child's index to index of current largest element
            if (leftChildIndex < lengthOfArray && arrayToBeSorted[leftChildIndex] > arrayToBeSorted[indexOfCurrentLargestElement])
            {
                indexOfCurrentLargestElement = leftChildIndex;
            }

            // Step - 3: check if right child is bigger than the largest element
            // set right child's index to index of current largest element
            if (rightChildIndex < lengthOfArray && arrayToBeSorted[rightChildIndex] > arrayToBeSorted[indexOfCurrentLargestElement] )
            {
                indexOfCurrentLargestElement = rightChildIndex;
            }

            // Step - 4 : if you found new largest element, swap it and run heapify again for that new largest element.
            if (indexOfCurrentLargestElement != indexOfLargestElement)
            {
                int temp = arrayToBeSorted[indexOfLargestElement];
                arrayToBeSorted[indexOfLargestElement] = arrayToBeSorted[indexOfCurrentLargestElement];
                arrayToBeSorted[indexOfCurrentLargestElement] = temp;
                Heapify(arrayToBeSorted, lengthOfArray, indexOfCurrentLargestElement);
            }
        }
    }
}
