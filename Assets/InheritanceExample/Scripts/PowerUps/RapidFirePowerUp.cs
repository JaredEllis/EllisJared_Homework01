using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Scripting;

public class RapidFirePowerUp : PowerupBase
{
    private TurretController turretController;

    private float PowerUpDuration
    {
        set => _powerUpDuration = value;
    }

    private void Awake()
    {
        turretController = FindObjectOfType<TurretController>();
        PowerUpDuration = 2.0f;
    }

    protected override void PowerUp()
    {
        turretController.FireCooldown /= 2;
        Debug.Log($"Fire Cool down is: {turretController.FireCooldown}s");
    }

    protected override void PowerDown()
    {
        turretController.FireCooldown *= 2;
        Debug.Log($"Fire Cool down is: {turretController.FireCooldown}s");
    }
}
