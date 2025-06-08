using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LocationControl : MonoBehaviour
{
    [SerializeField] private GameObject hintPanel;
    [SerializeField] private GameObject noteItemPanel;
    [SerializeField] private GameObject[] questObjects; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HintView(string textHint)
    {
        hintPanel.transform.GetChild(0).GetComponent<Text>().text = textHint;
        hintPanel.SetActive(true);
    }

    public void NoteItemView(NoteItem item)
    {
        noteItemPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = item.Day;
        noteItemPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = item.Location;
        noteItemPanel.transform.GetChild(2).gameObject.GetComponent<Text>().text = item.NameNPC;
        noteItemPanel.transform.GetChild(3).gameObject.GetComponent<Text>().text = item.Description;
        noteItemPanel.SetActive(true);
        GameManager.Instance.noteBook.AddItem(item);
    }

    public void LoadMapScene()
    {
        SceneManager.LoadScene("MapScene");
    }
}
