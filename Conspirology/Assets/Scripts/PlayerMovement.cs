using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float rotationRate = 360;

    private Rigidbody rb;
    private float hor, ver;
    Vector3 movement;

    Animator anim;

    private float runStart = 0;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        //movement = new Vector3(hor, 0, ver);
        //movement *= speed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(movement, ForceMode.Impulse);
        Move(ver);
        Turn(hor);
    }
    private void Move(float input)
    {
        if (input > 0.99f) runStart += Time.deltaTime;
        else runStart = 0;
        if (runStart < 3f) input = (input > 0.95f) ? 0.9f : input;
        transform.Translate(Vector3.forward * input * moveSpeed * Time.fixedDeltaTime);//Можно добавить Time.DeltaTime
        anim.SetFloat("speed", Mathf.Abs(input));
    }

    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}
