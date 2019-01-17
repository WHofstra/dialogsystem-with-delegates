using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    private readonly List<string> _dialogs = new List<string>();

    public bool IsPlaying { get; private set; } = false;

    public event Action<string> DialogChanged;
    public event Action DialogsCompleted;

    public void AddDialog(string newDialog)
    {
        _dialogs.Add(newDialog);
    }

    public void Play()
    {
        IsPlaying = true;
        NextDialog();
    }

    public void Stop()
    {
        IsPlaying = false;
        CancelInvoke("NextDialog");
    }

    public void NextDialog()
    {
        if (_dialogs.Count == 0)
        {
            Stop();

            if (DialogsCompleted != null)
            {
                DialogsCompleted();
            }

            return;
        }

        var dialog = _dialogs[0];
        _dialogs.RemoveAt(0);

        if (DialogChanged != null)
        {
            DialogChanged(dialog);
        }

        Invoke("NextDialog", 3);
    }
}