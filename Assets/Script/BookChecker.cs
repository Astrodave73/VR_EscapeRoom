using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BookChecker : MonoBehaviour
{
    [SerializeField] Image greenBook;
    [SerializeField] Image redBook;
    [SerializeField] Image blueBook;
    [SerializeField] MeshRenderer locker;
    [SerializeField] AudioSource openDoor;
    [SerializeField] GameObject door;

    
    private void Awake()
    {
        greenBook.enabled = false;
        redBook.enabled = false;
        blueBook.enabled = false;
    }

 
    private void Update()
    {
        if (greenBook.enabled && redBook.enabled && blueBook)
        {
            StartCoroutine("OpenWinScene");
        }
        
        
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

    IEnumerator OpenWinScene()
    {
        
        door.transform.rotation = Quaternion.Slerp(door.transform.rotation,Quaternion.Euler(0,-90,0), Time.deltaTime);
            locker.enabled = false;
            openDoor.Play();
       
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("WinScene");
        

    }
}
