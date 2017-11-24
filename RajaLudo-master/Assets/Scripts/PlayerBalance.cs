
using UnityEngine;
using UnityEngine.UI;


public class PlayerBalance : MonoBehaviour
{

    private long _balance;
    Text balanceText;

    public long Balance
    {
        get { return _balance; }
        set
        {
            _balance = value;

            if (_balance < 0)
                _balance = 0;
        }
    }

    private void Start()
    {
        balanceText = GetComponent<Text>();
        
    }
    private void Update()
    {
        if (balanceText != null)
        {
            _balance = GameManager.instance.Balance;
            balanceText.text = _balance.ToString();
        }
    }

}



