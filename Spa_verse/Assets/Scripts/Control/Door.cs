using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Door : MonoBehaviour
{
    // �� ������Ʈ
    public GameObject closeDoor;
    public GameObject openDoor;

    // collider
    public BoxCollider2D doorCollider;

    // ���� ����
    private bool isOpen = false;
    public bool IsOpenDoor { get => isOpen; }

    private bool isplayerInRange = false;

    // Floor �÷�����
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

    // �����ݱ� Ȯ��
    public void DoorCheck()
    {
        isOpen = !isOpen;
        doorCollider.enabled = !doorCollider.enabled; // ���� ������ �浹ü ��Ȱ��ȭ
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

    // �÷��̾ ���� ����
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
