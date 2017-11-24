using System;
using System.Collections;
using UnityEngine;



public enum StatesOfPlayer
{
    OnBase,
    InField,
    Activ,
    Finish
}
public class PlayerMoveHelper : MonoBehaviour
{
    Color colorOnStart;
    public Transform[] wayPoints; //маршрут игрока
    public GameObject startPosition;  // Стартовая точка 
    public StatesOfPlayer states; // его статус сейчас
    public int group; //номер группы
    public int GroupID; //номер игрока в группе
    public bool onBase;    //на базе ли сейчас игрок, проверка для правильной реакции на клик, когда игрок активен    
    public int CofNow;
    int interger;   //то число что прислал рандом
    int counter;  //счётчик для проверки возможности двигаться
    private int _nowPosition;
    public int nowPosition
    {
        get { return _nowPosition; }//место в массиве позиций
        set
        {
            _nowPosition = value;            
        }
    }
   
    bool corutineReady; //доступ к корутинам движения, чтоб пока активен, нельзя было кликать по нему
    Vector2 startPoint; //стартовая позиция, чтоб вернуть на место если на него напал противник
    public GameObject PointNow; //то в какой точке сейчас игрок, для проверки
    public GameObject[] allPLayers; //список всех игроков
    Animator animator;
    Transform winnerPoint;
    NetworkHelper networkHelper;
    
    BoxCollider2D collider2d;
    [SerializeField] AudioClip KickSound;
    [SerializeField] AudioClip StepSound;
    
    


    AudioSource audioSounds;
    
