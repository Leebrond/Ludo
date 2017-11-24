using UnityEngine;
using UnityEngine.UI;

public class ViewMode : MonoBehaviour {
    
    [SerializeField] GameObject ClassicView;
    [SerializeField] GameObject View3d;
    Text _buttonText;
    bool Is2D;

    private void Awake()
    {
        View3d.SetActive(false);
    }

    void Start ()
    {
        _buttonText = GetComponentInChildren<Text>();
        Is2D = true;
        
        
	}

    public void ChangeView()
    {
        if(Is2D)
        {
            _buttonText.text = "Classic View";
            Is2D = false;
            View3d.SetActive(!View3d.activeSelf);            
            ClassicView.SetActive(!ClassicView.activeSelf);
            View3d.GetComponent<ActiverterHelper>().SetActiveter();
            wait();
        }
        else
        {
            _buttonText.text = "3D View";
            Is2D = true;
            View3d.SetActive(!View3d.activeSelf);
            ClassicView.SetActive(!ClassicView.activeSelf);
            ClassicView.GetComponent<ActiverterHelper>().SetActiveter();
            wait();
        }
    }

    void wait()
    {
       
        PlayerMoveHelper[] tokens = FindObjectsOfType<PlayerMoveHelper>();
        foreach (var token in tokens)
        {
            token.GetNewWaypoints();
        }
    }
	


}
