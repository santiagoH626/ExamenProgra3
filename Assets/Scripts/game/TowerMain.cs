using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMain : MonoBehaviour
{
    public int life = 1;
    public bool unvulnerable;
    public float unvulnerableTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }

        if (unvulnerable)
        {
            if (unvulnerableTime <= 0f)
            {
                unvulnerable = false;
            }
            unvulnerableTime -= Time.deltaTime;
        }

    }

    public void TakeDamage()
    {
        if (!unvulnerable)
        {
            life--;
            unvulnerable = true;
            unvulnerableTime = 0.5f;
        }
    }
}
