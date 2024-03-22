using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _moveSpeed;
    private Rigidbody2D _rb;

    private bool _isColEnterLine = false;
    private float _delayTimeToMoveToWardPlayer = .2f;

    private bool _isLeftCat;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.Find("Cat");

        _isLeftCat = (transform.position.x - _target.transform.position.x) < 0 ? true : false;

        Debug.Log(_isLeftCat);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _isLeftCat ? 270 - CalculateAngle() : CalculateAngle() + 90);
        if(!_isColEnterLine)
            transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _moveSpeed * Time.fixedDeltaTime);
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

    private float CalculateAngle()
    {
        float oppositeSide = Mathf.Abs(transform.position.y - _target.transform.position.y);
        float adjacentSide = Mathf.Abs(transform.position.x - _target.transform.position.x);

        float alphaRad = Mathf.Atan2(oppositeSide, adjacentSide);

        float alphaDegree = alphaRad * 180 / Mathf.PI;

        return alphaDegree;
    }
}
