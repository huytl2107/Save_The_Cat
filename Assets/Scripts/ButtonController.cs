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
}
