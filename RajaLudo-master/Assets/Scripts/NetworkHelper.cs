using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NetworkHelper : MonoBehaviour
{
    [SerializeField] GameApiManager gameApiManager;
    History history;
    [SerializeField] TimerInButton timeInButton;
    [SerializeField] ActiverterHelper activerterHelper;
    [SerializeField] Button dropDiceButton;
    [SerializeField] Text Balance;
    [SerializeField] RectTransform WinnerImage;
    [SerializeField] RectTransform LoserImage;
    [SerializeField] Image showPlayer;
    public int PlayersCounter { get; set; }
    public int counter;
    public int count;
    public long coinsHave;
   
    private PlayerHelper _currentPlayer;
    public PlayerHelper CurrentPlayer
    {
        get { return _currentPlayer; }
        set { _currentPlayer = value; }
    }
    
    [SerializeField] AudioClip StartSound;
    [SerializeField] AudioClip CoinsChange;
    [SerializeField] AudioSource audioSound;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;        
        count = 0;        
    }
    private void Start()
    {
        PhotonNetwork.Instantiate("PlayerPrefab", Vector3.zero, Quaternion.identity, 0);        

    }

    public void StartCor()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        while (_currentPlayer == null)
            yield return null;
        history = GameObject.FindGameObjectWithTag("History").GetComponent<History>();
        GameManager.instance.IsGameOver = false;
        
        dropDiceButton.GetComponent<Animator>().enabled = false;
        dropDiceButton.GetComponentInChildren<Child>().GetComponent<Image>().enabled = false;
        dropDiceButton.enabled = false;
        audioSound.clip = StartSound;
        audioSound.Play();
        activerterHelper.SetActiveter();
        
        ShowColor();
        Balance.text = GameManager.instance.Balance.ToString();
        if (_currentPlayer.ID == 1)
            TurnOnButton(1);
    }


    public void TurnOnButton(int Id)
    {
        if (_currentPlayer.ID == Id)
        {
            dropDiceButton.enabled = true;
            dropDiceButton.GetComponentInChildren<Child>().GetComponent<Image>().enabled = true;
            dropDiceButton.GetComponent<Animator>().enabled = true;
            timeInButton.StartTimerFirst();
        }
    }

    public void Drop()
    {
        if (_currentPlayer.ID == _currentPlayer.groupNumber)
        {
            timeInButton._buttonImage.fillAmount = 1;
            timeInButton.StopTimer();
            dropDiceButton.enabled = false;
            dropDiceButton.GetComponentInChildren<Child>().GetComponent<Image>().enabled = false;
            dropDiceButton.GetComponent<Animator>().enabled = false;
            _currentPlayer.CmdCreate(_currentPlayer.ID);
            
        }
    }

    public void Move(int gruop, int id)
    {
        if (_currentPlayer.groupNumber == gruop && _currentPlayer.ID == _currentPlayer.groupNumber)
        {
            timeInButton._buttonImage.fillAmount = 1;
            timeInButton.StopTimer();
            _currentPlayer.photonView.RPC("RpcMovePin", PhotonTargets.All, gruop, id);
        }
    }

    public void ChangeGroup(int gruop, int step)
    {
        _currentPlayer.CmdChangeGroup(gruop, step);
        if (gruop == _currentPlayer.ID)
        {
            timeInButton._buttonImage.fillAmount = 1;

        }
    }


    public void ActiveterGroup(int groupnumber, int rand)
    {
        StartCoroutine(ActiveterGroupCor(groupnumber, rand));
    }

    public void CreateDice(int x)
    {
        _currentPlayer.go = Instantiate(Resources.Load("d6")as GameObject);
        _currentPlayer.go.GetComponent<Animator>().SetInteger("Show", x);
    }

    IEnumerator ActiveterGroupCor(int groupnumber, int rand)
    {
        yield return new WaitForSeconds(2.5f);
        history.AddToHistory(rand, groupnumber);

        foreach (PlayerMoveHelper player in _currentPlayer.playerMoveHelper)
        {
            if (player.group == groupnumber)
            {
                player.GetRandomInteger(rand);//передаём число в нужную группу
            }
        }
        yield return new WaitForEndOfFrame();//ждём кард
        bool flag = false; //флаг на то что есть активные игроки.
        int count = 0;
        foreach (PlayerMoveHelper player in _currentPlayer.playerMoveHelper)
        {
            if (player.states == StatesOfPlayer.Activ)//если есть активные игроки, переводим флаг
            {
                flag = true;
                count++;
            }
        }
        yield return null;//пропускаем кард
        if (!flag) // если актитвных нету, то меняем группу и даём возможность броска кубика
        {
            timeInButton.StopTimer();
            ChangeGroup(groupnumber, rand);
        }
        else if (count == 1)
        {
            yield return new WaitForSeconds(0.5f);
            foreach (PlayerMoveHelper player in _currentPlayer.playerMoveHelper)
            {
                if (player.states == StatesOfPlayer.Activ)//если есть активные игроки, переводим флаг
                {
                    Move(player.group, player.GroupID);
                }
            }
        }
        else if (_currentPlayer.ID == groupnumber)
        {
            timeInButton.StartTimerSecond();
        }
    }

    public void DestroyEnemyTokens(int group)
    {

        foreach (var item in _currentPlayer.playerMoveHelper)
        {
            if (item.group == group)
            {
                item.TakeOffCount();
                Destroy(item.gameObject);
            }
        }
        if(group == _currentPlayer.grop)
        {
            _currentPlayer.CmdChangeGroup(group, 1);
        }
        StartCoroutine(waitforframe());
    }

    public void StartWaitCor()
    {
        _currentPlayer.photonView.RPC("StartWaitCor", PhotonTargets.All);

    }

    public void DoStartWairCor()
    {
        StartCoroutine(waitforframe());
    }
    IEnumerator waitforframe()
    {
        yield return new WaitForEndOfFrame();
        _currentPlayer.UpdatePlayers();
    }

    public void ShowColor()
    {

        if (_currentPlayer.ID == 1)
        {
            showPlayer.color = Color.yellow;
        }
        if (_currentPlayer.ID == 2)
        {
            showPlayer.color = Color.green;
        }
        if (_currentPlayer.ID == 3)
        {
            showPlayer.color = Color.red;
        }
        if (_currentPlayer.ID == 4)
        {
            showPlayer.color = Color.blue;
        }
    }

    public void AddCoins(int cof, int id)
    {
        if (_currentPlayer.ID == id)
        {
            gameApiManager.SetKick(cof, true);
        }
    }

    public void ShowInHistoryKick(int IDplayer, int IDemeny, int cof)
    {
        if (_currentPlayer.ID == IDplayer)
            _currentPlayer.photonView.RPC("RpcShowHistory", PhotonTargets.All, IDplayer, IDemeny, cof);
    }

    public void ShowInHistoryFinisk(int IDplayer)
    {
        if (_currentPlayer.ID == IDplayer)
            _currentPlayer.photonView.RPC("RpcShowHistoryFinish", PhotonTargets.All, IDplayer);
    }




    public void LostCoins(int cof, int group)
    {
        if (_currentPlayer.ID == group)
            gameApiManager.SetKick(cof, false);
    }

    public void TakeOff(int takeoff, int id)
    {

        if (_currentPlayer.ID == id)
        {
            audioSound.clip = CoinsChange;
            audioSound.Play();
            
            //GameManager.instance.Balance -= (takeoff * GameManager.instance.GameCoust);
            
            //Balance.text = GameManager.instance.Balance.ToString();
            
            if (GameManager.instance.Balance < 0)
                _currentPlayer.photonView.RPC("RpcDestroyTokens", PhotonTargets.All, id);
        }

    }
    public void WinGame(int id)
    {
        if (_currentPlayer.ID == id)
        {
            gameApiManager.SetGameOver(true);
            WinnerImage.gameObject.SetActive(true);
            GameManager.instance.IsGameOver = true;
            _currentPlayer.photonView.RPC("RpcLoser", PhotonTargets.All, id);
            Destroy(_currentPlayer.go);
            Destroy(_currentPlayer);
            
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LeaveLobby();
        }
    }
    public void WinGame()
    {
        gameApiManager.SetGameOver(true);
        GameManager.instance.IsGameOver = true;
        WinnerImage.gameObject.SetActive(true);
        Destroy(_currentPlayer.go);
        Destroy(_currentPlayer);
        
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
    }

    public void Loser(int id)
    {
        if (_currentPlayer.ID != id)
        {
            gameApiManager.SetGameOver(false);
            GameManager.instance.IsGameOver = true;
            LoserImage.gameObject.SetActive(true);
            Destroy(_currentPlayer.go);
            Destroy(_currentPlayer);            
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LeaveLobby();
        }
    }
    public void Loser()
    {
        gameApiManager.SetGameOver(false);
        GameManager.instance.IsGameOver = true;
        LoserImage.gameObject.SetActive(true);
        Destroy(_currentPlayer.go);
        Destroy(_currentPlayer);        
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();

    }


}
