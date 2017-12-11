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

    public string urlPic;
    public Transform tfContent;

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
                //but.GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
                FourPlayerTransform.gameObject.SetActive(false);
                StartCoroutine(GetPic(item.table_img, but.GetComponent<Image>()));
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
                
               //but.GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
                TwoPlayerTransform.gameObject.SetActive(false);
                StartCoroutine(GetPic(item.table_img, but.GetComponent<Image>()));
            }
        }

        int contentCount = tfContent.childCount;
        float contentWidth = (contentCount * 1000f) + (1100 * (contentCount - 1));
        tfContent.GetComponent<RectTransform>().sizeDelta = new Vector2(contentWidth, 1494f);
    }


    IEnumerator GetPic(string path, Image but)
    {
        string path2 = path.Remove(0, 6);
        Debug.Log(path2);
        WWW www = new WWW(urlPic + path2);
        yield return www;

        Debug.Log(www.text);
        
        Texture2D texture = new Texture2D(1, 1);
        www.LoadImageIntoTexture(texture);
        but.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one / 2);
    }
}
