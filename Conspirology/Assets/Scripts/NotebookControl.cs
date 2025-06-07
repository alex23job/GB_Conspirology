using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotebookControl : MonoBehaviour
{
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
        audioSource.clip = clickChange;
        audioSource.Play();
    }

    public void OnBtnRightClick()
    {
        audioSource.clip = clickChange;
        audioSource.Play();
    }

    public void OnBtnMergeClick(int num)
    {
        audioSource.clip = clickMerge;
        audioSource.Play();
        mergeNote = num;
    }

    public void OnBtnLupaClick(int num)
    {

    }
}
