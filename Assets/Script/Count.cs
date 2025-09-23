using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CountSave
{
    int _count;
    public int Count { get; set; }
}

public class Count : MonoBehaviour
{
    [SerializeField] Text _countText;
    [SerializeField] int _max = 99999;
    [SerializeField] int _min = 0;

    CountSave _countSave;

    int _count = 0;

    private void Start()
    {
        _countSave = new CountSave();
        TextUpdate();
    }

    public void TextUpdate()
    {
        _countText.text = _count.ToString("00000");
    }

    public void CountUp()
    {
        _count++;
        if (_count >= _max)
        {
            _count = _max;
        }
        _countSave.Count = _count;
        TextUpdate();
    }

    public void CountDown()
    {
        _count--;
        if (_count <= _min)
        {
            _count = _min;
        }
        _countSave.Count = _count;
        TextUpdate();
    }
}
