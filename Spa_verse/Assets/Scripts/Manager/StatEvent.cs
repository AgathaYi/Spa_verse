using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatEvent : MonoBehaviour
{
    // ÄÚÀÎ, Á¡¼ö È¹µæ Ã³¸®
    public int getCoin;
    public int getScore;

    public void GetStat()
    {
        GameManager.Instance.StatsManager.AddScore(getScore);
        GameManager.Instance.StatsManager.AddCoin(getCoin);

        Debug.Log($"Score: {getScore},   coin: {getCoin}");
    }
}
