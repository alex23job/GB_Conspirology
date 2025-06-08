using System;
using UnityEngine;

[Serializable]
public class QuestNoteItem : MonoBehaviour
{
    [SerializeField] private string day;
    [SerializeField] private string location;
    [SerializeField] private string nameNPC;
    [SerializeField] private string description;

    public NoteItem GetNoteItem()
    {
        return new NoteItem(day, location, nameNPC, description);
    }

}
