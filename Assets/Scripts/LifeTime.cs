using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTime : MonoBehaviour, IObserver
{
    [SerializeField] private Text _lifeTimeText;
    private bool _lineEnded = false;
    [SerializeField] private float _lifetime = 10;

    private void Awake()
    {
        Subject.Register(this);
    }
    void Update()
    {
        if (!_lineEnded)
            return;

        _lifetime -= Time.deltaTime;
        int lifeTimeINT = (int)_lifetime;
        _lifeTimeText.text = lifeTimeINT.ToString();
    }

    public void OnNotify(string key)
    {
        if(key == "EndLine")
        {
            _lineEnded = true;
        }
    }
}
