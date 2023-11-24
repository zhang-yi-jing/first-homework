using UnityEngine;

public class BackPack1 : MonoBehaviour
{
    private static BackPack1 instance;

    private void Awake()
    {
        if (instance == null)
        {
            // 保留唯一的实例
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 如果已经存在实例，则销毁当前对象
            Destroy(gameObject);
            return;
        }
    }
}