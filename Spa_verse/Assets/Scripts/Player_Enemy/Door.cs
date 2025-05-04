using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // �� ������Ʈ
    public GameObject closedDoor;
    public GameObject openDoor;

    // collider
    public BoxCollider2D doorCollider;

    // ���� ����
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

    // �÷��̾ ���� ����
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("����ó");
            // ���� ���� Ű
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("������");
                DoorCheck();
            }
        }
    }
}
