using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip soundClip;  // 需要播放的声音剪辑
    private AudioSource audioSource;
    private bool isPlaying;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // 检测按下的键
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            if (!isPlaying)
            {
                PlaySound();
                isPlaying = true;
            }
        }
        // 检测松开的键
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) ||
                 Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            StopSound();
            isPlaying = false;
        }
    }

    private void PlaySound()
    {
        // 播放声音剪辑，并设置循环播放
        audioSource.clip = soundClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void StopSound()
    {
        // 停止播放声音剪辑
        audioSource.Stop();
    }
}