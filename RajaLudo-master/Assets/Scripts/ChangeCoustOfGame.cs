
using System;

using UnityEngine;
using UnityEngine.UI;



public class ChangeCoustOfGame : MonoBehaviour
{
    public string Table_id;
    public int EntryFee;
    Text coust;
    int balance;
    
    Button thisButton;
    int _remembeInt;

    private void OnEnable()
    {
        coust = GetComponentInChildren<Text>();
        thisButton = GetComponent<Button>();


        if (EntryFee * 20 > GameManager.instance.Balance)
        {
            thisButton.enabled = false;
            coust.text = "Not Enough coins";
        }
        else 
        {
            thisButton.enabled = true;
            coust.text = EntryFee.ToString();
        }

        GetComponent<Button>().onClick.AddListener(() => { DoJoinRandomRoom(); });
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }

    

    public void DoJoinRandomRoom()
    {
        GameManager.instance.DoJoinRoom(Table_id, EntryFee);
    }
}
