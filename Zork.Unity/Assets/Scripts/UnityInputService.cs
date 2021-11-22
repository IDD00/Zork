using UnityEngine;
using Zork;
using TMPro;
using System;

public class UnityInputService : MonoBehaviour, IInputService
{
    public event EventHandler<string> InputReceived;
        
    [SerializeField]
    private TMP_InputField InputField;

    void Start()
    {
        InputField.Select();
        InputField.ActivateInputField();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            string inputString = InputField.text;
            if (string.IsNullOrWhiteSpace(inputString) == false)
            {
                InputReceived?.Invoke(this, inputString);
            }

            InputField.text = string.Empty;
            InputField.Select();
            InputField.ActivateInputField();
        }
    }
}
