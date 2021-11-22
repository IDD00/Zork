using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zork;
using TMPro;

public class UnityOutputService : MonoBehaviour, IOutputService
{
    public void Clear() => mEntries.ForEach(entry => Destroy(entry));

    public void Write(string value) => ParseAndWriteLine(value);

    public void Write(object value) => Write(value.ToString());

    public void WriteLine(string value) => ParseAndWriteLine(value);

    public void WriteLine(object value) => WriteLine(value.ToString());

    private void ParseAndWriteLine(string value)
    {
        string[] delimiters = { "\n" };

        var lines = value.Split(delimiters, StringSplitOptions.None);
        foreach (var line in lines)
        {
            if (mEntries.Count >= MaxEntries)
            {
                var entry = mEntries.First();
                Destroy(entry);
                mEntries.Remove(entry);
            }

            if (string.IsNullOrWhiteSpace(line))
            {
                WriteNewLine();
            }
            else
            {
                WriteTextLine(line);
            }
        }
    }

    private void WriteNewLine()
    {
        var newLine = GameObject.Instantiate(NewLinePrefab);
        newLine.transform.SetParent(OutputTextContainer, false);
        mEntries.Add(newLine.gameObject);
    }

    private void WriteTextLine(string value)
    {
        var textLine = GameObject.Instantiate(TextLinePrefab);
        textLine.transform.SetParent(OutputTextContainer, false);
        textLine.text = value;
        mEntries.Add(textLine.gameObject);
    }

    public UnityOutputService() => mEntries = new List<GameObject>();

    [SerializeField]
    private int MaxEntries = 50;

    [SerializeField]
    private Transform OutputTextContainer;

    [SerializeField]
    private TextMeshProUGUI TextLinePrefab;

    [SerializeField]
    private Image NewLinePrefab;

    private readonly List<GameObject> mEntries;
}
