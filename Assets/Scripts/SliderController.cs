using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _maxCountOneStar = 75;
    private LineController line;

    // Start is called before the first frame update
    void Start()
    {
        _slider.value = 1;
        line = FindObjectOfType<LineController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetValue();
    }

    private void GetValue()
    {
        float value = (_maxCountOneStar-line.GetCountListPoint())/_maxCountOneStar;
        _slider.value = value;
    }
}
