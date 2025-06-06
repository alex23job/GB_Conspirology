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

    private int currentNote = 0;

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

    }

    public void OnBtnItemClick(int num)
    {
        audioSource.clip = clickItem;
        audioSource.Play();
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
    }
}
