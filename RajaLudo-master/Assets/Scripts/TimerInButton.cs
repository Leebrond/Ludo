using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerInButton : MonoBehaviour
{

    public Image _buttonImage;
    float Timer;
    [SerializeField] NetworkHelper _networkHelper;

    // Use this for initialization
    void Start()
    {
        Timer = 25f;
       
    }

    public void StartTimerFirst()
    {
        StopAllCoroutines();

        StartCoroutine(TimeStartFirst());
    }
    public void StartTimerSecond()
    {
        StopAllCoroutines();
        StartCoroutine(TimeStartSecond());
    }

    IEnumerator TimeStartFirst()
    {
        _buttonImage.fillAmount = 1f;
        do
        {
            _buttonImage.fillAmount -= 1f / Timer * Time.deltaTime;
            yield return null;
        }
        while (_buttonImage.fillAmount != 0);
        _networkHelper.Drop();   
    }
    IEnumerator TimeStartSecond()
    {        
        _buttonImage.fillAmount = 1f;
        do
        {
            _buttonImage.fillAmount -= 1f / Timer * Time.deltaTime;
            yield return null;
        }
        while (_buttonImage.fillAmount != 0);
        bool NoOnField = true;
        foreach (PlayerMoveHelper player in _networkHelper.CurrentPlayer.playerMoveHelper)
        {
            if (player.states == StatesOfPlayer.Activ && player.onBase == false)//если есть активные игроки, переводим флаг
            {
                _networkHelper.Move(player.group, player.GroupID);                
                NoOnField = false;
                StopAllCoroutines();
                break;
            }
        }
        if (NoOnField)
        {
            foreach (PlayerMoveHelper player in _networkHelper.CurrentPlayer.playerMoveHelper)
            {
                if (player.states == StatesOfPlayer.Activ )//если есть активные игроки на базе
                {
                    _networkHelper.Move(player.group, player.GroupID);                                
                    StopAllCoroutines();
                    break;
                }
            }
        }

    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }








}
