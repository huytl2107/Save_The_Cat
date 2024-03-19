using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer _line;
    private Rigidbody2D _rb;
    private EdgeCollider2D _col;

    [SerializeField] private List<Vector2> _listPoints = new List<Vector2>();
    private Vector2 _oldPoint = Vector2.zero;

    void Start()
    {
        _line = GetComponent<LineRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<EdgeCollider2D>();
    }

    void Update()
    {
        //đảm bảo list là rỗng khi nhấn chuột
        if(Input.GetMouseButtonDown(0))
        {
            _listPoints.Clear();
            _line.positionCount = 0;
        }

        if(Input.GetMouseButtonUp(0))
        {
            _rb.simulated = true;
            _col.SetPoints(_listPoints);

            //Notify tới nest để spawn Bug
            Subject.Notify("EndLine");
        }

        if (!Input.GetMouseButton(0))
            return;

        Vector2 newPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(_oldPoint, newPoint) < .2f)
            return;

        _oldPoint = newPoint;
        _listPoints.Add(newPoint);

        _line.positionCount = _listPoints.Count;

        for (int i = 0; i < _listPoints.Count; i++)
        {
            _line.SetPosition(i, _listPoints[i]);
        }

    }
}
