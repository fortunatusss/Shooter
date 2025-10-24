using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 2;
    [SerializeField] private UnityEvent _eventOnTakeDamage;

    public void TakeDamage(int damageValue)
    {
        _health -= damageValue;
        _eventOnTakeDamage.Invoke();

        if (_health <= 0)
        {
            Die();
        }       
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
