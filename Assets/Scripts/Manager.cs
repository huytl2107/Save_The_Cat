using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    void Start()
    {
        UIManager.Instant.LoadUI();
        Subject.Notify("StartGame");
    }

}
