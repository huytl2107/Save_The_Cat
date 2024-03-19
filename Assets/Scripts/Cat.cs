using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemies"))
        {
            Debug.Log("Va chạm với Enemies");
            GameManager.Instant.RestartGame();
        }
    }
}
