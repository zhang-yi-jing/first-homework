using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip soundClip;  // ��Ҫ���ŵ���������
    private AudioSource audioSource;
    private bool isPlaying;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // ��ⰴ�µļ�
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            if (!isPlaying)
            {
                PlaySound();
                isPlaying = true;
            }
        }
        // ����ɿ��ļ�
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) ||
                 Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            StopSound();
            isPlaying = false;
        }
    }

    private void PlaySound()
    {
        // ��������������������ѭ������
        audioSource.clip = soundClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void StopSound()
    {
        // ֹͣ������������
        audioSource.Stop();
    }
}