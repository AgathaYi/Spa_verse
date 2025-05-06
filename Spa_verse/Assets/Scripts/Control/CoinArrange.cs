using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinArrange : MonoBehaviour
{
    public GameObject coinPrefab;
    public int coinCount = 5; // ������ ���� ����
    [SerializeField] private Collider2D coinCollider; // ������ ��ġ

    private Bounds arrangeBound; // �ٿ����

    private void Start()
    {
        if (coinCollider != null)
        {
            arrangeBound = coinCollider.bounds;
            CoinPoint();
        }
    }

    private void CoinPoint()
    {
        // �÷��̾�� ��ħ. �������ڸ��� ���� ȸ����.  - �ذ�
        Vector2 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        for (int i = 0; i < coinCount; i++)
        {
            Vector3 randomPosition;
            int count = 0;

            do
            {
                randomPosition = new Vector3(
                    Random.Range(arrangeBound.min.x, arrangeBound.max.x),
                    Random.Range(arrangeBound.min.y, arrangeBound.max.y),
                    0f
                );
                count++;
                if (count > 10) // ���� ���� ����
                {
                    Debug.LogWarning("���� ���� ����");
                    break;
                }
            }
            while (Vector2.Distance(randomPosition, playerPosition) < 1f); // �÷��̾���� �Ÿ� üũ

            // ���� ����
            GameObject coin = Instantiate(coinPrefab, randomPosition, Quaternion.identity);
            coin.transform.SetParent(transform); // �θ� ����
        }
    }
}
