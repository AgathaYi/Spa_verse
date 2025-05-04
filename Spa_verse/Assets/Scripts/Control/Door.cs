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
    private bool isplayerInRange = false;


    void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        ChangeDoorUI();
    }

    void Update()
    {
        if (isplayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("������");
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
        }
        else
        {
            closeDoor.SetActive(true);
            openDoor.SetActive(false);
        }
    }

    // �÷��̾ ���� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isplayerInRange = true;
            Debug.Log("����ó");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isplayerInRange = false;
            Debug.Log("����");
        }
    }
}
