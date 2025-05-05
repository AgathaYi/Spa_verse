using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int obstacleCount = 0;
    public Vector3 obstacleLastPostion = Vector3.zero;
    public int BgCount = 5; // 배경 오브젝트의 개수

    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPostion = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPostion = obstacles[i].SetRandomObstacle(obstacleLastPostion, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D"+ collision.name);

        if (collision.CompareTag("BackGround"))
        {
            float widthBgObj = ((BoxCollider2D)collision).size.x;
            Vector3 bgPos = collision.transform.position;

            bgPos.x += widthBgObj * BgCount;
            collision.transform.position = bgPos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLastPostion = obstacle.SetRandomObstacle(obstacleLastPostion, obstacleCount);
        }
    }
}
