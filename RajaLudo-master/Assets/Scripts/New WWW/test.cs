using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {

    public Image imgtest;
    public string url;
    

    void Start () {
        StartCoroutine(getpic("Dubai.jpg"));
	}
	
    IEnumerator getpic(string name)
    {
        WWW www = new WWW(url + name);

        yield return www;

        Debug.Log(www.text);

        Texture2D texture = new Texture2D(5,5);

        www.LoadImageIntoTexture(texture);

        imgtest.sprite = Sprite.Create(texture, new Rect(0,0, texture.width, texture.height), Vector2.one / 2);
    }
}
