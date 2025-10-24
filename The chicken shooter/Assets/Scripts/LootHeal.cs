using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    [SerializeField] private int _healthValue;

    private void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * 40f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeHealth(_healthValue);
            Destroy(gameObject);
        }
    }
}
