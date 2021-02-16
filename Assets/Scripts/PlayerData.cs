[System.Serializable]
public class PlayerData
{
    public string name;
    public int lvlPlayer;

    public PlayerData (Player player)
    {
        name = player.name;
    }
}