using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    [SerializeField] Text _countText;
    [SerializeField] int _max = 99999;
    [SerializeField] int _min = 0;
    int _count = 0;

    private void Start()
    {
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
        TextUpdate();
    }

    public void CountDown()
    {
        _count--;
        if (_count <= _min)
        {
            _count = _min;
        }
        TextUpdate();
    }
}
