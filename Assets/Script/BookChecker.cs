using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookChecker : MonoBehaviour
{
    [SerializeField] Image greenBook;
    [SerializeField] Image redBook;
    [SerializeField] Image blueBook;


    private void Awake()
    {
        greenBook.enabled = false;
        redBook.enabled = false;
        blueBook.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GBook"))
        {
            greenBook.enabled = true;
        }
        if (other.gameObject.CompareTag("RBook"))
        {
            redBook.enabled = true;
        }
        if (other.gameObject.CompareTag("BBook"))
        {
            blueBook.enabled = true;
        }
    }
}
