using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HeapSolution
{
   public class HeapTree
   {
        private const int DEFAULT_CAPACITY = 7;
        private readonly IComparer<int> comparer;
        private int[] data;
        private int capacity;
        public int Count { get; private set; }
        public int[] HeapContents { get; private set; }

        public HeapTree(): this(Comparer<int>.Default)
        {

        }

        public HeapTree(IComparer<int> comparer)
        {
            this.comparer = comparer;
            capacity = DEFAULT_CAPACITY;
            data = new int[capacity];
        }

        public void Push(int value)
        {
            ExpandArrayIfNeeded();

            // Step – 1 Add the new value at the end of the heap array. This will ensure that tree is complete.
            data[Count] = value;
            int ChildIndex = Count;

            // Step - 2 While heap property is not satisfied, swap the new item with its parent.
            while (ChildIndex > 0 && IsFirstElementGreaterThanSecondElement(ChildIndex, GetParentIndex(ChildIndex)))
            {
                Swap(ChildIndex, GetParentIndex(ChildIndex));
                ChildIndex = GetParentIndex(ChildIndex);
            }

            HeapContents = data;
            Count++;
        }

        public void Pop()
        {
            if (Count <= 1)
            {
                Count = 0;
                return;
            }

            // Step – 1 Move the last item (the right most) in the heap array into the zero (root) index. 
            data[0] = data[Count - 1];
            data[Count - 1] = 0;
            Count--;

            // Step - 2 While heap property is not satisfied, swap the item with one of its children if needed.
            PushDownIfNeeded(0);
        }
        private void PushDownIfNeeded(int parentIndex)
        {
            int leftChildIndex = GetLeftChildIndex(parentIndex);
            int rightChildIndex = GetRightChildIndex(parentIndex);

            // case - 1 : no child
            if (leftChildIndex >= Count)
            {
                return;
            }

            // case - 2 : Only Left child
            if (rightChildIndex >= Count)
            {
                if (IsFirstElementGreaterThanSecondElement(leftChildIndex, parentIndex))
                {
                    Swap(leftChildIndex, parentIndex);
                    PushDownIfNeeded(leftChildIndex);
                    return;
                }
            }

            // case - 3 : Two children left and right
            // if left child is greater than right child, swap left child with parent
            if (IsFirstElementGreaterThanSecondElement(leftChildIndex, rightChildIndex))
            {
                if (IsFirstElementGreaterThanSecondElement(leftChildIndex, parentIndex))
                {
                    Swap(leftChildIndex, parentIndex);
                    PushDownIfNeeded(leftChildIndex);
                    return;
                }
            }
            //if right child is greater than left child, swap right child with parent
            else if(IsFirstElementGreaterThanSecondElement(rightChildIndex,parentIndex))
            {
                Swap(rightChildIndex, parentIndex);
                PushDownIfNeeded(rightChildIndex);
                return;
            }
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private void Swap(int left, int right)
        {
            int temp = data[left];
            data[left] = data[right];
            data[right] = temp;
        }

        private bool IsFirstElementGreaterThanSecondElement(int FirstElementIndex, int SecondElementIndex)
        {
            return data[FirstElementIndex] > data[SecondElementIndex];
        }
        private void ExpandArrayIfNeeded()
        {
            if (Count == capacity)
            {
                capacity = Count * 2;
                var newHeapTree = new int[capacity];
                for (int counter = 0; counter < data.Length; counter++)
                {
                    newHeapTree[counter] = data[counter];
                }
                data = newHeapTree;
            }
        }
    }
}
