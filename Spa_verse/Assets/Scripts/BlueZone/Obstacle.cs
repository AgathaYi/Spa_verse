using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public float highPositionY = 1f;
    public float lowPositionY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    [Header("Obstacle Prefabs")]
    public Transform topObj;
    public Transform bottomObj;

    public float widthPadding = 4f;

    BlueGameManager blueGameManager;

    private void Start()
    {
        blueGameManager = BlueGameManager.Instance;
    }

    public Vector3 SetRandomObstacle(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;

        topObj.localPosition = new Vector3(0, halfHoleSize);
        bottomObj.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 obstaclePosition = lastPosition + new Vector3(widthPadding, 0);
        obstaclePosition.y = Random.Range(lowPositionY, highPositionY);

        transform.position = obstaclePosition;

        return obstaclePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        BluePlayer player = collision.GetComponent<BluePlayer>();
        if (player != null)
        {
            blueGameManager.AddScore(1);
        }
    }
}
