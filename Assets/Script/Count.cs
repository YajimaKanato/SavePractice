using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CountSave
{
    public int Count;
}

public class Count : MonoBehaviour
{
    [SerializeField] string _fileName;
    [SerializeField] Text _countText;
    [SerializeField] int _max = 99999;
    [SerializeField] int _min = 0;

    CountSave _countSave;

    int _count = 0;

    private void Start()
    {
        LoadData();
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

    /// <summary>
    /// データをセーブする関数
    /// </summary>
    public void SaveData()
    {
        _countSave.Count = _count;
        SaveManager.SaveDataPrefs(_fileName, _countSave);
    }

    //データをロードする関数
    public void LoadData()
    {
        _countSave = SaveManager.LoadDataPrefs<CountSave>(_fileName);
        if (_countSave == null)
        {
            _countSave = new CountSave();
        }
        _count = _countSave.Count;
        TextUpdate();
    }

}
