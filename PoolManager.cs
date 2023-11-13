using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;

    static Dictionary<string, GameObject> ListPrefab = new Dictionary<string, GameObject>();
    static Dictionary<string, List<GameObject>> ListPool = new Dictionary<string, List<GameObject>>();

    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        ListPrefab.Clear();
        ListPool.Clear();
    }

    public static void CreatePool(GameObject prefab, int number)
    {
        if (!ListPrefab.ContainsKey(prefab.name))
        {
            ListPrefab.Add(prefab.name, prefab);
            InitPool(prefab.name, number);
        }
    }

    private static void InitPool(string name, int number)
    {
        GameObject prefab = ListPrefab[name];
        for (int i = 0; i < number; i++)
        {
            CreateObject(prefab);
        }
    }

    private static GameObject CreateObject(GameObject prefab)
    {
        GameObject ob = Instantiate(prefab, instance.transform);
        ob.SetActive(false);
        AddToPool(prefab.name, ob);

        return ob;
    }

    private static void AddToPool(string name, GameObject ob)
    {
        if (!ListPool.ContainsKey(name))
        {
            ListPool.Add(name, new List<GameObject>());
        }

        List<GameObject> list = ListPool[name];
        list.Add(ob);
    }

    public static GameObject GetObject(GameObject prefab, int count = 5)
    {
        if (!ListPool.ContainsKey(prefab.name))
        {
            CreatePool(prefab, count);
        }

        List<GameObject> list = ListPool[prefab.name];
        foreach (GameObject ob in list)
        {
            if (!ob.activeSelf)
            {
                ob.SetActive(true);
                return ob;
            }
        }
        return CreateObject(ListPrefab[prefab.name]);
    }
}

public interface IPoolObject
{
    //just disable object
    void ReturnObjectToPool();
}
