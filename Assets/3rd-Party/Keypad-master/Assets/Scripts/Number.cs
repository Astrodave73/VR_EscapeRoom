using UnityEngine;

public class Number : MonoBehaviour
{
    [SerializeField] GameObject keypad;
    /////// set VR here

#if UNITY_EDITOR
    private void OnMouseDown()
    {
        keypad.GetComponent<Code>().Receiver(gameObject);
    }
#endif

    private void OnTriggerEnter(Collider other)
    {
        keypad.GetComponent<Code>().Receiver(gameObject);
    }
}
