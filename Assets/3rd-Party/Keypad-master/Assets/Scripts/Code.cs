using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class Code : MonoBehaviour
{
    [SerializeField] GameObject num0;
    [SerializeField] GameObject num1;
    [SerializeField] GameObject num2;
    [SerializeField] GameObject num3;
    [SerializeField] GameObject num4;
    [SerializeField] GameObject num5;
    [SerializeField] GameObject num6;
    [SerializeField] GameObject num7;
    [SerializeField] GameObject num8;
    [SerializeField] GameObject num9;

    [SerializeField] GameObject cancle;
    [SerializeField] GameObject OK;
    [SerializeField] GameObject safeLock;

    [SerializeField] AudioSource asrc;
    [SerializeField] AudioClip clip;
    [SerializeField] AudioClip tecla;
    [SerializeField] AudioClip puertaAbierta;

    [SerializeField] TextMeshProUGUI showText;

    [SerializeField] string textEnter;
    [SerializeField] string textError;
    [SerializeField] string textCorrect;
    

    [SerializeField] Vector4 code;

    [SerializeField] bool hasOpened = false;
    [SerializeField] UnityEvent onCorrectCode;

    List<int> inputCode = new List<int>();

    int index = 0;

    void Start()
    {
        showText.text = textEnter;
    }

    public void Receiver(GameObject go)
    {
        if (go == num0)
            AddCode(0);
        if (go == num1)
            AddCode(1);
        if (go == num2)
            AddCode(2);
        if (go == num3)
            AddCode(3);
        if (go == num4)
            AddCode(4);
        if (go == num5)
            AddCode(5);
        if (go == num6)
            AddCode(6);
        if (go == num7)
            AddCode(7);
        if (go == num8)
            AddCode(8);
        if (go == num9)
            AddCode(9);
        if (go == cancle)
            Delete();
        if (go == OK)
            Enter();
    }

    // when we enter cancle, delete the number
    void Delete()
    {
        if (hasOpened)
            return;

        inputCode.Clear();
        index = 0;
        showText.text = "";
    }

    void Enter()
    {
        if (hasOpened)
            return;

        if (inputCode.Count == 4)
        {
            bool isCorrect = false;
            if (inputCode[0] == code.x &&
                inputCode[1] == code.y &&
                inputCode[2] == code.z &&
                inputCode[3] == code.w)
            {
                isCorrect = true;
                hasOpened = true;
                asrc.PlayOneShot(clip,1);
                asrc.PlayOneShot(puertaAbierta);
                onCorrectCode.Invoke();
                safeLock.SetActive(false);
            
            }
            else
            {
                Delete();
                isCorrect = false;
            }

            showText.text = isCorrect ? textCorrect : textError;
            showText.color = isCorrect ? Color.green : Color.red;
        }
    }

    public void AddCode(int num)
    {
        if (hasOpened)
            return;

        if (showText.text == textEnter || showText.text == textError)
            showText.text = "";

        if (index < 4)
        {
            asrc.PlayOneShot(tecla);
            showText.color = Color.white;
            inputCode.Add(num);
            showText.text += num;
            index++;
        }
    }

}
