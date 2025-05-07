using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    [SerializeField] private float hpChangeDelay = 0.1f;

    private BaseControl baseControl;
    private MainPlayerHandler mainHandler;

    private float timeSinceLastChange = float.MaxValue;

    public float CurrentHp { get; private set; }
    public float MaxHp => mainHandler.HP;
    private Action<float, float> onHpChange;

    private void Awake()
    {
        baseControl = GetComponent<BaseControl>();
        mainHandler = GetComponent<MainPlayerHandler>();
        
    }

    private void Start()
    {
        CurrentHp = mainHandler.HP;
    }

    private void Update()
    {
        if (timeSinceLastChange < hpChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;
        }
    }

    public bool ChangeHp(float change)
    {
        if (change == 0 || timeSinceLastChange < hpChangeDelay)
        {
            return false;
        }
        else
        {
            timeSinceLastChange = 0f;
            CurrentHp += change;

            if (CurrentHp > MaxHp)
            {
                CurrentHp = MaxHp;
            }
            else if (CurrentHp < 0)
            {
                CurrentHp = 0;
                baseControl.Die();
                return false;
            }

            onHpChange?.Invoke(CurrentHp, MaxHp);
        }

        if (change < 0)
        {
            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("IsDie", true);
            }
            else
            {
                Debug.LogWarning("Animator 컴포넌트없음 오브젝트명: " + gameObject.name);
            }
        }
        return true;
    }

    public void Die()
    {
        baseControl.Die();
    }

    public void AddHp(Action<float, float> action)
    {
        onHpChange += action;
    }

    public void RemoveHp(Action<float, float> action)
    {
        onHpChange -= action;
    }
}
