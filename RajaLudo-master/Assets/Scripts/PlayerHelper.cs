
using System.Collections;
using UnityEngine;
using System;


public class PlayerHelper : Photon.PunBehaviour
{

    History history;
    int PlayerOnGame;
    private int id;
    public int ID
    {
        get { return id; }
        set
        {
            id = value;
            if (id == 2 && GameManager.instance.CountPlayersInGame == 2)
                id = 3;
        }
    }
    NetworkHelper networkHelper;
    RandomHelper randomHelper;
    public PlayerMoveHelper[] playerMoveHelper;
    int diceDrowCounter;
    public GameObject go;
    public int grop;
    public int groupNumber;
    public PlayerMoveHelper[] allPlayers;
    int random1, random2;
    int starter;
    GameManager gameManager;
    int checker;
    public int gameCoust;

    void Start()
    {
        PhotonNetwork.sendRate = 20;
        PhotonNetwork.sendRateOnSerialize = 10;
        StartCoroutine(wait());
        checker++;
    }

    IEnumerator wait()
    {
        do
        {
            networkHelper = FindObjectOfType<NetworkHelper>();
            yield return null;
        }
        while (networkHelper == null);

        do
        {
            gameManager = FindObjectOfType<GameManager>();
            yield return null;
        }
        while (gameManager == null);
        networkHelper.PlayersCounter++;
        randomHelper = FindObjectOfType<RandomHelper>();
        history = GameObject.FindGameObjectWithTag("History").GetComponent<History>();
        PlayerOnGame = gameManager.CountPlayersInGame;
        UpdatePlayers();
        grop = 1;
        groupNumber = 1;       
        ID = photonView.ownerId;        
        if (photonView.isMine)
        {
            networkHelper.CurrentPlayer = this;
            networkHelper.StartCor();
        }
    }

    public void UpdatePlayers()
    {
        Array.Clear(playerMoveHelper, 0, playerMoveHelper.Length);       
        Array.Resize(ref playerMoveHelper, 0);       
        playerMoveHelper = FindObjectsOfType<PlayerMoveHelper>();
        foreach (var item in playerMoveHelper)
        {
            Array.Clear(item.allPLayers, 0, item.allPLayers.Length);
            Array.Resize(ref item.allPLayers, 0);
            item.allPLayers = GameObject.FindGameObjectsWithTag("Player");
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }


    public void CmdCreate(int ID)
    {
        diceDrowCounter++;
        int sender;
        random1 = UnityEngine.Random.Range(UnityEngine.Random.Range(1, UnityEngine.Random.Range(1,7)), 7);
        if (random1 == 6)
            checker++;
        else
            checker = 0;
        if (checker > 3)
        {
            random1 = UnityEngine.Random.Range(UnityEngine.Random.Range(1, UnityEngine.Random.Range(1, 6)), 6);
            checker = 0;
        }
        sender = random1 * 10;
        random2 = UnityEngine.Random.Range(1, 4);
        sender += random2;
        if (starter != 6)
            starter = random1;
        if (diceDrowCounter < 4 && starter != 6)
        {
            photonView.RPC("RpcDropDice", PhotonTargets.All, random1, sender, ID);
        }
        else
        {
            photonView.RPC("RpcDropDice", PhotonTargets.All, 6, 6 * 10 + random2, ID);
            diceDrowCounter = 0;
            starter = 0;
        }
    }

    [PunRPC]
    public void StartWaitCor()
    {
        networkHelper.DoStartWairCor();
    }

    [PunRPC]
    public void RpcLostCoins(int lost, int id)
    {
        networkHelper.TakeOff(lost, id);
    }


    [PunRPC]
    void RpcShowHistory(int IDplayer, int IDenemy, int cof)
    {
        history.AddToHistoryKick(IDplayer, IDenemy, cof);
    }

    [PunRPC]
    public void RpcDropDice(int rand,int sender, int id)
    {
        dice[] allDice = FindObjectsOfType<dice>();
        foreach (var item in allDice)
        {
            Destroy(item.gameObject);
        }
        networkHelper.CreateDice(sender);
        networkHelper.ActiveterGroup(id, rand);        
    }


    [PunRPC]
    public void RpcMovePin(int gr, int idg)
    {
        foreach (PlayerMoveHelper pin in playerMoveHelper)
        {
            if (pin.group == gr && pin.GroupID == idg)
            {
                pin.StartMove();
            }
        }
    }


    public void CmdChangeGroup(int group, int step) // изменение номера группы
    {
        PlayerHelper[] allPlayersInGame = FindObjectsOfType<PlayerHelper>();
        if (PlayerOnGame != 2)
        {
            photonView.RPC("RpcOffGroup", PhotonTargets.All, group);
            if (step != 6)
            {

                if (grop != 4)
                    grop++;
                else
                    grop = 1;
                bool flag = true;
                foreach (var item in allPlayersInGame)
                {
                    if (item.ID == grop)
                    {
                        photonView.RPC("RpcChangeGroup", PhotonTargets.All, grop);
                        flag = false;
                    }
                }
                if (flag)
                {                   
                    
                        //photonView.RPC("RpcDestroyTokens", PhotonTargets.All, grop);
                        CmdChangeGroup(grop, 1);                  
                        //photonView.RPC("RpcDestroyTokens", PhotonTargets.All, grop);
                        //CmdChangeGroup(1, 1);                   
                }

            }
            else if (step == 6)
            {
                photonView.RPC("RpcOnGroup", PhotonTargets.All, group);
            }
        }
        else
        {
            photonView.RPC("RpcOffGroup", PhotonTargets.All, group);
            if (step != 6)
            {
                if (grop == 3)
                    grop = 1;
                else
                    grop = 3;
                photonView.RPC("RpcChangeGroup", PhotonTargets.All, grop);

            }
            else if (step == 6)
            {
                photonView.RPC("RpcOnGroup", PhotonTargets.All, group);
            }
        }
    }

    [PunRPC]
    void RpcOffGroup(int group)
    {
        randomHelper.OffGroup(group);
    }
    [PunRPC]
    void RpcOnGroup(int group)
    {
        randomHelper.OnGroup(group);
        if (group == ID)
            networkHelper.TurnOnButton(ID);
    }

    [PunRPC]
    void RpcChangeGroup(int group)
    {
        groupNumber = group;
        randomHelper.OnGroup(group);
        if (group == ID)
            networkHelper.TurnOnButton(ID);
    }



    [PunRPC]
    void RpcLoser(int id)
    {
        networkHelper.Loser(id);
    }


    [PunRPC]
    void RpcDestroyTokens(int gruop)
    {
        networkHelper.DestroyEnemyTokens(gruop);
    }

    [PunRPC]
    void RpcShowHistoryFinish(int IDplayer)
    {
        history.AddToHistoryFinish(IDplayer);
    }
}
