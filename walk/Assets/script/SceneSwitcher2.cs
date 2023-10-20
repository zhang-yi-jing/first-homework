using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 检查进入触发器区域的物体是否为指定物体
        if (other.CompareTag("Player"))
        {
            // 执行场景切换逻辑
            SceneManager.LoadScene("SampleScene");
        }
        Debug.Log("进入触发器区域");
    }
        
}