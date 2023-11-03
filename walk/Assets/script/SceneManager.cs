using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CollisionSwitcher : MonoBehaviour
{
    public GameObject player; // �������
    public GameObject cube; // ������Cube
    public string secondSceneName; // �ڶ�������������
    public TextMeshPro countText; // ������ʾ�л������� Text��TMP��

    private int switchCount; // �л���������

    private bool hasCollided; // ����Ƿ��ѷ�����ײ

    private void Start()
    {
        switchCount = PlayerPrefs.GetInt("SwitchCount", 0);
        UpdateCountText();
    }

    private void Update()
    {
        // �����ײ
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