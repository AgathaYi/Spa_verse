using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // 문 오브젝트
    public GameObject closedDoor;
    public GameObject openDoor;

    // collider
    public BoxCollider2D doorCollider;

    // 오픈 여부
    private bool isOpen = false;

    void Start()
    {
        
    }

    public void DoorCheck()
    {
        isOpen = !isOpen;
        ChangeDoorUI();
    }

    private void ChangeDoorUI()
    {
        if (isOpen)
        {
            closedDoor.SetActive(false);
            openDoor.SetActive(true);
        }
        else
        {
            closedDoor.SetActive(true);
            openDoor.SetActive(false);
        }
    }

    // 플레이어가 문에 접근
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("문근처");
            // 문을 열기 키
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("문열림");
                DoorCheck();
            }
        }
    }
}
