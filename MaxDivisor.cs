using System;
using System.ComponentModel;

namespace First_cods_in_university.Divisor
{
    class MaxDivisor
    {
        

        public static int MaxDuoDivisor(int a, int b)
        {   
            while (a != 0  &&  b!=0)
            {
                if (a > b)
                {
                    a-=b;
                    
                }
                else
                {
                    b-=a;
                }
                
            }
            return a==0 ? b : a;
        }
        public static int MaxThreeDivisor(int a,int b, int c)
        {
            return MaxDuoDivisor(MaxDuoDivisor(a,b),c);
        }
        public static int MaxFourDivisor(int a, int b,int c,int d)
        {
            return MaxDuoDivisor(MaxDuoDivisor(MaxDuoDivisor(a,b),c),d);
        }
    }
}