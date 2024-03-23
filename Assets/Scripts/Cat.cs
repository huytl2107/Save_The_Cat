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
            Debug.Log("Va chạm với Enemies");
            UIManager.Instant.PopUpWinPanel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Lava"))
        {
            Debug.Log("Va chạm với Lava");
            UIManager.Instant.PopUpWinPanel();
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

}
