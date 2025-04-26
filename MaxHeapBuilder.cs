using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_cods_in_university
{
    public class MaxHeapBuilder
    {
        // Метод для построения максимальной двоичной кучи из массива
        public void BuildMaxHeap(int[] array)
        {
            if (array == null || array.Length <= 1)
                return;

            // Начинаем с последнего родительского узла
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(array, i, array.Length);
            }
        }

        // Метод для восстановления свойства max-heap для поддерева с корнем в index
        private void MaxHeapify(int[] array, int index, int heapSize)
        {
            int largest = index; // Предполагаем, что текущий узел наибольший
            int leftChild = 2 * index + 1; // Левый потомок
            int rightChild = 2 * index + 2; // Правый потомок

            // Сравниваем с левым потомком
            if (leftChild < heapSize && array[leftChild] > array[largest])
            {
                largest = leftChild;
            }

            // Сравниваем с правым потомком
            if (rightChild < heapSize && array[rightChild] > array[largest])
            {
                largest = rightChild;
            }

            // Если наибольший элемент не текущий узел, меняем их местами
            if (largest != index)
            {
                // Меняем местами
                int temp = array[index];
                array[index] = array[largest];
                array[largest] = temp;

                // Рекурсивно применяем MaxHeapify к поддереву
                MaxHeapify(array, largest, heapSize);
            }
        }
    }
}
