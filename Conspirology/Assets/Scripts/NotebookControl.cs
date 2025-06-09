using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotebookControl : MonoBehaviour
{
    [SerializeField] private GameObject lupaPanel;
    [SerializeField] private Button btnToLeft;
    [SerializeField] private Button btnToRight;
    [SerializeField] private Button[] arrBtnItems;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickItem;
    [SerializeField] private AudioClip clickMerge;
    [SerializeField] private AudioClip clickChange;
    [SerializeField] private Color noSelectColor;
    [SerializeField] private Color selectColor;

    private int currentNote = 0;
    private int selectNote = -1;
    private int mergeNote = -1;

    // Start is called before the first frame update
    void Start()
    {
        ViewItemButtons();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ViewItemButtons()
    {
        int i;
        Color itemColor = noSelectColor;
        for (i = 0; i < 6; i++)
        {
            itemColor = noSelectColor;
            if ((selectNote != -1) && (selectNote == i))
            {
                itemColor = selectColor;

            }
            arrBtnItems[i].gameObject.GetComponent<Image>().color = itemColor;
            NoteItem ni = GameManager.Instance.noteBook.GetItem(i + currentNote);
            if (ni != null)
            {
                arrBtnItems[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = ni.Day;
                arrBtnItems[i].transform.GetChild(1).gameObject.GetComponent<Text>().text = ni.Location;
                arrBtnItems[i].transform.GetChild(2).gameObject.GetComponent<Text>().text = ni.NameNPC;
                arrBtnItems[i].transform.GetChild(3).gameObject.GetComponent<Text>().text = ni.Description;
                arrBtnItems[i].gameObject.SetActive(true);
            }
            else
            {
                arrBtnItems[i].gameObject.SetActive(false);
            }
        }
    }

    public void OnBtnItemClick(int num)
    {
        audioSource.clip = clickItem;
        audioSource.Play();
        selectNote = num;
        ViewItemButtons();
    }

    public void OnBtnLeftClick()
    {
        int counts = GameManager.Instance.noteBook.CountItems;
        if (counts > 6 && (currentNote + 3 < counts))
        {
            currentNote += 3;
            ViewItemButtons();
        }
        audioSource.clip = clickChange;
        audioSource.Play();
    }

    public void OnBtnRightClick()
    {
        int counts = GameManager.Instance.noteBook.CountItems;
        if (counts > 6 && (currentNote >= 3))
        {
            currentNote -= 3;
        }
        else currentNote = 0;
        ViewItemButtons();
        audioSource.clip = clickChange;
        audioSource.Play();
    }

    public void OnBtnMergeClick(int num)
    {
        audioSource.clip = clickMerge;
        audioSource.Play();
        mergeNote = num;
        if (selectNote != mergeNote)
        {
            NoteItem ni = GameManager.Instance.noteBook.GetItem(selectNote + currentNote);
            ni.MergeItem(GameManager.Instance.noteBook.GetItem(mergeNote + currentNote));
            ViewItemButtons();
        }
    }

    public void OnBtnLupaClick(int num)
    {
        NoteItem ni = GameManager.Instance.noteBook.GetItem(num + currentNote);
        if (ni != null)
        {
            lupaPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = ni.Day;
            lupaPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = ni.Location;
            lupaPanel.transform.GetChild(2).gameObject.GetComponent<Text>().text = ni.NameNPC;
            lupaPanel.transform.GetChild(3).gameObject.GetComponent<Text>().text = ni.Description;
        }

        audioSource.clip = clickItem;
        audioSource.Play();
        lupaPanel.SetActive(true);
    }
}
