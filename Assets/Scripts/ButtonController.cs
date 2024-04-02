using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControler : MonoBehaviour
{
    public void RestartLevel()
    {
        GameManager.Instant.RestartGame();
    }

    public void NextLevel()
    {
        GameManager.Instant.LoadNextLevel();
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

