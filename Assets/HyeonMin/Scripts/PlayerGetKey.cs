using UnityEngine;

public class PlayerGetKey : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IGetable>(out IGetable getKey))
        {
            if (getKey != null)
            {
                Debug.Log("���� ȹ�� ����");
                getKey.Get();
            }
            else
            {
                Debug.LogWarning("Key�� �����ϴ�");
            }
        }
    }
}