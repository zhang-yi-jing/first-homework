using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // �����봥��������������Ƿ�Ϊָ������
        if (other.CompareTag("Player"))
        {
            // ִ�г����л��߼�
            SceneManager.LoadScene("SampleScene");
        }
        Debug.Log("���봥��������");
    }
        
}