using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // 문 오브젝트
    public GameObject closeDoor;
    public GameObject openDoor;

    // collider
    public BoxCollider2D doorCollider;

    // 오픈 여부
    private bool isOpen = false;

    void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        ChangeDoorUI();
    }

    // 문여닫기 확인
    public void DoorCheck()
    {
        isOpen = !isOpen;
        doorCollider.enabled = !doorCollider.enabled; // 문이 열리면 충돌체 비활성화
        ChangeDoorUI();
    }

    private void ChangeDoorUI()
    {
        if (isOpen)
        {
            closeDoor.SetActive(false);
            openDoor.SetActive(true);
        }
        else
        {
            closeDoor.SetActive(true);
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("문열림");
                DoorCheck();
            }
        }
    }
}
