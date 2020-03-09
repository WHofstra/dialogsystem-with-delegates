using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogStack : MonoBehaviour
{
    [SerializeField]
    private Text _field;

    private string[] names = new string[1];

    void Awake()
    {
        var dialogSystem = GetComponent<DialogSystem>();
        dialogSystem.DialogChanged += OnDialogStack;

        names[0] = "B. Weij";
    }

    private void OnDialogStack(string newDialog)
    {
        _field.text += newDialog + " [" + names[0] + " at: " + System.DateTime.Now + "]\n";
    }
}
