using UnityEngine;
using UnityEngine.UI;

public class History : MonoBehaviour
{

    public RectTransform AddTextObj;
    public RectTransform Scroll;

    private void Start()
    {
        Scroll = GetComponent<RectTransform>();
        AddTextObj = Resources.Load<RectTransform>("History");
    }

    public void AddToHistory(int text, int ColorText)
    {
        RectTransform add = Instantiate(AddTextObj);
        add.transform.SetParent(Scroll, false);
        //add.transform.localScale = Vector3.one;

        add.transform.SetSiblingIndex(0);

        if (ColorText == 1)
        {
            add.GetComponent<Text>().text = "Yellow: " + text;
            add.GetComponent<Text>().color = Color.yellow;
        }
        if (ColorText == 2)
        {
            add.GetComponent<Text>().text = "Green: " + text;
            add.GetComponent<Text>().color = Color.green;
        }
        if (ColorText == 3)
        {
            add.GetComponent<Text>().text = "Red: " + text;
            add.GetComponent<Text>().color = Color.red;
        }
        if (ColorText == 4)
        {
            add.GetComponent<Text>().text = "Blue: " + text;
            add.GetComponent<Text>().color = Color.blue;
        }
    }
    public void AddToHistoryKick(int Player, int Enemy, int cof)
    {
        RectTransform add = Instantiate(AddTextObj);
        Text textcop = add.GetComponent<Text>();
        
        add.transform.SetParent(Scroll, false);
        
        add.transform.SetSiblingIndex(0);
        string textOne = null ;
        string textTwo = null;
       
        if (Player == 1)
        {
            textOne = "Yellow kick ";
            textcop.color = Color.yellow;
        }
        if (Player == 2)
        {
            textOne = "Green kick ";
            textcop.color = Color.green;
        }
        if (Player == 3)
        {
            textOne = "Red kick ";
            textcop.color = Color.red;
        }
        if (Player == 4)
        {
            textOne = "Blue kick ";
            textcop.color = Color.blue;
        }

        if (Enemy == 1)
        {
            textTwo = "Yellow token x " + cof;
      
        }
        if (Enemy == 2)
        {
            textTwo = "Green token x " + cof;
           
        }
        if (Enemy == 3)
        {
            textTwo = "Red token x " + cof;
          
        }
        if (Enemy == 4)
        {
            textTwo = "Blue token x " + cof;
           
        }
        textcop.text = textOne + textTwo;

    }
    public void AddToHistoryFinish(int ColorText)
    {
        RectTransform add = Instantiate(AddTextObj);
        add.transform.SetParent(Scroll, false);
        
        add.transform.SetSiblingIndex(0);
        add.GetComponent<Text>().text = "Player put token to the finish base";
        if (ColorText == 1)
        {
            add.GetComponent<Text>().text = "Yellow put token to the finish base";
            add.GetComponent<Text>().color = Color.yellow;
        }
        if (ColorText == 2)
        {
            add.GetComponent<Text>().text = "Green put token to the finish base";
            add.GetComponent<Text>().color = Color.green;
        }
        if (ColorText == 3)
        {
            add.GetComponent<Text>().text = "Red put token to the finish base";
            add.GetComponent<Text>().color = Color.red;
        }
        if (ColorText == 4)
        {
            add.GetComponent<Text>().text = "Blue put token to the finish base";
            add.GetComponent<Text>().color = Color.blue;
        }
    }
}
