using System.Text;

public class Swap<T>
{
    private List<T> list;

    public Swap()
    {
        list = new List<T>();
    }

    public void Add(T item)
    {
        list.Add(item);
    }
    public void SwapElement(int index1, int index2)
    {
        (list[index1], list[index2]) = (list[index2], list[index1]);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (T item in list)
        {
            sb.AppendLine($"{typeof(T)}: {item}");
        }

        return sb.ToString().Trim();
    }

}