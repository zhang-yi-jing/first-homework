using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip soundClip;       // ��Ҫ���ŵ���������
    public AudioClip backgroundMusic; // ��Ҫ���ŵı������ּ���
    private AudioSource soundAudioSource;
    private AudioSource backgroundMusicAudioSource;

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

        // ���������µ� AudioSource ���
        soundAudioSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicAudioSource = gameObject.AddComponent<AudioSource>();

        // ���ñ������ֵ� AudioSource ���
        backgroundMusicAudioSource.clip = backgroundMusic;
        backgroundMusicAudioSource.loop = true;
        backgroundMusicAudioSource.Play();
    }

    public void PlaySound()
    {
        // ��������������������ѭ������
        soundAudioSource.clip = soundClip;
        soundAudioSource.loop = true;
        soundAudioSource.Play();
    }

    public void StopSound()
    {
        // ֹͣ������������
        soundAudioSource.Stop();
    }
}