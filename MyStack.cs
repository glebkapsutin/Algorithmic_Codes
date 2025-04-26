
class MyStack
{
    private List<int> Stack = new List<int>();

    public void push(int n)
    {
        Stack.Add(n);
    }
    public void pop()
    {   

        Console.WriteLine(Stack[^1]);
        Stack.RemoveAt(Stack[^1]);
        Console.WriteLine(Stack);

    }
    public void back()
    {
        Console.WriteLine(Stack[^1]);
    }
    public void Size()
    {
        Console.WriteLine(Stack.Count);
    }
    public void Clear()
    {
        Stack.Clear();
    }
}