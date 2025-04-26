namespace First_cods_in_university.AvlTree
{
    public class Node
    {
        public int Value;

        public Node? Left;
        public Node? Right;

        public Node(int Value)
        {
            this.Value= Value;
            Left = null;
            Right = null;
        }


    }
    public class BinarySearchTree
    {
        public Node? Root;

        public BinarySearchTree()
        {
            Root = null;
        }
        public void Insert(int value)
        {
            Root = InsertRec(Root, value);
        }

        private Node InsertRec(Node node, int value)
        {
            if (node == null)
                return new Node(value);

            if (value < node.Value)
                node.Left = InsertRec(node.Left, value);
            else if (value > node.Value)
                node.Right = InsertRec(node.Right, value);

            return node;
        }
        public int SearchHeight(Node node)
        {
            if(node  == null)
            {
                return 0;
            }
            int leftHeight = SearchHeight(node.Left);
            int rightHeight = SearchHeight(node.Right);
            return Math.Max(leftHeight, rightHeight ) +1;

        }
        public int GetBalance(Node node)
        {
            if (node == null)
                return 0;

            return SearchHeight(node.Left) - SearchHeight(node.Right);
        }

        public void PrintBalances(Node node)
        {
            if (node == null)
                return;

            Console.WriteLine($"Узел {node.Value} → Баланс: {GetBalance(node)}");

            PrintBalances(node.Left);
            PrintBalances(node.Right);
        }

       
        public void PrintTreeBalance()
        {
            if (Root == null)
            {
                Console.WriteLine("Дерево пустое.");
                return;
            }
            PrintBalances(Root);
        }

    }
}