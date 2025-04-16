using UnityEngine;

public interface IGetable
{
    public void Get();
}

public class Key : MonoBehaviour, IGetable
{
    public void Get()
    {
        KeyCounter.AddCount();
        Destroy(gameObject);
    }
}
