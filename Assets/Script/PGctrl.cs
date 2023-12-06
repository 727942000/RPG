using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGctrl : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 1;
    public ObjectPoolTest op;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(1, 0, 0) * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            op.pgPool.Release(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
