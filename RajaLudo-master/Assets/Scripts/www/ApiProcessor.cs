using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class ApiProcessor : MonoBehaviour
{
    [SerializeField] InputField UserNameInput;
    [SerializeField] InputField PasswordInput;
    [SerializeField] GameObject warrying;
    [SerializeField] GameObject ThisPanel;
    [SerializeField] GameObject MainPanel;
    
    
    [SerializeField]
    private string configurationAPI;
    public  string ConfigAPI { get { return configurationAPI; } }

    public string User_name;
    public string Password;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            GetAPI();
        }
    }


    public void GetName()
    {
        User_name = UserNameInput.text;

        if (string.IsNullOrEmpty(Password)) { }
        else
            GetAPI();
    }

    public void GetPassword()
    {
        Password = PasswordInput.text;

        if (string.IsNullOrEmpty(User_name)) { }
        else
            GetAPI();
    }


    private void GetAPI()
    {
        CreateJson json = new CreateJson();
        json.user_name = User_name;
        json.password = Password;                                                                                     
    
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");
        byte[] pData = System.Text.Encoding.UTF8.GetBytes(json.SaveToString());
        WWW www = new WWW(ConfigAPI, pData, headers);

        StartCoroutine(WaitForWWW(www));

        Debug.Log("getapi");
    }


    IEnumerator WaitForWWW(WWW www)
    {
        yield return www;

        Debug.Log(www.text);
       
        string txt = "";

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Getting login...");
            var response = Responce.CreateFromJSON<AssetJson>(www.text);
            if (response.success)
            {
                SetInformationToPlayer(response);
                MainPanel.SetActive(true);
                ThisPanel.SetActive(false);
                
            }
            else
            {
                warrying.SetActive(true);
            }
        }
        else
        {
            txt = www.error;
            Debug.Log(txt);
        }
    }


    void SetInformationToPlayer(Responce<AssetJson> info)
    {
        GameManager.instance.Balance = Convert.ToInt64(info.data.balance);
        GameManager.instance.ID = info.data._id;
        GameManager.instance.FirstName = info.data.first_name;
        GameManager.instance.LastName = info.data.last_name;
        GameManager.instance.IsLogin = true;
    }


}

