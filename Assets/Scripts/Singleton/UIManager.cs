using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _starPanel;
    [SerializeField] private GameObject _selecLevelPanel;
    [SerializeField] private GameObject _startMenu;

    [Header("Star")]
    private Image[] _starIMG;
    [SerializeField] private Sprite _star;
    [SerializeField] private Sprite _nullStar;

    [Header("Slider Bar")]
    [SerializeField] private Slider _slider;

    public override void Awake()
    {
        base.Awake();

        PopDownWinPanel();
        PopDownLosePanel();
        _starIMG = _starPanel.GetComponentsInChildren<Image>();

        //code tạm
        if(_selecLevelPanel!= null )_selecLevelPanel.SetActive(false);
        
        if(GameManager.Instant.GetBuildIndex() == 0)
        {
            if(_gameUI != null)
            _gameUI.SetActive(false);
        } 
        else
        {
            if(_startMenu != null)
            _startMenu.SetActive(false);
        }
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

        for (int i = 0; i<_starIMG.Length; i++)
        {
            _starIMG[i].sprite = (value > .33f * i) ? _star : _nullStar;
        }
    }
}