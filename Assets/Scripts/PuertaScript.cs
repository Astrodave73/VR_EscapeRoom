using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuertaScript : MonoBehaviour
{
    [SerializeField] Image GBook;
    [SerializeField] Image RBook;
    [SerializeField] Image BBook;

    [SerializeField] GameObject exitDoor;

    [SerializeField] GameObject greenbook;
    [SerializeField] GameObject redbook;
    [SerializeField] GameObject bluebook;

    [SerializeField] GameObject locker;
    [SerializeField] AudioSource audiosrc;
    [SerializeField] AudioClip audioclp;
    [SerializeField] AudioClip bookChecker;


    private void Awake()
    {
        GBook.enabled = false;
        RBook.enabled = false;
        BBook.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GBook.enabled && RBook.enabled && BBook.enabled)
        {
            StartCoroutine("OpenDoorB");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject. CompareTag("GBook"))
        {
            GBook.enabled = true;
            audiosrc.PlayOneShot(bookChecker);
          
        }
        if (other.gameObject.CompareTag("RBook"))
        {
            RBook.enabled = true;
            audiosrc.PlayOneShot(bookChecker);
        }
        if (other.gameObject.CompareTag("BBook"))
        {
            BBook.enabled = true;
            audiosrc.PlayOneShot(bookChecker);
        }
    }

    IEnumerator OpenDoorB()
    {
        locker.SetActive(false);
        audiosrc.PlayOneShot(audioclp);
        exitDoor.transform.rotation = Quaternion.Slerp(exitDoor.transform.rotation, Quaternion.Euler(0,- 90f,0), Time.deltaTime);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("WinScene");
        RBook.enabled = false;
        GBook.enabled = false;
        BBook.enabled = false;
    }
        
}
