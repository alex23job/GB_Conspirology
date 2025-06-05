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
        //weight = GetComponent<BoxCollider>().size.x * transform.localScale.x;
        weight = 100 * transform.localScale.x;
        print($"startPos = <{startPos}>     weight = <{weight}>");
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening)
        {
            if (door.transform.position.x > targetPos.x)
            {
                print($"Open: deltaX = {Time.deltaTime} trp.x<{door.transform.position.x}>  tgp.x<{targetPos.x}>  isOp={isOpening}  isCL={isClosing}");
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
                print($"Close: deltaX = {Time.deltaTime}");
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
        //if (isOpening) return;
        targetPos = startPos;
        targetPos.x -= weight;
        isOpening = true;
        isClosing = false;
        //transform.position = startPos;
        print($"Open: targetPos = <{targetPos}>");
    }

    public void DoorClose()
    {
        //if (isClosing) return;
        targetPos = startPos;
        isClosing = true;
        isOpening = false;
        /*Vector3 doorPos = startPos;
        doorPos.x -= weight;
        transform.position = doorPos;*/
        print($"Close: targetPos = <{targetPos}>");
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
