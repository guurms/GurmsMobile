using System.Collections.Generic;
using UnityEngine;

public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    private T prefab = null;

    public static GenericObjectPool<T> Instance { get; private set; }
    private Queue<T> objects = new Queue<T>();

    private void Awake() 
    {
        Instance = this;
        AddObjects(15);
    }

    public T Get() 
    {
        if (objects.Count == 0)
            AddObjects(1);
        return objects.Dequeue();
    }

    public void ReturnToPool(T objectToReturn) 
    {
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }

    private void AddObjects(int count)
    {
        for(int i = 0; i < count; i++)
        {
            var newObject = GameObject.Instantiate(prefab);

            newObject.name = prefab.name + objects.Count;

            newObject.gameObject.SetActive(false);
            objects.Enqueue(newObject);
        }
    }
}
