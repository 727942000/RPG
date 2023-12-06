using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerCtrl : MonoBehaviour
{
    public float MoveSpeed = 1;
    public float rotateSpeed = 1;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxisRaw("Horizontal");
        float h = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180), 0, Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180)) * h * MoveSpeed;
        Debug.Log(Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180) +" "+ Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180));
        rb.angularVelocity = new Vector3(0, v , 0) * rotateSpeed;
    }
}
