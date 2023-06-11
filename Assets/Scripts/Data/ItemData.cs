using System.Collections.Generic;

[System.Serializable]
public class ItemData
{
    public List<HighScore> highScore;
    public List<int> coins;
    public List<float> counts;
}
[System.Serializable]
public class HighScore
{
    public float highScore;
}
