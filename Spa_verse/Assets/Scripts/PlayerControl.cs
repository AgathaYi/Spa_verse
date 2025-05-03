using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : BaseControl
{
    private Camera mainCamera;

    protected override void KeyControl()
    {
        // 플레이어 move 방법
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W");
        }
    }
}
