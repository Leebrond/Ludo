using UnityEngine;

public class JsonBalance 
{
    public string user_id;
    public int win_amount;

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}

public class StartGameJson
{
    public string user_id;
    public string table_id;
    public string entry_fee;
    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}

public class KickJson
{
    public string user_id;
    public int kick_coffecient;
    public bool is_player_do_kick;
    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}

public class GameOverJson
{
    public string user_id;
    public bool is_player_win;
    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}

