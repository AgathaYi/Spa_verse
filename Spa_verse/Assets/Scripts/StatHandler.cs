using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [Range(1, 100)][SerializeField] private int hp = 100;
    public int HP
    {
        get => hp;
        set => hp = Mathf.Clamp(value, 0, 100);
    }

    [Range(1f, 20f)][SerializeField] private float moveSpeed = 5f;

    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = Mathf.Clamp(value, 1f, 20f);
    }

    [Range(1f, 20f)][SerializeField] private float jumpPower = 5f;
    public float JumpPower
    {
        get => jumpPower;
        set => jumpPower = Mathf.Clamp(value, 1f, 20f);
    }

    [Range(1f, 20f)][SerializeField] private float attackPower = 5f;
    public float AttackPower
    {
        get => attackPower;
        set => attackPower = Mathf.Clamp(value, 1f, 20f);
    }
}
