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
        if (coinCollider != null)
        {
            arrangeBound = coinCollider.bounds;
            CoinPoint();
        }
    }

    private void CoinPoint()
    {
        // 플레이어랑 겹침. 시작하자마자 코인 회수됨.  - 해결
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
                if (count > 10) // 무한 루프 방지
                {
                    Debug.LogWarning("코인 생성 실패");
                    break;
                }
            }
            while (Vector2.Distance(randomPosition, playerPosition) < 1f); // 플레이어와의 거리 체크

            // 코인 생성
            GameObject coin = Instantiate(coinPrefab, randomPosition, Quaternion.identity);
            coin.transform.SetParent(transform); // 부모 설정
        }
    }
}
