using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( target!= null)
        {
            transform.LookAt(target);
        }
        
        rb.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyMain>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
