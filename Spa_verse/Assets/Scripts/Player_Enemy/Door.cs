using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // �� ������Ʈ
    public GameObject closeDoor;
    public GameObject openDoor;

    // collider
    public BoxCollider2D doorCollider;

    // ���� ����
    private bool isOpen = false;

    void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        ChangeDoorUI();
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
        }
        else
        {
            closeDoor.SetActive(true);
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("������");
                DoorCheck();
            }
        }
    }
}
