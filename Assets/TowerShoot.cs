using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TowerShoot : MonoBehaviour
{
    public float bulletSpeed;
    public Transform spawner;
    public GameObject target;
    public GameObject bulletPrefab;

    public float shootTime = 0f;
    public float shootDelay = 0.7f;

    public TowerShootTargetSelector tsts;
    //public Transform targetSignal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = tsts.target;

        if (shootTime <= 0f)
        {
            if (target != null)
            {
                float dist = Vector3.Distance(spawner.position, target.transform.position);
                float collisionTime = dist / bulletSpeed;
                //targetSignal.position = target.transform.position + target.GetComponent<Rigidbody>().velocity * collisionTime;
                Vector3 targetPosition = target.transform.position + target.GetComponent<Rigidbody>().velocity * collisionTime;

                GameObject b = Instantiate(bulletPrefab);
                b.GetComponent<Rocket>().target = target.transform;
                b.GetComponent<Rocket>().speed = bulletSpeed;
                b.transform.position = spawner.position;
                //b.transform.LookAt(targetPosition);
                //b.GetComponent<Rigidbody>().velocity= (targetPosition.normalized * bulletSpeed);
                //b.GetComponent<Rigidbody>().velocity= b.transform.forward * bulletSpeed;
                shootTime = shootDelay;
            }
        }
        shootTime -= Time.deltaTime;
    }
    
}