    void Start()
    {
        networkHelper = FindObjectOfType<NetworkHelper>();
        colorOnStart = GetComponent<SpriteRenderer>().color;
        audioSounds = GetComponent<AudioSource>();
        CofNow = 1;
        
        PointNow = startPosition;
        allPLayers = GameObject.FindGameObjectsWithTag("Player");
        onBase = true;
        
        states = StatesOfPlayer.OnBase;
        interger = 0;
        corutineReady = true;
        startPoint = startPosition.transform.position;
        wayPoints = startPosition.GetComponent<StartPointHelper>().WayPoints;
        winnerPoint = startPosition.GetComponent<StartPointHelper>().WinnerPoint;
        collider2d = GetComponent<BoxCollider2D>();
        collider2d.enabled = false;
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    

    public void GetNewWaypoints()
    {
        if (states != StatesOfPlayer.OnBase)
        {
            wayPoints[nowPosition].GetComponent<PointsHelper>().CountPlayer--;
            if (group == 1)
            {
                wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup1--;
            }
            if (group == 2)
            {
                wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup2--;
            }
            if (group == 3)
            {
                wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup3--;
            }
            if (group == 4)
            {
                wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup4--;
            }
        }
        startPosition = GameObject.Find(startPosition.name);        
        wayPoints = startPosition.GetComponent<StartPointHelper>().WayPoints;
        winnerPoint = startPosition.GetComponent<StartPointHelper>().WinnerPoint;
        PointNow = GameObject.Find(PointNow.name);
        gameObject.transform.position = PointNow.transform.position;
        if (states != StatesOfPlayer.OnBase)
        {
            wayPoints[nowPosition].GetComponent<PointsHelper>().CountPlayer++;
            if (group == 1)
            {
                wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup1++;
            }
            if (group == 2)
            {
                wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup2++;
            }
            if (group == 3)
            {
                wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup3++;
            }
            if (group == 4)
            {
                wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup4++;
            }
        }
    }

    public void StartMove()
    {
        StartCoroutine(movePlayerInField(interger));
    }

    IEnumerator movePlayerInField(int steps)
    {
        if (states == StatesOfPlayer.Activ && corutineReady)
        {
            int MyPlayersInMyPoint = 1;
            foreach (var players in allPLayers)
            {
                if (players.name != gameObject.name)
                {
                    if (players.GetComponent<PlayerMoveHelper>().PointNow == PointNow)
                    {
                        if (players.GetComponent<PlayerMoveHelper>().group == group)
                        {
                            MyPlayersInMyPoint++;
                        }

                    }
                }
            }
                        corutineReady = false;

            foreach (var item in allPLayers)
            {
                if (item.name != gameObject.name) //если имя не как у нас, значит не этот игрок
                {
                    if (item.GetComponent<PlayerMoveHelper>().states == StatesOfPlayer.Activ)//если активны
                    {
                        item.GetComponent<PlayerMoveHelper>().SetDisactive();//выключаем активность
                    }
                }
            }
            
            if (onBase)
            {
                while (new Vector2(transform.position.x, transform.position.y) != new Vector2(wayPoints[0].position.x, wayPoints[0].position.y))
                {
                    transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), wayPoints[0].position, 0.1f);
                    yield return new WaitForSeconds(0.01f);
                }
                audioSounds.clip = StepSound;
                audioSounds.Play();
                onBase = false;
            }
            else
            {
                wayPoints[nowPosition].GetComponent<PointsHelper>().CountPlayer--;
                if(group==1)
                {
                    wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup1--;
                }
                if (group == 2)
                {
                    wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup2--;
                }
                if (group == 3)
                {
                    wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup3--;
                }
                if (group == 4)
                {
                    wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup4--;
                }

                gameObject.transform.localScale = Vector3.one;
                //двигаем нужное количество шагов
                for (int i = 0; i < steps; i++)
                {
                    nowPosition++;//меняем текущую позицию и двигаемся к следующей
                    while (new Vector2(transform.position.x, transform.position.y) != new Vector2(wayPoints[nowPosition].position.x, wayPoints[nowPosition].position.y))
                    {
                        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), wayPoints[nowPosition].position, 0.1f);
                        yield return new WaitForSeconds(0.01f);
                    }
                    audioSounds.clip = StepSound;
                    audioSounds.Play();
                    yield return new WaitForSeconds(0.2f);//пауза на точке
                }
            }

            PointNow = wayPoints[nowPosition].gameObject;//отмечаем точку для проверки
            
            //проверяем на наличие в нашей точке других игроков
            foreach (var players in allPLayers)
            {
                if (players.name != gameObject.name)
                {
                    if (players.GetComponent<PlayerMoveHelper>().PointNow == PointNow)
                    {
                        if (players.GetComponent<PlayerMoveHelper>().group != group && wayPoints[nowPosition].GetComponent<PointsHelper>().CountPlayer <= MyPlayersInMyPoint) // если не из нашей команды, то посылаем его на базу
                        {
                            players.GetComponent<PlayerMoveHelper>().StartBaseCor();                            
                            networkHelper.AddCoins(players.GetComponent<PlayerMoveHelper>().CofNow, group);
                            networkHelper.ShowInHistoryKick(group, players.GetComponent<PlayerMoveHelper>().group, players.GetComponent<PlayerMoveHelper>().CofNow);
                            audioSounds.clip = KickSound;
                            audioSounds.Play();
                        }
                    }

                }
            }
            wayPoints[nowPosition].GetComponent<PointsHelper>().CountPlayer++;
            if (group == 1)
            {
                wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup1++;
            }
            if (group == 2)
            {
                wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup2++;
            }
            if (group == 3)
            {
                wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup3++;
            }
            if (group == 4)
            {
                wayPoints[nowPosition].GetComponent<PointsHelper>().playersGroup4++;
            }           

            SetDisactive(); //деактивируемся

            if (wayPoints[nowPosition] == wayPoints[wayPoints.Length - 1])
            {
                states = StatesOfPlayer.Finish;//теперь игрок не доступен
                networkHelper.ShowInHistoryFinisk(group);
                winnerPoint.GetComponentInParent<WinnerChekHelper>().Counter++;
                winnerPoint.GetComponentInParent<WinnerChekHelper>().Win(group);                
                corutineReady = true;               
                networkHelper.StartWaitCor();
                
                Destroy(gameObject);
                foreach (var item in allPLayers)
                {
                    item.GetComponent<PlayerMoveHelper>().DoUpdateCor();
                }
                
            }
            if (nowPosition < 12)
                CofNow = 1;
            else if (nowPosition >= 12 && nowPosition < 25)
                CofNow = 2;
            else if (nowPosition >= 25 && nowPosition < 37)
                CofNow = 3;
            else
                CofNow = 4;
            corutineReady = true;            // включаем возможность корутин

            networkHelper.ChangeGroup(group, steps);  //и говорим поменять группу

        }
    }

    public void DoUpdateCor()
    {
        StartCoroutine(DoUpdatePins());
    }
    IEnumerator DoUpdatePins()
    {
        yield return new WaitForEndOfFrame();
        Array.Clear(allPLayers, 0, allPLayers.Length);
        Array.Resize(ref allPLayers, 0);
        allPLayers = GameObject.FindGameObjectsWithTag("Player");
    }

    //чтоб включить возврат на базу другим игроком

    void StartBaseCor()
    {
        
        StartCoroutine(GoToBase());
    }



    //возврат на базу
    IEnumerator GoToBase()
    {
        if (corutineReady)
        {

            corutineReady = false;
            wayPoints[nowPosition].GetComponent<PointsHelper>().CountPlayer--;
            gameObject.transform.localScale = Vector3.one;

            //двигаемся на базу
            for (int i = nowPosition; i >= 0; i--)
            {
                while (new Vector2(transform.position.x, transform.position.y) != new Vector2(wayPoints[i].position.x, wayPoints[i].position.y + 0.6f))
                {
                    transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(wayPoints[i].position.x, wayPoints[i].position.y + 0.6f), 1f);
                    yield return new WaitForSeconds(0.01f);
                }
            }
            //когда дошли до первой точки, перемещаемся на стартовую позицию
            while (new Vector2(transform.position.x, transform.position.y) != startPoint)
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), startPoint, 1f);
                yield return new WaitForSeconds(0.01f);
            }
            //приводим себя в стартовое состояние
            
            onBase = true;
            states = StatesOfPlayer.OnBase;
            corutineReady = true;
            PointNow = null;
            nowPosition = 0;
           networkHelper.LostCoins(CofNow, group);     //списывает коинты
        }
    }

    private void OnMouseDown()
    {
        networkHelper.Move(group, GroupID);
    }


    //снимаем активированное состояние
    public void SetDisactive()
    {
        animator.enabled = false;//возвращаем цвет
        GetComponent<SpriteRenderer>().color = colorOnStart;
        collider2d.enabled = false;
         
        if (onBase)//если на базе, то ставим статус
        {
            states = StatesOfPlayer.OnBase;
        }
        else //если в поле
            states = StatesOfPlayer.InField;
    }

    //Получаем рандомное число 
    public void GetRandomInteger(int randInt)
    {
        interger = randInt;       //присваем значение внутренней переменной

        if (states == StatesOfPlayer.InField || (states == StatesOfPlayer.OnBase && randInt == 6))
        {
            getActive(interger); //если игрок уже в поле, проводим проверку.
        }

    }

    //проверка игрока в поле
    void getActive(int steps)
    {

        //смотрим где сейчас и добавляем количество шагов.
        counter = nowPosition;
        counter += steps;
        //если есть куда идти и впереди нету блока, то автируемся и меняем цвет

        if (onBase)
        {
            collider2d.enabled = true;
            states = StatesOfPlayer.Activ; // активируем если игрок на базе и выпало 6
            animator.enabled = true;
        }
        else if (counter < wayPoints.Length)
        {
            bool flag = true;
          
            for (int i = 1; i < steps; i++)
            {
                
                //если впереди у точки маршрута есть двое игроков и если они из вражеской команды, то ставим флаг
                if (/*wayPoints[nowPosition + i].GetComponent<PointsHelper>().CountPlayer > 1*/
                    /*&& */wayPoints[nowPosition + i].GetComponent<PointsHelper>().MainGroup != group
                    && wayPoints[nowPosition].GetComponent<PointsHelper>().CountPlayer < wayPoints[nowPosition + i].GetComponent<PointsHelper>().CountPlayer)
                    flag = false;
            }
            if (flag)
            {
                states = StatesOfPlayer.Activ;
                collider2d.enabled = true;
                animator.enabled = true;

            }
        }

    }

    public void TakeOffCount()
    {
        wayPoints[nowPosition].GetComponent<PointsHelper>().CountPlayer--;
    }


}





