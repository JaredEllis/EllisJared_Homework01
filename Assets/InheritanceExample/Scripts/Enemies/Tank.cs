using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tank : EnemyBase
{

    private bool _isPaused;
    private int Health
    {
        get => _health;
        set => _health = value;
    }
    
    private void Start()
    {
        Health *= 2;
        // Debug.Log($"{gameObject.name}'s health is: {Health}");
    }
    
    protected override void Move()
    {
        if (!_isPaused)
        {
            base.Move();
        }
    }

    protected override void OnHit()
    {
        StartCoroutine(Pause());
    }

    private IEnumerator Pause()
    {
        _isPaused = true;
        // Debug.Log("Starting Pause");
        yield return new WaitForSeconds(1);
        // Debug.Log("Ending Pause");
        _isPaused = false;
    }
}
