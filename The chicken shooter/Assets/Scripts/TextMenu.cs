using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMenu : MonoBehaviour
{
    [SerializeField] private Text _textMenu;

    private void Start()
    {
        Invoke("Deactivate", 5);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
