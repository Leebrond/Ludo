using UnityEngine;
using UnityEngine.EventSystems;

public class TurnOffGame : MonoBehaviour
{


   
    [SerializeField] GameObject BackPanel;
    [SerializeField] GameObject ButtonOff;
    [SerializeField] NetworkHelper gameHelper;
    // Use this for initialization
    void Start()
    {
        BackPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            BackPanel.SetActive(!BackPanel.gameObject.activeSelf);
        }

        if (Input.GetMouseButtonDown(0))// Любое действие
        {
            //Если текущий объект не из этого списка
            if (EventSystem.current.currentSelectedGameObject != ButtonOff)
                BackPanel.SetActive(!gameObject.activeSelf);
            else
            {
                gameHelper.Loser();
                BackPanel.SetActive(!gameObject.activeSelf);
            }
        }
    }



}
