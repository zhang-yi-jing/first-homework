using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip soundClip;       // 需要播放的声音剪辑
    public AudioClip backgroundMusic; // 需要播放的背景音乐剪辑
    private AudioSource soundAudioSource;
    private AudioSource backgroundMusicAudioSource;

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

        // 创建两个新的 AudioSource 组件
        soundAudioSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicAudioSource = gameObject.AddComponent<AudioSource>();

        // 设置背景音乐的 AudioSource 组件
        backgroundMusicAudioSource.clip = backgroundMusic;
        backgroundMusicAudioSource.loop = true;
        backgroundMusicAudioSource.Play();
    }

    public void PlaySound()
    {
        // 播放声音剪辑，并设置循环播放
        soundAudioSource.clip = soundClip;
        soundAudioSource.loop = true;
        soundAudioSource.Play();
    }

    public void StopSound()
    {
        // 停止播放声音剪辑
        soundAudioSource.Stop();
    }
}