using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using First_cods_in_university.AvlTree;
//NUMBER 44 

namespace First_cods_in_university
{
   

    class Program
    {
       

        static int Main()
        {
          BinarySearchTree bst = new BinarySearchTree();
          bst.Insert(8);
          bst.Insert(3);
          bst.Insert(10);
          bst.Insert(1);
          bst.Insert(6);
          bst.Insert(14);
          bst.Insert(4);
          bst.Insert(7);
          bst.Insert(13);

          bst.PrintTreeBalance();
            
          return 0;
        }

    }


}