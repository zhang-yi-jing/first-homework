using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip soundClip;       // ��Ҫ���ŵ���������
    public AudioClip backgroundMusic; // ��Ҫ���ŵı������ּ���
    private AudioSource soundAudioSource;
    private AudioSource backgroundMusicAudioSource;
    private bool isPlaying;

    private static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            // ����Ψһ��ʵ��
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // ����Ѿ�����ʵ���������ٵ�ǰ����
            Destroy(gameObject);
            return;
        }

        // ���������µ�AudioSource���
        soundAudioSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicAudioSource = gameObject.AddComponent<AudioSource>();

        // ���ñ������ֵ�AudioSource���
        backgroundMusicAudioSource.clip = backgroundMusic;
        backgroundMusicAudioSource.loop = true;
        backgroundMusicAudioSource.Play();
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
        soundAudioSource.clip = soundClip;
        soundAudioSource.loop = true;
        soundAudioSource.Play();
    }

    private void StopSound()
    {
        // ֹͣ������������
        soundAudioSource.Stop();
    }
}