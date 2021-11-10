using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [SerializeField] TextMeshProUGUI showText;

    [SerializeField] string textEnter;
    [SerializeField] string textError;
    [SerializeField] string textCorrect;

    [SerializeField] List<int> code = new List<int>(4);

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

    // when we enter cancle, delelte the number
    void Delete()
    {
        inputCode.Clear();
        index = 0;
        showText.text = "";
    }

    void Enter()
    {
        if (index == code.Count)
        {
            bool isCorrect = true;
            for (int i = 0; i < code.Count; i++)
                if (inputCode[i] != code[i])
                {
                    isCorrect = false;
                    break;
                }

            showText.text = isCorrect ? textCorrect : textError;
        }
        else
        {
            showText.text = textError;
            Delete();
        }
    }

    public void AddCode(int num)
    {
        if (index < code.Count)
        {
            inputCode.Add(num);
            showText.text += num;
            index++;
        }
    }

}
