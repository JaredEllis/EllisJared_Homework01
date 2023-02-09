using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PowerupBase : MonoBehaviour
{
    [Header("PowerUp")]
    [SerializeField] protected float _powerUpDuration;
    
    [Header("SFX")]
    [SerializeField] private AudioClip _hitSound;
    
    [Header("FX")]
    [SerializeField] private Collider _collider;
    [SerializeField] private MeshRenderer _visuals;

    protected abstract void PowerUp();
    protected abstract void PowerDown();
    
    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            AudioHelper.PlayClip2D(_hitSound, 1, .1f);
            OnHit();
        }
    }

    private void OnHit()
    {
        StartCoroutine(StartPowerUpDuration());
    }

    private IEnumerator StartPowerUpDuration()
    {
        _collider.enabled = false;
        _visuals.enabled = false;
        Debug.Log($"Starting Power Up Duration for {_powerUpDuration}s");
        PowerUp();
        yield return new WaitForSeconds(_powerUpDuration);
        Debug.Log($"Ending Power Up");
        PowerDown();
    }
}
