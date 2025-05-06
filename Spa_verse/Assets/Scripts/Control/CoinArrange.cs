using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinArrange : MonoBehaviour
{
    public GameObject coinPrefab;
    public int coinCount = 5; // 생성할 코인 개수
    [SerializeField] private Collider2D coinCollider; // 생성할 위치

    private Bounds arrangeBound; // 바운더리

    private void Start()
    {
        if (arrangeBound != null)
        {
            arrangeBound = coinCollider.bounds;
            CoinPoint();
        }
        else
        {
            Debug.LogError("Collider2D가 null!");
        }
    }

    private void CoinPoint()
    {
        for (int i = 0; i < coinCount; i++)
        {
            // 랜덤한 위치 생성
            Vector2 randomPos = new Vector2(
                Random.Range(arrangeBound.min.x, arrangeBound.max.x),
                Random.Range(arrangeBound.min.y, arrangeBound.max.y)
            );
            // 코인 생성
            GameObject coin = Instantiate(coinPrefab, randomPos, Quaternion.identity);
            coin.transform.SetParent(transform); // 부모 설정
        }
    }
}
