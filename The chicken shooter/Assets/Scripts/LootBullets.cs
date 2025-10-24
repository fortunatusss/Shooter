using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullets : MonoBehaviour
{
    [SerializeField] private int _gunIndex;
    [SerializeField] private int _numberOfBullets;
    [SerializeField] private AudioSource _takeBulletsSound;

    private void Start()
    {
        _takeBulletsSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * 40f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _takeBulletsSound.Play();
            other.GetComponent<PlayerArmoury>().AddBulletsForGun(_gunIndex, _numberOfBullets);           
            Destroy(gameObject, 0.2f);            
        }
    }
}
