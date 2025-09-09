using System.Security.AccessControl;

namespace First_cods_in_university.Sort
{
    public class Algorithmic
    {
        public static int LinerSearch(int[] a , int t)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if(a[i] == t)
                {
                    return i;
                }

            }
            return -1;
        }
        public static int BinarySearch(int[] a , int t )
        {   
            int left = 0;
             
            int right = a.Length - 1;

            while(left<= right)
            {
                int middle = (left+ right ) / 2;

                if(a[middle] == t)
                {
                    return middle;
                }
               if(a[middle] < t)
               {
                
                left = middle +1;
               }
               else{
                right = middle - 1;

               }

            }
            return -1;
        }
        public static void BubleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n-1; i++)
            {   
                bool swapped = false;
                for (int j = 0; j < n-i-1; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp;
                        swapped = true;
                    }
                }
                if(!swapped)
                {
                    break;


                }
            }

        }
        public static int BinarySearch2(int[] a , int t)
        {   
            
            int right = a.Length-1;
            int left = 0;
           
            while (left<=right)
            {   
                int middle = (left+right) / 2;
                if (a[middle] ==t)
                {
                    return middle;
                }
                if (t > a[middle])
                {
                    left = middle +1;
                }
                else{
                    right = middle -1;
                }
            }
            return -1;
        }
        public static void BubleSort2(int[] a)
        {
             int n  = a.Length;

             for (int i = 0; i < n-1; i++)
             {   
                bool swaped = false;
                for (int j = 0; j < n-i-1; j++)
                {   
                   
                    if (a[j] > a[j+1])
                    {
                        int temp = a[j];
                        a[j] = a[j+1];
                        a[j+1] = temp;
                        swaped = true;
                    }
                }
                if(!swaped)
                {
                    break;
                }
             }

        }
        public static void InsertionSort(int[] a )
        {
            int n = a.Length;
            for (int i = 1; i < n; i++)
            {
                int key = a[i];
                int j = i -1;

                while(j>= 0 && a[j] > key )
                {
                    a[j+1] = a[j];
                    j--;
        
                }
                a[j+1] = key;
            }

        }

    }
   
}