using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace RPGDemo
{
    public class Projectile222 : MonoBehaviour
    {
        public int force = 200;
        public float lifetime = 4;


        public void Launch()
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddRelativeForce(Vector3.forward * force, ForceMode.Impulse);
            Destroy(gameObject, lifetime);
        }
    }
}
