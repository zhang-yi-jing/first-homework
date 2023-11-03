using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneSwitchCounter : MonoBehaviour
{
    public TextMeshPro counterText; // ������ʾ�л�������TextMeshPro���
    private static int sceneSwitchCount = -1; // �����л�������

    private void Awake()
    {
        // ����ʼ������ֵ��ʾ��TextMeshPro�����
        UpdateCounterText();
    }

    private void Start()
    {
        // ���Ӽ�����ֵ
        sceneSwitchCount++;
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        // ����TextMeshPro�����ʾ���ı�
        counterText.text = sceneSwitchCount.ToString();
    }

    private void OnDestroy()
    {
        // ��������ֵ���ݸ���һ������
        PlayerPrefs.SetInt("SceneSwitchCount", sceneSwitchCount);
    }
}