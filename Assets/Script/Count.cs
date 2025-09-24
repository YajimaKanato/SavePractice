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
    const string JSON = ".json";

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
    /// �f�[�^���Z�[�u����֐�
    /// </summary>
    public void SaveData()
    {
        _countSave.Count = _count;
        SaveManager.SaveDataJson(_fileName + JSON, _countSave);
    }

    //�f�[�^�����[�h����֐�
    public void LoadData()
    {
        _countSave = SaveManager.LoadDataJson<CountSave>(_fileName + JSON);
        if (_countSave == null)
        {
            _countSave = new CountSave();
        }
        _count = _countSave.Count;
        TextUpdate();
    }

}
