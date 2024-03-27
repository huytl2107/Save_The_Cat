using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;

    [Header("Star")]
    [SerializeField] private Image _star1;
    [SerializeField] private Image _star2;
    [SerializeField] private Image _star3;
    [SerializeField] private Sprite _star;
    [SerializeField] private Sprite _nullStar;  //Code dơ vkl

    [Header("Slider Bar")]
    [SerializeField] private Slider _slider;

    public override void Awake()
    {
        base.Awake();

        PopDownWinPanel();
        PopDownLosePanel();
    }

    #region WinPanel
    public void PopUpWinPanel()
    {
        if (_losePanel.activeInHierarchy)
            return; //Đảm bảo không popUp đồng thời losePanel và winPanel

        _winPanel.SetActive(true);
        GetStar();
    }

    public void PopDownWinPanel()
    {
        _winPanel.SetActive(false);
    }
    #endregion WinPanel

    #region LosePanel
    public void PopUpLosePanel()
    {
        if (_winPanel.activeInHierarchy)
            return; //Đảm bảo không popUp đồng thời losePanel và winPanel
        _losePanel.SetActive(true);
    }

    public void PopDownLosePanel()
    {
        _losePanel.SetActive(false);
    }
    #endregion LosePanel

    private void GetStar()
    {
        Debug.Log(_slider.value);
        float value = _slider.value;

        if (value > .67f)
        {

        }
        else if (value > .33f)
        {
            _star3.sprite = _nullStar;
        }
        else if (value > 0)
        {
            _star3.sprite = _nullStar;
            _star2.sprite = _nullStar;
        }
        else
        {
            _star3.sprite = _nullStar;
            _star2.sprite = _nullStar;
            _star1.sprite = _nullStar;
        }
    }
}