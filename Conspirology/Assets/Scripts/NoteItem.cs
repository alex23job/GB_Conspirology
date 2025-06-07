using System;

[Serializable]
public class NoteItem
{
    private string day;
    private string location;
    private string nameNPC;
    private string description;

    public string Day { get => day; }
    public string Location { get => location; }
    public string NameNPC { get => nameNPC; }
    public string Description { get => description; }

    public NoteItem() { }
    public NoteItem(string d, string loc, string nm, string des)
    {
        day = d;
        location = loc;
        nameNPC = nm;
        description = des;
    }

    public NoteItem(string csv, char sep = '=')
    {
        string[] ar = csv.Split(sep);
        if (ar.Length == 4)
        {
            day = ar[0];
            location = ar[1];
            nameNPC = ar[2];
            description = ar[3];
        }
    }

    public string ToCsvString(char sep = '=')
    {
        return $"{day}{sep}{location}{sep}{nameNPC}{sep}{description}{sep}";
    }

    public override string ToString()
    {
        return $"day:{day}  location:{location}  nameNPC:{nameNPC}  description:{description}";
    }
}
