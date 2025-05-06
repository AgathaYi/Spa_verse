using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrriger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�浹"+ collision.name);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("����" + GameManager.Instance.StatsManager.totalCoin);
            GameManager.Instance.StatsManager.AddCoin(1); // ���� 1�� �߰�
            GameManager.Instance.UIManager.UpdateCoinUI(GameManager.Instance.StatsManager.totalCoin);

            // ���� ������Ʈ ��Ȱ��ȭ
            Destroy(gameObject);
        }
    }
}
