using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class SendScore : MonoBehaviour
{
    public string username;
    public int score;

    public PlayerBase playerBase;
    public TMP_InputField playerInputField;
    public Button sendButton;
    public Button restartButton;
    public TextMeshProUGUI tmpRanking;
    public RankingModel ranking;
    public GameObject screen;

    // Start is called before the first frame update
    void Start()
    {
        
        sendButton.onClick.AddListener(OnSendButtonClick);
        restartButton.onClick.AddListener(OnRestartButtonClick);
        restartButton.gameObject.SetActive(false);
        screen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBase!=null){
            score = playerBase.score;
        } else {
            screen.SetActive(true);
        }
    }

    public void OnSendButtonClick(){
        if (playerInputField.text!=""){
            username = playerInputField.text;
            StartCoroutine(SendRequest(username,score));
            sendButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
        }
    }
    IEnumerator SendRequest(string username, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("score", score);
        DateTime currentDateTime = DateTime.Now;
        form.AddField("date_time", currentDateTime.ToString("yyyy-MM-dd HH:mm:ss"));


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/examen_progra_3/score.php", form))
        {
            yield return www.SendWebRequest();
            
            if (www.result == UnityWebRequest.Result.ProtocolError ||
                www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("error");
                tmpRanking.text = "Scores:\nnoone";
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
            
        }
        StartGetRanking();

    }
    public void StartGetRanking(){
        StartCoroutine(GetRanking());
    }
    IEnumerator GetRanking()
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/examen_progra_3/ranking.php", form))
        {
            yield return www.SendWebRequest();

            
            if (www.result == UnityWebRequest.Result.ProtocolError ||
                www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("error");
                tmpRanking.text = "Scores:\nsin registros";
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                //OnCallback?.Invoke(JsonUtility.FromJson<PlayerInfoResultModel>(www.downloadHandler.text));
                ranking = JsonUtility.FromJson<RankingModel>(www.downloadHandler.text);
                //tmpScores.text = "Scores:\n"+www.downloadHandler.text;
                ReadRanking(ranking,tmpRanking);
            }
            
        }

    }

    public void ReadRanking(RankingModel rr, TextMeshProUGUI tmp){
        string s = "Ranking:\n";
        for(int i = 0; i < rr.scores.Length; i++){
            int orden = i+1;
            s += orden.ToString()+".- "+rr.scores[i].username+" - "+rr.scores[i].score.ToString()+"\n";
        }
        tmp.text = s;
    }


    public void OnRestartButtonClick(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
