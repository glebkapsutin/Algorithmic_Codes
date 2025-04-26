


namespace First_cods_in_university.Node
{

    public class Nodee
    {
        public int _value;
        public Nodee? right, left ;
        public Nodee(int value)
        {
            _value = value;
            right=left=null;
        }

    }
    public class BinSearchTree()
    {
        public Nodee Root { get; set; }

        
        public Nodee AddNewElement( Nodee current, int value )
        {   
            if (current == null)
            {
                return new Nodee(value);
            }
             if (value < current._value)
            {
                current.left = AddNewElement(current.left, value);
            }
            // Если значение больше – идем вправо
            else if (value > current._value)
            {
                current.right = AddNewElement(current.right, value);
            }
            return current;
        }

        public void InsertRecursively(int value)
        {
            Root = AddNewElement(Root, value);
        }
        public void GenerateRandomValue(int value)
        {
            Random rnd = new Random();
            int n = Convert.ToInt32(Console.ReadLine()); // Ввод количества элементов

            BinSearchTree bst = new BinSearchTree();
            for (int i = 0; i < n; i++)
            {
                value = rnd.Next(1, 100); // Генерация случайного числа от 1 до 99
                bst.InsertRecursively(value); // Вставка в дерево
            }

        }
    }
}