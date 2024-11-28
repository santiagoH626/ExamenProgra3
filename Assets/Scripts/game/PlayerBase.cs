using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBase : MonoBehaviour
{
    public int money;
    public int moneyStart;

    public int moneyPerSecond;
    public float moneyFloatStorage;

    public int score;

    public TextMeshProUGUI gui;
    public TextMeshProUGUI scoreUI;
    // Start is called before the first frame update
    void Start()
    {
        money = moneyStart;
    }

    // Update is called once per frame
    void Update()
    {
        moneyFloatStorage += Time.deltaTime * moneyPerSecond;
        money += (int)(moneyFloatStorage - moneyFloatStorage % 1);
        moneyFloatStorage = moneyFloatStorage % 1;

        gui.text = "Money: " + money.ToString();
        scoreUI.text = "Score: "+score.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Fin
            Destroy(other.gameObject);
        }
    }
    public void SpendMoney(int amount)
    {
        money -= amount;
    }
    public void GetMoney(int amount)
    {
        money += amount; 
    }
}
