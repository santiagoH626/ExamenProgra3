using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerShootTargetSelector : MonoBehaviour
{
    public GameObject target;

    private void OnTriggerStay(Collider other)
    {
        if (target == null)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
            
                target = other.gameObject;
            
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (target == null)
            {
                target = other.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (target == other.gameObject)
            {
                target = null;
            }
        }
    }
}
