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
            Vector3 coinPosition = 
        }
    }
}
