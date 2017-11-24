using UnityEngine;
using UnityEngine.UI;

public class WinnerChekHelper : MonoBehaviour
{
    [SerializeField] AudioClip TokenFinish;
    [SerializeField] AudioSource audioSource;
    private int counter;
    public int Counter { get { return counter; } set
        {
            counter = value;
            tokens[counter - 1].gameObject.SetActive(true);
            if(counter<4)
                audioSource.PlayOneShot(TokenFinish);
        } }
    [SerializeField] NetworkHelper gameHelper;
    [SerializeField] Image[] tokens;
   
    public void Win(int id)
    {

        if (Counter == 4)
        {            
            gameHelper.WinGame(id);
        }
    }
}
