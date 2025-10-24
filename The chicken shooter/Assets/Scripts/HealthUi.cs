using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUi : MonoBehaviour
{
    [SerializeField] private GameObject _healthImagePrefab;
    [SerializeField] private List<GameObject> _healthImages = new List<GameObject>();

    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newImage = Instantiate(_healthImagePrefab, transform);
            _healthImages.Add(newImage);
        }
    }

    public void DisplayHealth(int health)
    {
        for (int i = 0; i < _healthImages.Count; i++)
        {
            if (i < health)
            {
                _healthImages[i].SetActive(true);
            }

            else
            {
                _healthImages[i].SetActive(false);
            }
        }
    }

}
