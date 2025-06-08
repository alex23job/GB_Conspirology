using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjectList : MonoBehaviour
{
    public static QuestObjectList Instance;

    public List<QuestObjectInfo> listQuestObiects = new List<QuestObjectInfo>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GenerateQuestObjectList();
    }

    private void GenerateQuestObjectList()
    {
        listQuestObiects.Add(new QuestObjectInfo("1", "PlaneDown", "FlDatRecorder", new List<string>() { "Это бортовой самописец", "Самописец нужно отдать в лабораторию для расшифровки" }));
        listQuestObiects.Add(new QuestObjectInfo("1", "PlaneDown", "FragmentNLO", new List<string>() { "Странный фрагмент обшивки - точно не от самолёта", "Фрагмент нужно отдать в университет для спектрального анализа" }));
    }
}

public class QuestObjectInfo
{
    private string day;
    private string location;
    private string nameQuestObject;
    private List<string> hintList;

    public QuestObjectInfo() { }
    public QuestObjectInfo(string d, string l, string nqo, List<string> hl)
    {
        day = d;
        location = l;
        nameQuestObject = nqo;
        hintList = hl;
    }

    public string Day { get => day; }
    public string Location { get => location; }
    public string NameQuestObject { get => nameQuestObject; }
    public List<string> HintList { get => hintList; }
}
