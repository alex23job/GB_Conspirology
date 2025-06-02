using System;
using System.Text;

[Serializable]
public class LocationInfo
{
    private string nameNPC;
    private string description;
    private string title;
    private int numberDay;
    private bool isComplete;

    public string NameNPC { get => nameNPC; }
    public string Description { get => description; }
    public string Title { get => title; }
    public int NumberDay { get => numberDay; }
    public bool IsComplete { get => isComplete; }

    public LocationInfo() { }
    public LocationInfo(int num, string nm, string tit, string descr)
    {
        numberDay = num;
        nameNPC = nm;
        title = tit;
        description = descr;
    }

    public LocationInfo(string csv, char sep = '=')
    {
        string[] ar = csv.Split(sep, StringSplitOptions.RemoveEmptyEntries);
        if (ar.Length == 5)
        {
            numberDay = (int.TryParse(ar[0], out int res)) ? res : -1;
            nameNPC = ar[1];
            title = ar[2];
            description = ar[3];
            isComplete = (bool.TryParse(ar[4], out bool boolValue)) ? boolValue : false;
        }
    }

    public string ToCSVString(char sep = '=')
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{numberDay}{sep}");
        sb.Append($"{nameNPC}{sep}");
        sb.Append($"{title}{sep}");
        sb.Append($"{description}{sep}");
        sb.Append($"{isComplete}{sep}");
        return sb.ToString();
    }

    public void SetComplete(bool zn)
    {
        isComplete = zn;
    }
}
