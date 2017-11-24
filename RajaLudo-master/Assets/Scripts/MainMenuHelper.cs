using UnityEngine;

public class MainMenuHelper : MonoBehaviour {

    [SerializeField] RectTransform Header;
    private void OnEnable()
    {
        Header.gameObject.SetActive(true);
    }
}
