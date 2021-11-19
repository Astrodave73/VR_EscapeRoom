using UnityEngine;

public class Number : MonoBehaviour
{
    Code code;
    bool isPressed = false;
    private void Awake()
    {
        code = GetComponentInParent<Code>();
    }

#if UNITY_EDITOR
    private void OnMouseDown()
    {
        code.Receiver(gameObject);
    }
#endif

    private void OnTriggerEnter(Collider other)
    {
        if (isPressed)
            return;

        if (other.CompareTag("Finger"))
        {
            isPressed = true;
            code.Receiver(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Finger"))
            isPressed = false;
    }
}
