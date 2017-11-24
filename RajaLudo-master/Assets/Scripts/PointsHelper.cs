using UnityEngine;

public class PointsHelper : MonoBehaviour
{
    [SerializeField] bool IsHorizontal=true;
    private int _counterPlayer;

    public int CountPlayer
    {
        get { return _counterPlayer; }
        set
        {
            _counterPlayer = value;
            ChekSide();
        }
    }
    public int playersGroup1
    {
        get { return _playerGroup1; }
        set
        {
            _playerGroup1 = value;
            ChekMain();
        }
    }
    private int _playerGroup1;

    public int playersGroup2
    {
        get { return _playerGroup2; }
        set
        {
            _playerGroup2 = value;
            ChekMain();
        }
    }
    private int _playerGroup2;
    public int playersGroup3
    {
        get { return _playerGroup3; }
        set
        {
            _playerGroup3 = value;
            ChekMain();
        }
    }
    private int _playerGroup3;
    public int playersGroup4
    {
        get { return _playerGroup4; }
        set
        {
            _playerGroup4 = value;
            ChekMain();
        }
    }
    private int _playerGroup4;

    public int MainGroup = 0;

    void ChekMain()
    {
        if (_playerGroup1 > _playerGroup2 && _playerGroup1 > _playerGroup3 && _playerGroup1 > _playerGroup4)
            MainGroup = 1;
        if (_playerGroup2 > _playerGroup1 && _playerGroup2 > _playerGroup3 && _playerGroup2 > _playerGroup4)
            MainGroup = 2;
        if (_playerGroup3 > _playerGroup2 && _playerGroup3 > _playerGroup1 && _playerGroup3 > _playerGroup4)
            MainGroup = 3;
        if (_playerGroup4 > _playerGroup2 && _playerGroup4 > _playerGroup3 && _playerGroup4 > _playerGroup1)
            MainGroup = 4;
    }

    void ChekSide()
    {
        if (CountPlayer != 0)
        {
            PlayerMoveHelper[] allTokens = FindObjectsOfType<PlayerMoveHelper>();
            int x = 0;

            foreach (PlayerMoveHelper token in allTokens)
            {
                if (token.PointNow == gameObject)
                {
                    if (!IsHorizontal)
                    {
                        if (CountPlayer == 1)
                        {
                            token.transform.position = gameObject.transform.position;
                            token.gameObject.transform.localScale = Vector3.one;
                        }
                        if (CountPlayer == 2)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 3)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.3f, transform.localScale.y - 0.3f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
                            }
                            if (x == 2)
                                token.transform.position = gameObject.transform.position;
                            x++;
                        }
                        if (CountPlayer == 4)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.4f, transform.localScale.y - 0.4f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 5)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.5f, transform.localScale.y - 0.5f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = gameObject.transform.position;
                            }
                            x++;
                        }
                        if (CountPlayer == 6)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.4f, transform.localScale.y - 0.4f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.075f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 5)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.075f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 7)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.4f, transform.localScale.y - 0.4f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.075f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 5)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.075f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 6)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 8)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.4f, transform.localScale.y - 0.4f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.15f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 5)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.15f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 6)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.075f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 7)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.075f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 9)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.5f, transform.localScale.y - 0.5f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 5)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.15f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 6)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.075f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 7)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.075f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 8)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.15f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 10)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.5f, transform.localScale.y - 0.5f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 5)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 6)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 7)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 8)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 9)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 11)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.6f, transform.localScale.y - 0.6f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.15f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 5)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.15f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 6)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 7)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 8)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 9)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 10)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 12)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.6f, transform.localScale.y - 0.6f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.15f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 5)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.15f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 6)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 7)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 8)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 9)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 10)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.15f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 11)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.15f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            x++;
                        }
                    }
                    else
                    {
                        if (CountPlayer == 1)
                        {
                            token.transform.position = gameObject.transform.position;
                            token.gameObject.transform.localScale = Vector3.one;
                        }
                        if (CountPlayer == 2)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 3)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.3f, transform.localScale.y - 0.3f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                                token.transform.position = gameObject.transform.position;
                            x++;
                        }
                        if (CountPlayer == 4)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.4f, transform.localScale.y - 0.4f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 5)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.5f, transform.localScale.y - 0.5f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = gameObject.transform.position;
                            }
                            x++;
                        }
                        if (CountPlayer == 6)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.4f, transform.localScale.y - 0.4f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x -0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.075f, gameObject.transform.position.z);
                            }
                            if (x == 5)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.075f, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 7)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.4f, transform.localScale.y - 0.4f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.075f, gameObject.transform.position.z);
                            }
                            if (x == 5)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.075f, gameObject.transform.position.z);
                            }
                            if (x == 6)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 8)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.4f, transform.localScale.y - 0.4f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.15f, gameObject.transform.position.z);
                            }
                            if (x == 5)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.15f, gameObject.transform.position.z);
                            }
                            if (x == 6)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.075f, gameObject.transform.position.z);
                            }
                            if (x == 7)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.075f, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 9)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.5f, transform.localScale.y - 0.5f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
                            }
                            if (x == 5)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.15f, gameObject.transform.position.z);
                            }
                            if (x == 6)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.075f, gameObject.transform.position.z);
                            }
                            if (x == 7)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.075f, gameObject.transform.position.z);
                            }
                            if (x == 8)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.15f, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 10)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.5f, transform.localScale.y - 0.5f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y , gameObject.transform.position.z);
                            }
                            if (x == 5)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y , gameObject.transform.position.z);
                            }
                            if (x == 6)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 7)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 8)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 9)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 11)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.6f, transform.localScale.y - 0.6f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.15f, gameObject.transform.position.z);
                            }
                            if (x == 5)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.15f, gameObject.transform.position.z);
                            }
                            if (x == 6)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 7)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 8)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 9)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 10)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
                            }
                            x++;
                        }
                        if (CountPlayer == 12)
                        {
                            token.gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.6f, transform.localScale.y - 0.6f);
                            if (x == 0)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 1)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 2)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 3)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 4)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y + 0.15f, gameObject.transform.position.z);
                            }
                            if (x == 5)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y - 0.15f, gameObject.transform.position.z);
                            }
                            if (x == 6)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 7)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.05f, gameObject.transform.position.z);
                            }
                            if (x == 8)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 9)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
                            }
                            if (x == 10)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y - 0.15f, gameObject.transform.position.z);
                            }
                            if (x == 11)
                            {
                                token.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y + 0.15f, gameObject.transform.position.z);
                            }
                            x++;
                        }
                    }
                }
            }
        }
    }
}
