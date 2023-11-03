using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CollisionSwitcher : MonoBehaviour
{
    public GameObject player; // 玩家物体
    public GameObject cube; // 触发器Cube
    public string secondSceneName; // 第二个场景的名称
    public TextMeshPro countText; // 用于显示切换次数的 Text（TMP）

    private int switchCount; // 切换次数计数

    private bool hasCollided; // 标记是否已发生碰撞

    private void Start()
    {
        switchCount = PlayerPrefs.GetInt("SwitchCount", 0);
        UpdateCountText();
    }

    private void Update()
    {
        // 检测碰撞
        if (!hasCollided && player != null && cube != null)
        {
            Collider playerCollider = player.GetComponent<Collider>();
            Collider cubeCollider = cube.GetComponent<Collider>();

            if (playerCollider != null && cubeCollider != null)
            {
                if (playerCollider.bounds.Intersects(cubeCollider.bounds))
                {
                    hasCollided = true;
                    SwitchToSecondScene();
                    IncrementCount();
                    UpdateCountText();
                }
            }
        }
    }

    private void SwitchToSecondScene()
    {
        PlayerPrefs.SetInt("SwitchCount", switchCount);
        SceneManager.LoadScene(secondSceneName);
    }

    private void IncrementCount()
    {
        switchCount++;
    }

    private void UpdateCountText()
    {
        if (countText != null)
        {
            countText.text = switchCount.ToString();
        }
    }
}