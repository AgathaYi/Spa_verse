using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrriger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ÄÚÀÎ È¹µæ
            StatsManager.Instance.AddCoin(1);
            
            // UI¾ø¾îÁü
            Destroy(gameObject);
        }
    }
}
