using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugNest : MonoBehaviour, IObserver
{
    private bool _canSpawn = false;
    private bool _gameOver = false;
    [SerializeField] private float _delayTime = .5f;
    // Start is called before the first frame update

    private void Awake()
    {
        Subject.Register(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canSpawn || _gameOver)
            return;

        ObjectPooler.Instant.GetPoolObject("Bug", transform.position, Quaternion.identity);
        _canSpawn = false;
        StartCoroutine("DelayTime");
    }

    private IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(_delayTime);
        _canSpawn = true;
    }

    public void OnNotify(string key)
    {
        if (key == "EndLine")
        {
            _canSpawn = true;
        }
        if(key == "GameOver")
        {
            _gameOver = true;
        }
    }
}