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
    private string helpDay;

    public List<LocationInfo> ListLocations { get => listLocations; }

    public string HelpDay { get => helpDay; }

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

    public DayInfo(int numDay, string helpStr, List<LocationInfo> list)
    {
        numberDay = numDay;
        helpDay = helpStr;
        listLocations = list;
    }

    public DayInfo(string csv, char sep = '#')
    {
        string[] ar = csv.Split(sep, StringSplitOptions.RemoveEmptyEntries);
        if (ar.Length > 2)
        {
            numberDay = (int.TryParse(ar[0], out int res)) ? res : -1;
            helpDay = ar[1];
            listLocations.Clear();
            for(int i = 0; i < ar.Length - 2; i++)
            {
                listLocations.Add(new LocationInfo(ar[i + 2]));
            }
        }
    }

    public string ToCsvString(char sep = '#')
    {
        StringBuilder sb = new StringBuilder($"{numberDay}{sep}{helpDay}{sep}");
        foreach(LocationInfo li in listLocations)
        {
            sb.Append($"{li.ToCSVString()}{sep}");
        }
        return sb.ToString();
    }
}
