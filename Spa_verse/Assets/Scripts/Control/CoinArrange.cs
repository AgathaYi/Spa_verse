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
        if (arrangeBound != null)
        {
            arrangeBound = coinCollider.bounds;
            CoinPoint();
        }
        else
        {
            Debug.LogError("Collider2D�� null!");
        }
    }

    private void CoinPoint()
    {
        for (int i = 0; i < coinCount; i++)
        {
            // ������ ��ġ ����
            Vector2 randomPos = new Vector2(
                Random.Range(arrangeBound.min.x, arrangeBound.max.x),
                Random.Range(arrangeBound.min.y, arrangeBound.max.y)
            );
            // ���� ����
            GameObject coin = Instantiate(coinPrefab, randomPos, Quaternion.identity);
            coin.transform.SetParent(transform); // �θ� ����
        }
    }
}
