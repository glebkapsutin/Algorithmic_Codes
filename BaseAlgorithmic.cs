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
    }
   
}