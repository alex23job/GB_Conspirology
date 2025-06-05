using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private float speed = 5f;
    private Vector3 startPos;
    private bool isOpening = false;
    private bool isClosing = false;
    private float weight = 0f;
    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = door.transform.position;
        weight = 100 * transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening)
        {
            if (door.transform.position.x > targetPos.x)
            {
                door.transform.position -= Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                door.transform.position = targetPos;
                isOpening = false;
            }
        }
        if (isClosing)
        {
            if (door.transform.position.x < targetPos.x)
            {
                door.transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                door.transform.position = targetPos;
                isClosing = false;
            }
        }
    }

    public void DoorOpen()
    {
        targetPos = startPos;
        targetPos.x -= weight;
        isOpening = true;
        isClosing = false;
    }

    public void DoorClose()
    {
        targetPos = startPos;
        isClosing = true;
        isOpening = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpening)
        {
            DoorOpen();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isClosing)
        {
            DoorClose();
        }
    }
}
