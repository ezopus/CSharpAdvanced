using System.Text;

public class GenericCount<T> where T : IComparable<T>
{
    private List<T> list;

    public GenericCount()
    {
        list = new List<T>();
    }

    public void Add(T item)
    {
        list.Add(item);
    }

    public int Count(T itemToCompare)
    {
        int count = 0;
        foreach (T item in list)
        {
            if (item.CompareTo(itemToCompare) > 0)
            {
                count++;
            }
        }

        return count;
    }







}