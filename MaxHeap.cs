using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_cods_in_university
{
    public class MaxHeap
    {
        private List<int> heap;

        public MaxHeap(int[] array)
        {
            heap = new List<int>(array);
            if (array == null) return;

            if(array.Length == 0) return;

            for (int i = 0; i < array.Length - 1; i++)
            {
                heap.Add(array[i]);
            }
            if (heap.Count <=1) return;

            int lastParent = heap.Count / 2 - 1;

            for (int i = lastParent; i >= 0; i++)
            {
                int currentIndex = i;
                HeapifyDown(currentIndex);

                
            }


        }
        public MaxHeap()
        {
            heap = new List<int>();
        }
        public int FindMax()
        {
            if (heap.Count== 0)
            {
                throw new InvalidOperationException("Cannot find maximum: heap is empty");
            }
            int maxValue = heap[0];
            return maxValue;

        }
        public int RemoveMax()
        {
            if (heap.Count == 0) throw new InvalidOperationException("Cannot remove maximum: heap is empty");
            int maxValue = heap[0];

            if (maxValue == 1) { heap.RemoveAt(0); return maxValue; }

            int lastIndex = heap.Count - 1;
            int lastElement = heap[lastIndex];
            heap[0] = lastElement;
            if (heap.Count == 0)
            {
                return maxValue;
            }
            HeapifyDown(0);
            return maxValue;


        }
        private void HeapifyDown(int index)
        {
            // Установить текущий узел как наибольший
            int largest = index;
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;

            // Сравнить с левым потомком
            if (leftChild < heap.Count && heap[leftChild] > heap[largest])
            {
                largest = leftChild;
            }

            // Сравнить с правым потомком
            if (rightChild < heap.Count && heap[rightChild] > heap[largest])
            {
                largest = rightChild;
            }

            // Если наибольший элемент не текущий узел, поменять местами и продолжить
            if (largest != index)
            {
                int temp = heap[index];
                heap[index] = heap[largest];
                heap[largest] = temp;

                // Рекурсивно применить HeapifyDown к поддереву
                HeapifyDown(largest);
            }
        }

        private void HeapifyUp(int index)
        {
            // Если достигнут корень, завершить
            if (index <= 0)
            {
                return;
            }

            // Вычислить индекс родителя
            int parent = (index - 1) / 2;

            // Если текущий элемент больше родителя, поменять местами
            if (heap[index] > heap[parent])
            {
                int temp = heap[index];
                heap[index] = heap[parent];
                heap[parent] = temp;

                // Рекурсивно применить HeapifyUp к родителю
                HeapifyUp(parent);
            }
        }

        public void Add(int element)
        {
            // Добавить элемент в конец списка
            heap.Add(element);

            // Если куча не пуста, просеять новый элемент вверх
            if (heap.Count > 1)
            {
                HeapifyUp(heap.Count - 1);
            }
        }
    }
}
