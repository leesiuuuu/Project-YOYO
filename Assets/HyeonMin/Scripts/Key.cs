using UnityEngine;

public interface IGetable
{
    public void Get();
}

public class Key : MonoBehaviour, IGetable
{
    KeyCounter counter;
    void Start()
    {
        counter = FindObjectOfType<KeyCounter>();
    }
    public void Get()
    {
        counter.AddCount();
        Destroy(gameObject);
    }
}
