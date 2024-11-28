using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    public int life = 1;
    public bool unvulnerable;
    public float unvulnerableTime;

    public PlayerBase playerBase;
    public int enemyValue;

    public float stunCount;
    public float stunMax;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject o_playerBase = GameObject.FindWithTag("PlayerBase");
        if (o_playerBase != null)
        {
            playerBase = o_playerBase.GetComponent<PlayerBase>();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (stunCount <= 0f)
        {
            Vector2 mov = new Vector3(-transform.position.x, -transform.position.z);
            mov.Normalize();
            mov = mov * speed;

            rb.velocity = new Vector3(mov.x, rb.velocity.y, mov.y);
        }
        else
        {
            stunCount -= Time.deltaTime;
        }

        if (life <= 0)
        {
            playerBase.GetMoney(enemyValue);
            Destroy(gameObject);
        }
        if (unvulnerable)
        {
            if (unvulnerableTime <= 0f)
            {
                unvulnerable = false;
            }
            unvulnerableTime -=Time.deltaTime;
        }
    }
    /*
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DamagesEnemies"))
        {   
            if (!unvulnerable)
            {
                life--;
                unvulnerable = true;
                unvulnerableTime = 0.5f;
            }
            
        }
    }
    */
    public void TakeDamage()
    {
        if (!unvulnerable)
        {
            life--;
            unvulnerable = true;
            unvulnerableTime = 0.5f;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            stunCount = stunMax;
        }
    }
}
