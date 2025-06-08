using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LocationControl : MonoBehaviour
{
    [SerializeField] private string locationName;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject hintPanel;
    [SerializeField] private GameObject noteItemPanel;
    [SerializeField] private GameObject[] questObjects;
    [SerializeField] private Button mapBtn;

    private GameObject currentQuestObject = null;
    private int countQuestObjects = 0;

    // Start is called before the first frame update
    void Start()
    {
        LoadQuestHints();
        if (questObjects != null && questObjects.Length == 0) mapBtn.gameObject.GetComponent<Image>().color = Color.green;
    }

    private void LoadQuestHints()
    {
        if (questObjects == null || questObjects.Length == 0) return;
        foreach (GameObject go in questObjects)
        {
            string nameObject = go.name;
            foreach(QuestObjectInfo qoi in QuestObjectList.Instance.listQuestObiects)
            {
                if ((qoi.Day == GameManager.Instance.currentDay) && (qoi.Location == locationName) && (qoi.NameQuestObject == nameObject))
                {
                    QuestHint questHint = go.GetComponent<QuestHint>();
                    if (questHint != null)
                    {
                        questHint.AddListHint(qoi.HintList);
                    }
                    break;
                }
            }
        }
    }

    public void HintView(string textHint, GameObject go)
    {
        currentQuestObject = go;
        hintPanel.transform.GetChild(0).GetComponent<Text>().text = textHint;
        hintPanel.SetActive(true);
    }

    public void HintClose()
    {
        currentQuestObject = null;
        hintPanel.SetActive(false);
    }

    public void HintOK()
    {
        if (currentQuestObject != null)
        {
            QuestHint questHint = currentQuestObject.GetComponent<QuestHint>();
            questHint.IncrementIndexHint();
            QuestNoteItem qni = currentQuestObject.GetComponent<QuestNoteItem>();
            if (qni != null)
            {
                NoteItem item = qni.GetNoteItem();
                noteItemPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = item.Day;
                noteItemPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = item.Location;
                noteItemPanel.transform.GetChild(2).gameObject.GetComponent<Text>().text = item.NameNPC;
                noteItemPanel.transform.GetChild(3).gameObject.GetComponent<Text>().text = item.Description;
                GameManager.Instance.noteBook.AddItem(item);
                if (questHint.IsEndHint)
                {
                    countQuestObjects++;
                    currentQuestObject.SetActive(false);
                    if (countQuestObjects == questObjects.Length) mapBtn.gameObject.GetComponent<Image>().color = Color.green;
                }
                HintClose();
            }
        }
        noteItemPanel.SetActive(true);
        

    }

    /*public void ViewNoteItem(NoteItem item)
    {
        noteItemPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = item.Day;
        noteItemPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = item.Location;
        noteItemPanel.transform.GetChild(2).gameObject.GetComponent<Text>().text = item.NameNPC;
        noteItemPanel.transform.GetChild(3).gameObject.GetComponent<Text>().text = item.Description;
        noteItemPanel.SetActive(true);
        GameManager.Instance.noteBook.AddItem(item);
    }*/

    public void LoadMapScene()
    {
        if (questObjects != null && questObjects.Length > 0 && countQuestObjects < questObjects.Length)
        {
            infoPanel.SetActive(true);
            return;
        }
        SceneManager.LoadScene("MapScene");
    }
}
