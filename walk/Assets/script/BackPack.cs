using UnityEngine;

public class BackPack : MonoBehaviour
{
    private static BackPack instance;

    private void Awake()
    {
        if (instance == null)
        {
            // ����Ψһ��ʵ��
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // ����Ѿ�����ʵ���������ٵ�ǰ����
            Destroy(gameObject);
            return;
        }
    }
}