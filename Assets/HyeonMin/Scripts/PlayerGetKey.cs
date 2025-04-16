using UnityEngine;

public class PlayerGetKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IGetable>(out IGetable getKey))
        {
            if (getKey != null)
            {
                Debug.Log("¿­¼è È¹µæ °¡´É");
                getKey.Get();
            }
            else
            {
                Debug.LogWarning("Key°¡ ¾ø½À´Ï´Ù");
            }
        }
    }
}