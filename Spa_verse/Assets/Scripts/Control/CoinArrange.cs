using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinArrange : MonoBehaviour
{
    public GameObject coinPrefab;
    public int coinCount = 5; // ������ ���� ����
    [SerializeField] private Collider2D coinCollider; // ������ ��ġ

    private Bounds arrangeBound; // �ٿ����

    void Start()
    {
        Vector2 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        arrangeBound = coinCollider.bounds;
        for (int i = 0; i < coinCount; i++)
        {
            Vector3 randomPosition;
            int count = 0;

            do
            {
                float x = Random.Range(arrangeBound.min.x, arrangeBound.max.x);
                float y = Random.Range(arrangeBound.min.y, arrangeBound.max.y);
                randomPosition = new Vector3(x, y, 0);
                count++;
            }
            // �÷��̾�� �Ÿ� 1f �̻�
            while (Vector2.Distance(randomPosition, playerPosition) < 1f && count < 20);

            // ���� ����
            Instantiate(coinPrefab, randomPosition, Quaternion.identity, transform);
        }
    }
}
