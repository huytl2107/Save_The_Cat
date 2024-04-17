using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _starPanel;
    [SerializeField] private GameObject _selecLevelPanel;
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _exitComfirm;
    [SerializeField] private GameObject _settingPanel;
    private SliderController _sliderController;

    [Header("Star")]
    private Image[] _starIMG;
    [SerializeField] private Sprite _star;
    [SerializeField] private Sprite _nullStar;

    [Header("Slider Bar")]
    [SerializeField] private Slider _slider;

    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        _sliderController = GetComponentInChildren<SliderController>();

        LoadUI();
        _starIMG = _starPanel.GetComponentsInChildren<Image>();
    }

    private void GetStar()
    {
        Debug.Log(_slider.value);
        float value = _slider.value;

        for (int i = 0; i < _starIMG.Length; i++)
        {
            _starIMG[i].sprite = (value > .33f * i) ? _star : _nullStar;
        }
    }

    public void LoadUI()
    {
        PopDownWinPanel();
        PopDownLosePanel();
        PopDownPausePannel();
        PopDownExitConfirm();
        PopDownSettingPannel();
        _selecLevelPanel.SetActive(false);
        _exitComfirm.SetActive(false);

        //Tham chiếu tới Line
        _sliderController.GetLine();

        if (GameManager.Instant.GetBuildIndex() == 0)
        {
            Debug.Log("Build Index: " + GameManager.Instant.GetBuildIndex());
            _gameUI.SetActive(false);
            _startMenu.SetActive(true);
        }
        else
        {
            Debug.Log("Build Index: " + GameManager.Instant.GetBuildIndex());
            _startMenu.SetActive(false);
            _gameUI.SetActive(true);
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

    #region ExitConfirm

    public void PopUpExitConfirm()
    {
        _exitComfirm.SetActive(true);
    }

    public void PopDownExitConfirm()
    {
        _exitComfirm.SetActive(false);
    }

    #endregion ExitConfirm

    #region SettingPanel
    public void PopUpSettingPannel()
    {
        _settingPanel.SetActive(true);
    }

    public void PopDownSettingPannel()
    {
        _settingPanel.SetActive(false);
    }
    #endregion SettingPannel

    #region PausePannel
    public void PopUpPausePannel()
    {
        _pausePanel.SetActive(true);
    }

    public void PopDownPausePannel()
    {
        _pausePanel.SetActive(false);
    }
    #endregion PausePannel
}