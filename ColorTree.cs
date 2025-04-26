namespace First_cods_in_university.ColorTree
{   public enum Color
    {
        Red,
        Black
    }
    public class Node
    {
        public int Value;
        public Color NodeColor;
        public Node Left, Right, Parent;

        public Node(int value)
        {
            Value = value;
            NodeColor = Color.Red;  // Новые узлы всегда красные
            Left = Right = Parent = null;
        }
    }
    public class RedBlackTree
    {
        private Node root;
        private Node TNULL;  // Специальный null-узел

        public RedBlackTree()
        {
            TNULL = new Node(0);
            TNULL.NodeColor = Color.Black;
            root = TNULL;
        }

        // Вставка узла
        public void Insert(int value)
        {
            Node newNode = new Node(value) { Left = TNULL, Right = TNULL };
            Node parent = null;
            Node current = root;

            while (current != TNULL)
            {
                parent = current;
                if (value < current.Value)
                    current = current.Left;
                else
                    current = current.Right;
            }

            newNode.Parent = parent;

            if (parent == null)
                root = newNode;
            else if (value < parent.Value)
                parent.Left = newNode;
            else
                parent.Right = newNode;

            newNode.NodeColor = Color.Red;
            FixInsert(newNode);
        }

        // Восстановление свойств после вставки
        private void FixInsert(Node node)
        {
            while (node.Parent != null && node.Parent.NodeColor == Color.Red)
            {
                if (node.Parent == node.Parent.Parent.Left)
                {
                    Node uncle = node.Parent.Parent.Right;
                    if (uncle.NodeColor == Color.Red) // Случай 1: дядя красный
                    {
                        node.Parent.NodeColor = Color.Black;
                        uncle.NodeColor = Color.Black;
                        node.Parent.Parent.NodeColor = Color.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Right) // Случай 2: узел справа
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }
                        node.Parent.NodeColor = Color.Black; // Случай 3: узел слева
                        node.Parent.Parent.NodeColor = Color.Red;
                        RotateRight(node.Parent.Parent);
                    }
                }
                else
                {
                    Node uncle = node.Parent.Parent.Left;
                    if (uncle.NodeColor == Color.Red)
                    {
                        node.Parent.NodeColor = Color.Black;
                        uncle.NodeColor = Color.Black;
                        node.Parent.Parent.NodeColor = Color.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Left)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }
                        node.Parent.NodeColor = Color.Black;
                        node.Parent.Parent.NodeColor = Color.Red;
                        RotateLeft(node.Parent.Parent);
                    }
                }
            }
            root.NodeColor = Color.Black;
        }

        // Левый поворот
        private void RotateLeft(Node node)
        {
            Node temp = node.Right;
            node.Right = temp.Left;

            if (temp.Left != TNULL)
                temp.Left.Parent = node;

            temp.Parent = node.Parent;

            if (node.Parent == null)
                root = temp;
            else if (node == node.Parent.Left)
                node.Parent.Left = temp;
            else
                node.Parent.Right = temp;

            temp.Left = node;
            node.Parent = temp;
        }

        // Правый поворот
        private void RotateRight(Node node)
        {
            Node temp = node.Left;
            node.Left = temp.Right;

            if (temp.Right != TNULL)
                temp.Right.Parent = node;

            temp.Parent = node.Parent;

            if (node.Parent == null)
                root = temp;
            else if (node == node.Parent.Right)
                node.Parent.Right = temp;
            else
                node.Parent.Left = temp;

            temp.Right = node;
            node.Parent = temp;
        }

        // Проверка свойств красно-черного дерева
        public void CheckProperties()
        {
            Console.WriteLine("Корень черный? " + (root.NodeColor == Color.Black));
            Console.WriteLine("Свойство красного узла? " + CheckRedProperty(root));
            Console.WriteLine("Черная высота одинакова? " + CheckBlackHeight(root, 0, -1));
        }

        private bool CheckRedProperty(Node node)
        {
            if (node == TNULL)
                return true;

            if (node.NodeColor == Color.Red)
            {
                if (node.Left.NodeColor != Color.Black || node.Right.NodeColor != Color.Black)
                    return false;
            }

            return CheckRedProperty(node.Left) && CheckRedProperty(node.Right);
        }

        private bool CheckBlackHeight(Node node, int blackCount, int target)
        {
            if (node.NodeColor == Color.Black)
                blackCount++;

            if (node == TNULL)
            {
                if (target == -1)
                    target = blackCount;
                return target == blackCount;
            }

            return CheckBlackHeight(node.Left, blackCount, target) &&
                CheckBlackHeight(node.Right, blackCount, target);
        }

        // Вывод дерева (Прямой обход)
        public void PrintTree()
        {
            PrintTreeHelper(root, "", true);
        }

        private void PrintTreeHelper(Node node, string indent, bool last)
        {
            if (node != TNULL)
            {
                Console.Write(indent);
                Console.Write(last ? "R---- " : "L---- ");
                Console.WriteLine(node.Value + " (" + node.NodeColor + ")");

                indent += last ? "   " : "|  ";

                PrintTreeHelper(node.Left, indent, false);
                PrintTreeHelper(node.Right, indent, true);
            }
        }
    }


}