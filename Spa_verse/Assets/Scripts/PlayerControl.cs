using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : BaseControl
{
    private Camera mainCamera;

    protected override void KeyControl()
    {
        // �÷��̾� move ���
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W");
        }
    }
}
