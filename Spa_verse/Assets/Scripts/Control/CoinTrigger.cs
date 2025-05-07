using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrriger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.CompareTag("Player"))
        {
            return;
        }

        if (collision.CompareTag("Player"))
        {
            // ¾Àº° ÄÚÀÎ È¹µæ ¹æ¹ý »óÀÌ
            string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            if (sceneName == "BlueZone")
            {
                BlueGameManager.Instance.AddCoin(1);
            }
            //else if (sceneName == "RedZone")
            //{
            //    RedGameManager.Instance.AddCoin(1);
            //}
            else
            {
                StatsManager.Instance.AddCoin(1);
            }
            
            // UI¾ø¾îÁü
            Destroy(gameObject);
        }
    }
}
