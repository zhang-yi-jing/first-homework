using UnityEngine;

public class BackPack1 : MonoBehaviour
{
    private static BackPack1 instance;

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