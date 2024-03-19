using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : Singleton <ObjectPooler>
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectsPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectsPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectsPool);
        }
    }

    public GameObject GetPoolObject(string tag, Vector3 position, Quaternion roration)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Key " + tag + " doesn't exist!!!");
            return null;
        }

        GameObject objToSpawn = poolDictionary[tag].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = roration;

        Rigidbody2D rb = objToSpawn.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, 0f); //Set velocity về 0 tránh bug bọ bay thẳng lên trời khi gọi lại;

        poolDictionary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }
}