using UnityEngine;
using UnityEngine.UI;

public class LastPointHelper : MonoBehaviour {

   
    [SerializeField] GameObject[] panel;

    private void Start()
    {
        if(GameManager.instance.CountPlayersInGame==2)
        {
            panel[0].SetActive(true);
            panel[1].SetActive(true);
        }
        else
        {
            for (int i = 0; i < panel.Length; i++)
            {
                panel[i].SetActive(true);
            }
        }
    }

}

  
