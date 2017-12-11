using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameApiManager : MonoBehaviour {

    [SerializeField] Text Balance;

    [SerializeField] string StartGameURL;
    [SerializeField] string KickURL;
    [SerializeField] string GameOverURL;






    //void Start()
    //{
    //    GetStartBalance();
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GetStartBalance();
        }
    }


    private void GetStartBalance()
    {
        Debug.Log("Game start");
        StartGameJson startgame = new StartGameJson();
        startgame.user_id = GameManager.instance.FirstName;
        startgame.table_id = GameManager.instance.TableId;
        startgame.entry_fee = GameManager.instance.GameCoust.ToString();

        Debug.Log(startgame.SaveToString());

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");
        byte[] form = System.Text.Encoding.UTF8.GetBytes(startgame.SaveToString());
        WWW www = new WWW(StartGameURL, form, headers);
        Debug.Log(www.url);
        StartCoroutine(UpdateBalance(www));
    }

    public  void SetKick(int kickCof, bool IsKick)
    {
        Debug.Log("Kick Player");
        KickJson kick = new KickJson();
        kick.user_id = GameManager.instance.ID;
        kick.kick_coffecient= kickCof;
        kick.is_player_do_kick = IsKick;

        Debug.Log(kick.SaveToString());

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");
        byte[] form = System.Text.Encoding.UTF8.GetBytes(kick.SaveToString());
        WWW www = new WWW(KickURL, form, headers);
        StartCoroutine(UpdateBalance(www));
    }

    public void SetGameOver(bool IsWin)
    {
        Debug.Log("Game Over");
        GameOverJson gameOver = new GameOverJson();
        gameOver.user_id = GameManager.instance.ID;
        gameOver.is_player_win = IsWin;

        Debug.Log(gameOver.SaveToString());

        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");
        byte[] form = System.Text.Encoding.UTF8.GetBytes(gameOver.SaveToString());
        WWW www = new WWW(GameOverURL, form, headers);
        StartCoroutine(UpdateBalance(www));
    }


    IEnumerator UpdateBalance(WWW www)
    {
        while (!www.isDone)
        {
            Debug.Log( www.progress * 100);
            yield return null;
        }
        yield return www;        
        string txt = "";
        if (string.IsNullOrEmpty(www.error))
        {
            var response = JsonUtility.FromJson<GameJson>(www.text);
            Debug.Log(www.text);
            Debug.Log(response.balance);
            Balance.text = response.balance.ToString();
            GameManager.instance.Balance = response.balance;
        }
        else
        {
            txt = www.error;
            Debug.Log(txt);
        }

    }



}
