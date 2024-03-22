using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject _winPanel;

    private void Awake()
    {
        PopDownWinPanel();
    }

    #region WinPanel
    public void PopUpWinPanel()
    {
        _winPanel.SetActive(true);
    }

    public void PopDownWinPanel()
    {
        _winPanel.SetActive(false);
    }
    #endregion WinPanel
}
