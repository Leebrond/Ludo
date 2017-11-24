using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RandomHelper : MonoBehaviour
{
    public int groupNumber;
    public GameObject dice;
    GameObject[] allPlayers;
   
    [SerializeField] Button button;
    public GameObject[] PS;
    NetworkHelper networkHelper;
    private void Awake()
    {
        groupNumber = 1;
    }
    private void Start()
    {
        networkHelper = FindObjectOfType<NetworkHelper>();
        FindObjectOfType<GameStartedHelper>().CreatePlayers();
        
        allPlayers = GameObject.FindGameObjectsWithTag("Player");
    }

    

    public void GetActiveter()
    {
        foreach (var item in PS)
        {
            item.SetActive(false);
        }
        OnGroup(groupNumber);
    }
 
    
    public void OffGroup(int group)
    {
        PS[group - 1].SetActive(false);
    }

    public void OnGroup(int group)
    {
        groupNumber = group;
        PS[group - 1].SetActive(true);
    }

    public void ActiveterGroup(int groupnumber, int rand)
    {
        StartCoroutine(ActiveterGroupCor(groupnumber, rand));
    }

    IEnumerator ActiveterGroupCor(int groupnumber, int rand)
    {
        
        yield return new WaitForSeconds(2f);
        foreach (GameObject player in allPlayers)
        {
            if (player.GetComponent<PlayerMoveHelper>().group == groupnumber)
            {
                player.GetComponent<PlayerMoveHelper>().GetRandomInteger(rand);//передаём число в нужную группу
            }
        }
        yield return new WaitForEndOfFrame();//ждём кард
        bool flag = false; //флаг на то что есть активные игроки.
        foreach (GameObject player in allPlayers)
        {
            if (player.GetComponent<PlayerMoveHelper>().states == StatesOfPlayer.Activ)//если есть активные игроки, переводим флаг
            {
                flag = true;
            }
        }
        yield return null;//пропускаем кард
        if (!flag) // если актитвных нету, то меняем группу и даём возможность броска кубика
            networkHelper.ChangeGroup(groupnumber, rand);
    }
}
