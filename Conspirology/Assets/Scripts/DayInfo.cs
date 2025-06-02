using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DayInfo
{
    private bool isComplete;
    private int numberDay;
    private List<LocationInfo> listLocations = new List<LocationInfo>();

    public List<LocationInfo> ListLocations { get => listLocations; }

    public bool IsComplete 
    {
        get
        {
            foreach(LocationInfo li in listLocations)
            {
                if (li.IsComplete == false)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public void SetComplete(string title, bool zn = true)
    {
        foreach(LocationInfo li in listLocations)
        {
            if (title == li.Title)
            {
                li.SetComplete(zn);
                return;
            }
        }
    }

    public DayInfo() { }

    public DayInfo(int numDay, List<LocationInfo> list)
    {
        numberDay = numDay;
        listLocations = list;
    }

    public DayInfo(string csv, char sep = '#')
    {
        string[] ar = csv.Split(sep, StringSplitOptions.RemoveEmptyEntries);
        if (ar.Length > 1)
        {
            numberDay = (int.TryParse(ar[0], out int res)) ? res : -1;
            listLocations.Clear();
            for(int i = 0; i < ar.Length - 1; i++)
            {
                listLocations.Add(new LocationInfo(ar[i + 1]));
            }
        }
    }

    public string ToCsvString(char sep = '#')
    {
        StringBuilder sb = new StringBuilder($"{numberDay}{sep}");
        foreach(LocationInfo li in listLocations)
        {
            sb.Append($"{li.ToCSVString()}{sep}");
        }
        return sb.ToString();
    }
}
