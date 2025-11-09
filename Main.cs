using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using First_cods_in_university.AvlTree;


namespace First_cods_in_university
{
   

    class Program
    {
       

        static int Main()
        {
            string a = 'aaab';
            string b = 'aaaaajhc';
            Solution solution = new Solution();
            bool b = solution.CanConstruct(a, b);
            Console.WriteLine(b);

            
            return 0;
        }

    }


}