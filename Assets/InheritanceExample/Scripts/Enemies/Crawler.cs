using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crawler : EnemyBase
{
    [SerializeField]
    private GameObject RapidFirePowerUp;
    
    protected override void OnHit()
    {
        
    }

    public override void Kill()
    {
        //TODO put code you want to happen before disable here
        Instantiate(RapidFirePowerUp, transform.position, Quaternion.identity);
        // this runs the base method AND what's above it here
        base.Kill();
    }
}
