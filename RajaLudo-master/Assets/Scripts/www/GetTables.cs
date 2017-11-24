using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GetTables : MonoBehaviour {

    [SerializeField] Transform FourPlayerTransform;
    [SerializeField] Transform TwoPlayerTransform;
    [SerializeField] GameObject PrefabTable;
    [SerializeField] Sprite[] sprites;
    

    [SerializeField]
    private  string _url;
    public  string Url { get { return _url; } }

    private void Start()
    {
        GetAPI();
       
    }
    public void GetAPI()
    {
        WWW www = new WWW(Url);
        StartCoroutine(WaitForWWW(www));
    }
    IEnumerator WaitForWWW(WWW www)
    {
        yield return www;
        Debug.Log(www.text);
        string txt = "";
        if (string.IsNullOrEmpty(www.error))
        {
            var response = ResponceTable.CreateFromJSON<TableJson>(www.text);
            SetTables(response);

        }
        else
        {
            txt = www.error;
            Debug.Log(txt);
        }
    }

    void SetTables(ResponceTable<TableJson> tables)
    {
        int forFour = 2000;
        int forTwo = 2000;

        foreach (var item in tables.data)
        {
            if(item.table_type == "4")
            {
                GameObject but = Instantiate(PrefabTable);
                but.GetComponent<ChangeCoustOfGame>().EntryFee = item.fee;
                but.GetComponent<ChangeCoustOfGame>().Table_id = item._id;
                
                FourPlayerTransform.gameObject.SetActive(true);
                FourPlayerTransform.GetComponentInChildren<HorizontalLayoutGroup>().padding.left = forFour;
                if (forFour > 0)
                    forFour -= 1000;
                else
                    forFour = 0;
                but.transform.SetParent(FourPlayerTransform.GetComponentInChildren<HorizontalLayoutGroup>().transform, false);               
                but.GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
                FourPlayerTransform.gameObject.SetActive(false);
            }
            if (item.table_type == "2")
            {
                GameObject but = Instantiate(PrefabTable);
                but.GetComponent<ChangeCoustOfGame>().EntryFee = item.fee;
                but.GetComponent<ChangeCoustOfGame>().Table_id = item._id;
                
                TwoPlayerTransform.gameObject.SetActive(true);
                TwoPlayerTransform.GetComponentInChildren<HorizontalLayoutGroup>().padding.left = forTwo;
                if (forTwo > 0)
                    forTwo -= 1000;
                else
                    forTwo = 0;
                but.transform.SetParent(TwoPlayerTransform.GetComponentInChildren<HorizontalLayoutGroup>().transform, false);               
                but.GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
                TwoPlayerTransform.gameObject.SetActive(false);
            }

        }
    }
}
