using System.Collections.Concurrent;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolTest : MonoBehaviour
{
    public GameObject prefab;
    public Transform originPos;
    public Transform pool;
    public int maxNum = 30;
    public int poolMaxSize = 20;
    public ObjectPool<GameObject> pgPool;
    private int id = 1;
    private int startNum = 0;
    private ConcurrentQueue<GameObject> queue;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 2;
        queue = new ConcurrentQueue<GameObject>();
        foreach (var go in pool.gameObject.GetComponentsInChildren<Transform>())
        {
            if (go.name != pool.name)
            {
                queue.Enqueue(go.gameObject);
                go.name = "弹头" + id++ + "号";
                Debug.Log(go.name + "存在");
                startNum++;
            }
        }
        //startNum = GameObject.FindGameObjectsWithTag("Pg").Length;
        pgPool = new ObjectPool<GameObject>(Create, Get, Release, MyDestroy, true, 10, poolMaxSize);
 
        GameObject go = Instantiate(prefab,originPos.position,originPos.rotation,pool);

        queue.Enqueue(go);

        go.name = "弹头" + id++ + "号";
        Debug.Log("池为空,新建对象" + go.name);
        return go;
    }
    void Get(GameObject go) {
        if (queue.IsEmpty)
        {
            Create();
        }
        queue.TryDequeue(out go);
        go.transform.position = originPos.position;
        go.transform.rotation = originPos.rotation;
        go.SetActive(true);
        Debug.Log(go.name + "出池"); 
    }
    void Release(GameObject go) {
        go.SetActive(false);
        if (queue.Count >= maxNum)
        {
            MyDestroy(go);
        }
        else
        {
            queue.Enqueue(go);
            Debug.Log(go.name + "进池");
        }
    }
    void MyDestroy(GameObject go) {
        Debug.Log("池已满," + go.name + "被销毁");
        Destroy(go);
    }
    //private void Update()
    //{
    //    timer += Time.deltaTime;
    //    if (timer >= 2)
    //    {
    //        GameObject go;
    //        pgPool.Get(out go);
    //        timer -= 2;
    //    }
    //    Debug.Log(queue.Count);
    //}
}
