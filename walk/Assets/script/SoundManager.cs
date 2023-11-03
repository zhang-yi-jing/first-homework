using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip soundClip;       // 需要播放的声音剪辑
    public AudioClip backgroundMusic; // 需要播放的背景音乐剪辑
    private AudioSource soundAudioSource;
    private AudioSource backgroundMusicAudioSource;
    private bool isPlaying;

    private static SoundManager instance;

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

        // 创建两个新的AudioSource组件
        soundAudioSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicAudioSource = gameObject.AddComponent<AudioSource>();

        // 设置背景音乐的AudioSource组件
        backgroundMusicAudioSource.clip = backgroundMusic;
        backgroundMusicAudioSource.loop = true;
        backgroundMusicAudioSource.Play();
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
        soundAudioSource.clip = soundClip;
        soundAudioSource.loop = true;
        soundAudioSource.Play();
    }

    private void StopSound()
    {
        // 停止播放声音剪辑
        soundAudioSource.Stop();
    }
}