using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    [SerializeField] private LocationControl locationControl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("questObject"))
        {
            string hint = other.gameObject.GetComponent<QuestHint>().GetHint();
            locationControl.HintView(hint, other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("questObject"))
        {
            locationControl.HintClose();
        }
    }
}