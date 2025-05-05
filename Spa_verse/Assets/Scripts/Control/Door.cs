using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Door : MonoBehaviour
{
    // 문 오브젝트
    public GameObject closeDoor;
    public GameObject openDoor;

    // collider
    public BoxCollider2D doorCollider;

    // 오픈 여부
    private bool isOpen = false;
    public bool IsOpenDoor { get => isOpen; }

    private bool isplayerInRange = false;

    // Floor 컬려변경
    public GameObject floorObj;
    private Tilemap floorColor;


    void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        floorColor = floorObj.GetComponent<Tilemap>();
        ChangeDoorUI();
    }

    void Update()
    {
        if (isplayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                DoorCheck();
            }
        }
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
            floorColor.color = new Color(0, 0, 0, 0);
        }
        else
        {
            closeDoor.SetActive(true);
            openDoor.SetActive(false);
            floorColor.color = new Color(0, 0, 0, 0.8f);
        }
    }

    // 플레이어가 문에 접근
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isplayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isplayerInRange = false;
        }
    }
}
