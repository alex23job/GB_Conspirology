using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHint : MonoBehaviour
{
    private List<string> listHints = new List<string>();
    private int currentIndexHint = 0;

    public int CurrentIndexHint { get => currentIndexHint; }

    public bool IsEndHint { get => (currentIndexHint == listHints.Count - 1); }

    public void AddListHint(List<string> list)
    {
        listHints.Clear();
        for (int i = 0; i < list.Count; i++) listHints.Add(new string(list[i]));
    }

    public string GetHint()
    {
        return listHints[CurrentIndexHint];
    }

    public void IncrementIndexHint()
    {
        if (currentIndexHint < listHints.Count - 1) currentIndexHint++;
    }
}
