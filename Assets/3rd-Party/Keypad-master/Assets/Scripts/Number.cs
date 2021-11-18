using UnityEngine;

public class Number : MonoBehaviour
{
    Code code;

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
        if (other.CompareTag("Finger"))
            code.Receiver(gameObject);
    }
}
