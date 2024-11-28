using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerStore : MonoBehaviour
{
    public PlayerBase playerBase;
    public Transform playerBaseTarget;
    public GameObject player;
    public Vector3 creationOffset;
    public int index;
    public KeyCode[] teclas =
    {
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9
    };

    public GameObject[] prefabs;
    public int [] prices;

    public TextMeshProUGUI storeUI;
    void Update()
    {
        for (int i = 0; i < teclas.Length; i++)
        {
            if(Input.GetKeyDown(teclas[i])){
                index = i;
            }
            playerBaseTarget.position = transform.position + creationOffset;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (prices[index] < playerBase.money)
            {
                playerBase.SpendMoney(prices[index]);
                GameObject o = Instantiate(prefabs[index]);
                o.transform.position = player.transform.position + creationOffset;

                //Vector3 forwardTarget = new Vector3(playerBase.transform.position.x, o.transform.position.y, playerBase.transform.position.z);
                //o.transform.forward = playerBase.transform.position-transform.position;
                //o.transform.forward = forwardTarget;
                o.transform.LookAt(playerBaseTarget);
            }
        }
        int fakeIndex = index + 1;
        storeUI.text = fakeIndex.ToString()+".- Tower"+ fakeIndex.ToString() +" $"+prices[index].ToString();
    }
    
}
