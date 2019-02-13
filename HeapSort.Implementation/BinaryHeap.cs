using System;

namespace HeapSort.Implementation
{
    //MaxHeap
    public class BinaryHeap<T> where T : IComparable<T>
    {
        private readonly T[] _heap;
        private int _counter;

        public int Parent(int index) => (index - 1) / 2;
        public int LeftChild(int index) => 2 * index + 1;
        public int RightChild(int index) => 2 * index + 2;
        public T Root => _heap[0];

        public BinaryHeap(int heapSize)
        {
            _heap = new T[heapSize];
            _counter = -1;
        }

        private BinaryHeap(T[] array)
        {
            _counter = array.Length;
            _heap = array;
            for (int i = _counter / 2; i >= 0; i--)
            {
                SiftDown(i);
            }
        }

        public void Add(T element)
        {
            if (_counter == _heap.Length)
                throw new InvalidOperationException("Heap is full :(");

            _counter++;
            _heap[_counter] = element;
            SiftUp(_counter);
        }

        public T PopRoot()
        {
            var root = _heap[0];
            _heap[0] = _heap[_counter];
            SiftDown(0);
            _counter--;

            return root;
        }

        private void SiftUp(int index)
        {
            var parentIndex = Parent(index);
            while (index > 0 && _heap[parentIndex].CompareTo(_heap[index]) < 0)
            {
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }

        private void SiftDown(int index)
        {
            var maxIndex = index;

            while (true)
            {
                var l = LeftChild(maxIndex);
                var r = RightChild(maxIndex);

                if (l < _counter && _heap[l].CompareTo(_heap[maxIndex]) > 0)
                    maxIndex = l;

                if (r < _counter && _heap[r].CompareTo(_heap[maxIndex]) > 0)
                    maxIndex = r;

                if (maxIndex == index)
                    return;

                Swap(maxIndex, index);
                index = maxIndex;
            }
        }

        private void Swap(int from, int to)
        {
            var temp = _heap[from];

            _heap[from] = _heap[to];
            _heap[to] = temp;
        }

        public static BinaryHeap<THeap> BuildHeap<THeap>(THeap[] array) where THeap : IComparable<THeap>
        {
            BinaryHeap<THeap> heap = new BinaryHeap<THeap>(array);

            return heap;
        }

        public static THeap[] HeapSort<THeap>(THeap[] array) where THeap : IComparable<THeap>
        {
            var heap = BuildHeap(array);
            int size = heap._counter;
            for (int i = 0; i < size - 1; i++)
            {
                heap.Swap(0, heap._counter- 1);
                heap._counter--;
                heap.SiftDown(0);
            }

            return heap._heap;
        }
    }
}
