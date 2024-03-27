using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour, IObserver
{
    private Rigidbody2D _rb;
    private void Awake()
    {
        Subject.Register(this);
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemies"))
        {
            GameOVer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Lava"))
        {
            GameOVer();
        }
    }

    public void OnNotify(string key)
    {
        if(key == "EndLine")
        {
            if(_rb != null)
                _rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void GameOVer()
    {
        UIManager.Instant.PopUpLosePanel();
        Subject.Notify("GameOver");
    }

}
