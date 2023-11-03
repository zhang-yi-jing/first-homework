using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneSwitchCounter : MonoBehaviour
{
    public TextMeshPro counterText; // 用于显示切换次数的TextMeshPro组件
    private static int sceneSwitchCount = -1; // 场景切换计数器

    private void Awake()
    {
        // 将初始计数器值显示在TextMeshPro组件中
        UpdateCounterText();
    }

    private void Start()
    {
        // 增加计数器值
        sceneSwitchCount++;
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        // 更新TextMeshPro组件显示的文本
        counterText.text = sceneSwitchCount.ToString();
    }

    private void OnDestroy()
    {
        // 将计数器值传递给下一个场景
        PlayerPrefs.SetInt("SceneSwitchCount", sceneSwitchCount);
    }
}