using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTime : MonoBehaviour, IObserver
{
    [SerializeField] private Text _lifeTimeText;
    [SerializeField] private float _lifeTime = 10;
    private float _time;
    private bool _lineEnded = false;
    private bool _gameOver = false;

    private void Awake()
    {
        Subject.Register(this);
        _time = _lifeTime;
    }
    void Update()
    {
        if (!_lineEnded || _gameOver)
            return;

        _time -= Time.deltaTime;
        if (_time <= 0) // Vì trường hợp == 0 rất khó xảy ra
            UIManager.Instant.PopUpWinPanel();
        int lifeTimeINT = (int)_time;
        if (lifeTimeINT < 0)
            lifeTimeINT = 0;

        _lifeTimeText.text = lifeTimeINT.ToString();
    }

    public void OnNotify(string key)
    {
        if(key == "EndLine")
        {
            _lineEnded = true;
        }
        if(key == "GameOver")
        {
            _gameOver = true;
        }
        if(key == "StartGame")
        {
            _time = _lifeTime;
            _gameOver = false;
            _lineEnded = false;
            _lifeTimeText.text = "";
        }
    }
}
