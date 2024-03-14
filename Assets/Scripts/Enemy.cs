using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed;
    private Rigidbody2D _rb;

    private bool _isColEnterLine = false;
    private float _delayTimeToMoveToWardPlayer = .2f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!_isColEnterLine)
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Line"))
        {
            _isColEnterLine = true;
            Vector2 force = new Vector2(transform.position.x - _target.transform.position.x, transform.position.y - _target.transform.position.y);
            _rb.AddForce(force * 5f, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Line"))
        {
            StartCoroutine("ExitLine");
        }
    }

    private IEnumerator ExitLine()
    {
        yield return new WaitForSeconds(_delayTimeToMoveToWardPlayer);
        _rb.velocity = new Vector2(0f, 0f);
        _isColEnterLine = false;
    }
}
