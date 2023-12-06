using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RPGctrl : MonoBehaviour
{
    public ObjectPoolTest op;
    public float timeInterval;
    private float timer;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeInterval)
        {
            GameObject go;
            op.pgPool.Get(out go);
            go.GetComponent<PGctrl>().op = this.op;
            timer -= timeInterval;
        }
    }
}
