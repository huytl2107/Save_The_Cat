using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControler : MonoBehaviour
{
    public void RestartLevel()
    {
        GameManager.Instant.RestartGame();
    }

    public void ReturnHome()
    {
        GameManager.Instant.ReturnHome();
        UIManager.Instant.LoadUI();
    }

    public void NextLevel()
    {
        GameManager.Instant.LoadNextLevel();
    }

    public void ExitGame()
    {
        GameManager.Instant.ExitGame();
    }

    #region ExitConfirm
    public void PopUpExitConfirm()
    {
        UIManager.Instant.PopUpExitConfirm();
    }

    public void PopDownExitConfirm()
    {
        UIManager.Instant.PopDownExitConfirm();
    }
    #endregion ExitConfirm

    #region SettingPannel
    public void PopUpSettingPannel()
    {
        UIManager.Instant.PopUpSettingPannel();
    }

    public void PopDownSettingPannel()
    {
        UIManager.Instant.PopDownSettingPannel();
    }
    #endregion SettingPannel

    #region PausePannel
    public void PupUpPausePannel()
    {
        UIManager.Instant.PopUpPausePannel();
    }

    public void PopDownPausePannel()
    {
        UIManager.Instant.PopDownPausePannel();
    }

    public void PauseGame()
    {
        GameManager.Instant.PauseGame();
    }

    public void ResumeGame()
    {
        GameManager.Instant.ResumeGame();
    }
    #endregion PausePannel
}

