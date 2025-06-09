using System;
using System.Collections.Generic;
using System.Text;

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

    public bool IsMerged 
    {
        get
        {
            return (description.IndexOf(')') != -1);
        }
    }

    public NoteItem() { }

    public NoteItem(NoteItem item)
    {
        day = new string(item.Day);
        location = new string(item.Location);
        nameNPC = new string(item.NameNPC);
        description = new string(item.Description);
    }
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

    public void MergeItem(NoteItem item)
    {
        int count = 1;
        if (IsMerged)
        {
            string[] ar = description.Split(')');
            count = ar.Length;
        }
        else count++;
        string itemDescr = item.Description;
        if (item.IsMerged)
        {
            
            int index = -1;
            do
            {
                index = itemDescr.IndexOf(')', index++);
                if (index != -1)
                {                    
                    string replStr = "";
                    if (index > 2 && itemDescr[index - 2] == ' ') replStr = itemDescr.Substring(index - 1, 1);
                    if (index > 3 && itemDescr[index - 3] == ' ') replStr = itemDescr.Substring(index - 2, 2);
                    itemDescr = itemDescr.Replace(replStr, count.ToString());
                    count++;
                }
            } while (index != -1);
        }
        else
        {
            itemDescr = $" {count}) {item.Day} {item.Location} {item.Description}";
        }
        if (IsMerged)
        {
            description += itemDescr;
        }
        else
        {
            description = $" 1) {day} {location} {description} {itemDescr}";
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

[Serializable]
public class NoteBook
{
    private List<NoteItem> noteItems = new List<NoteItem>();

    public int CountItems { get { return noteItems.Count; } }

    public NoteBook() { }

    public NoteBook(string csv, char sep = '#', char sepItem = '=')
    {
        string[] ar = csv.Split(sep);
        noteItems.Clear();
        for(int i = 0; i < ar.Length; i++)
        {
            noteItems.Add(new NoteItem(ar[i], sepItem));
        }
    }

    public void AddItem(NoteItem item)
    {
        noteItems.Add(item);
    }

    public void Remove(NoteItem item)
    {
        noteItems.Remove(item);
    }

    public void RemoveAt(int index)
    {
        noteItems.RemoveAt(index);
    }

    public NoteItem GetItem(int index)
    {
        if (index >= 0 && index < noteItems.Count)
        {
            return noteItems[index];
        }
        return null;
    }

    public void MergeItems(int numItem1, int numItem2)
    {
        if (numItem1 >= 0 && numItem1 < noteItems.Count)
        {
            if (numItem2 >= 0 && numItem2 < noteItems.Count)
            {
                noteItems[numItem1].MergeItem(noteItems[numItem2]);
                noteItems.RemoveAt(numItem2);
            }
        }
    }

    public string ToCsvString(char sep = '#', char sepItem = '=')
    {
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < noteItems.Count; i++)
        {
            sb.Append($"{noteItems[i].ToCsvString(sepItem)}{sep}");
        }
        return sb.ToString();
    }
}
