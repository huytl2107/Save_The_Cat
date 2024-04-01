using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControler : MonoBehaviour
{
    public void RestartLevel()
    {
        GameManager.Instant.RestartGame();
        UIManager.Instant.PopDownWinPanel();
        UIManager.Instant.PopDownLosePanel();
    }

    public void NextLevel()
    {
        GameManager.Instant.LoadNextLevel();
        UIManager.Instant.PopDownWinPanel();
        UIManager.Instant.PopDownLosePanel();
    }

    public void PopUpExitConfirm()
    {
        UIManager.Instant.PopUpExitConfirm();
    }

    public void PopDownExitConfirm()
    {
        UIManager.Instant.PopDownExitConfirm();
    }

    public void ExitGame()
    {
        GameManager.Instant.ExitGame();
    }
}
