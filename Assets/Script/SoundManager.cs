using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource Audio, music;

    [Header("Game Audio")]
    [SerializeField] private AudioClip jumpAudio;
    [SerializeField] private AudioSource scoreAudio;
    [SerializeField] private AudioSource gameOverAudio;
    [SerializeField] private AudioSource boundAudio;
    [SerializeField] private AudioClip buttonAudio;

    [Header("Game Music")]
    [SerializeField] private AudioClip[] sceneMusic;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void JumpSound()
    {
        Audio.clip = jumpAudio;
        Audio.Play();
    }
    public void ScoreSound()
    {
        scoreAudio.Play();
    }
    public void GameOverSound()
    {
        gameOverAudio.Play();
    }
    public void BoundSound()
    {
        boundAudio.Play();
    }
    public void ButtonSound()
    {
        Audio.clip = buttonAudio;
        Audio.Play();
    }

    public void SceneMusic(int sceneNumber)
    {
        music.clip = sceneMusic[sceneNumber];
        music.Play();
    }
}
