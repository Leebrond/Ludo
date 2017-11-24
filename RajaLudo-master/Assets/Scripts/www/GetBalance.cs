using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//public class GetBalance : MonoBehaviour {

//    [SerializeField]
//    private string ApiUrl;
//    public  string APIUrl { get { return ApiUrl; } }

//    private void Start()
//    {

//        if (PlayerPrefs.HasKey("SendToDBint") || PlayerPrefs.HasKey("SendToDBsrting"))
//        {
//            GetInfoForApi(PlayerPrefs.GetString("SendToDBsrting"), PlayerPrefs.GetInt("SendToDBint"));           
//        }
//    }

//    public void GetInfoForApi()
//    {
//        Debug.Log("Setting balance...");
//        JsonBalance balance = new JsonBalance();
//        balance.user_id = GameManager.instance.ID;
//        balance.win_amount = GameManager.instance.CointsInGame;
//        Debug.Log(balance.SaveToString());

//        Dictionary<string, string> headers = new Dictionary<string, string>();
//        headers.Add("Content-Type", "application/json");
//        byte[] form = System.Text.Encoding.UTF8.GetBytes(balance.SaveToString());
//        WWW www = new WWW(APIUrl, form, headers);
//        StartCoroutine(GetBalancePlayer(www));
//    }

//    public void GetInfoForApi(string ID, int CointInGame)
//    {
//        Debug.Log("Setting balance...");
//        JsonBalance balance = new JsonBalance();
//        balance.user_id = GameManager.instance.ID;
//        balance.win_amount = GameManager.instance.CointsInGame;
//        Debug.Log(balance.SaveToString());

//        Dictionary<string, string> headers = new Dictionary<string, string>();
//        headers.Add("Content-Type", "application/json");
//        byte[] form = System.Text.Encoding.UTF8.GetBytes(balance.SaveToString());
//        WWW www = new WWW(APIUrl, form, headers);
//        StartCoroutine(GetBalancePlayer(www));
//    }
//    IEnumerator GetBalancePlayer(WWW www)
//    {
//        yield return www;
//        string txt = "";
//        if (string.IsNullOrEmpty(www.error))
//        {
//            if (PlayerPrefs.HasKey("SendToDBint") || PlayerPrefs.HasKey("SendToDBsrting"))
//            {
//                PlayerPrefs.DeleteKey("SendToDBint");
//                PlayerPrefs.DeleteKey("SendToDBsrting");
//            }
//            Debug.Log("Getting balance...");
//            var response = Responce.CreateFromJSON<AssetJson>(www.text);
//            Debug.Log(www.text);
//            Debug.Log(response.data.balance);
//            GameManager.instance.Balance = response.data.balance;
//        }
//        else
//        {
//            txt = www.error;
//            Debug.Log(txt);
//        }

//    }



//}
