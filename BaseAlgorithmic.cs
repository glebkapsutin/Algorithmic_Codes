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

    }
   
}