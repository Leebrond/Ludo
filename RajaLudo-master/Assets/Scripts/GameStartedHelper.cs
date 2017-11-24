using UnityEngine;
public class GameStartedHelper : MonoBehaviour
{
    public Transform[] StartPoints;
    
    public void CreatePlayers()
    {
        int x = 0;
        if (GameManager.instance.CountPlayersInGame == 2)
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++, x++)
                {
                    GameObject player = Instantiate(Resources.Load("Player" + i + "x" + j) as GameObject, StartPoints[x].position, Quaternion.identity);
                    player.GetComponent<PlayerMoveHelper>().startPosition = StartPoints[x].gameObject;
                    player.GetComponent<PlayerMoveHelper>().GroupID = j;
                }
                x = x + 4;
                i++;

            }
        }
        else
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++, x++)
                {
                    GameObject player = Instantiate(Resources.Load("Player" + i + "x" + j) as GameObject, StartPoints[x].position, Quaternion.identity);
                    player.GetComponent<PlayerMoveHelper>().startPosition = StartPoints[x].gameObject;
                    player.GetComponent<PlayerMoveHelper>().GroupID = j;
                }

            }
        }
    }
}
