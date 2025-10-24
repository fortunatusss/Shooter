using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private AudioSource _takeDamageSound;
    [SerializeField] private AudioSource _takeHealthSound;
    [SerializeField] private HealthUi _healthUi;
    [SerializeField] private DamageScreen _damageScreen;
    [SerializeField] private Blink _blink;

    private int maxHealth = 5;
    private bool invulnerable = false;

    private void Start()
    {
        _healthUi.Setup(maxHealth);
        _healthUi.DisplayHealth(_health);
    }

    public void TakeDamage(int damageValue)
    {
        if (invulnerable == false) 
        {
            _health -= damageValue;           

            if (_health <= 0)
            {
                _health = 0;
                Die();
            }

            invulnerable = true;
            _takeDamageSound.Play();
            _healthUi.DisplayHealth(_health);
            _damageScreen.StartScreenEffect();
            _blink.StartBlink();
            Invoke("StopInvulnerable", 1.5f);
        }    
    }

    void StopInvulnerable()
    {
        invulnerable = false;
    }

    public void TakeHealth(int healthValue)
    {
        _health += healthValue;

        if (_health > maxHealth)
        {
            _health = maxHealth;
        }

        _takeHealthSound.Play();
        _healthUi.DisplayHealth(_health);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
