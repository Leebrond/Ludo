using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Login : MonoBehaviour {



    [SerializeField] InputField UserNameInput;
    [SerializeField] InputField PasswordInput;
    [SerializeField] GameObject warrying;
    [SerializeField] GameObject ThisPanel;
    [SerializeField] GameObject MainPanel;

    
    [SerializeField]
    private string configurationAPI;
    public string ConfigAPI { get { return configurationAPI; } }

    public string User_name;
    public string Password;



    void Update()
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
        User_name = UserNameInput.text;
        Password = PasswordInput.text;

        WWWForm form = new WWWForm();
        form.AddField("usernamePost", User_name);
        form.AddField("passwordPost", Password);

        WWW www = new WWW(ConfigAPI, form);

        StartCoroutine(WaitForWWW(www));

        Debug.Log("getapi");
    }


    IEnumerator WaitForWWW(WWW www)
    {
        yield return www;
        
        string txt = "";
        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Getting login...");

            string[] temp = www.text.Split(';');

            Debug.Log(www.text);

            if (temp[0] == "\nLogin success ")
            {
                // SetInformationToPlayer(response);
                Debug.Log(www.text);
                SetInfoPlayer(temp);
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


    void SetInfoPlayer(string[] info)
    {
        GameManager.instance.Balance = int.Parse(info[1]);
        GameManager.instance.IsLogin = true;
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
