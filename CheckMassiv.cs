namespace First_cods_in_university.Massiv
{
    public class MassivCheck
    {
        public static int[] Add(int[] massiv1,int[] massiv2)
        {
            List<int> Res = new List<int>();
            int perenos = 0;
            for (int i = 0; i < Math.Max(massiv1.Length,massiv2.Length); i++)
            {
                int num1 = i<massiv1.Length ? massiv1[massiv1.Length-1-i] : 0;
                int num2 = i<massiv2.Length ? massiv2[massiv2.Length-1-i] : 0;
                int sum = num1 + num2 + perenos;
                Res.Add(sum%10);
                perenos = sum / 10;
               
            }
             if (perenos > 0)
                {
                    Res.Add(perenos);
                }
                Res.Reverse();
                return Res.ToArray();
        }
        
       public static int[] Subtract(int[] num1, int[] num2)
        {
            List<int> result = new List<int>();
            int borrow = 0; // Заем

            for (int i = 0; i < num1.Length; i++)
            {
                int digit1 = num1[num1.Length - 1 - i];
                int digit2 = i < num2.Length ? num2[num2.Length - 1 - i] : 0;

                int diff = digit1 - digit2 - borrow;
                if (diff < 0)
                {
                    diff += 10; 
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }

                result.Add(diff);
            }

            result.Reverse();
            return RemoveLeadingZeros(result.ToArray());
        }

        
        static int[] RemoveLeadingZeros(int[] number)
        {
            return number.SkipWhile(digit => digit == 0).ToArray();
        }
        static int Compare(int[] num1, int[] num2)
        {
            if (num1.Length != num2.Length)
            {
                return num1.Length.CompareTo(num2.Length);
            }

            for (int i = 0; i < num1.Length; i++)
            {
                if (num1[i] != num2[i])
                {
                    return num1[i].CompareTo(num2[i]);
                }
            }

            return 0; // Числа равны
        }

    }
}