using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrriger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("충돌"+ collision.name);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("코인" + GameManager.Instance.StatsManager.totalCoin);
            GameManager.Instance.StatsManager.AddCoin(1); // 코인 1개 추가
            GameManager.Instance.UIManager.UpdateCoinUI(GameManager.Instance.StatsManager.totalCoin);

            // 코인 오브젝트 비활성화
            Destroy(gameObject);
        }
    }
}
