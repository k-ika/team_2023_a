using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public AudioClip bgmClip; // BGMとして再生するオーディオクリップ
    public float delayInSeconds = 2.0f; // シーン読み込み後の待機秒数

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgmClip; // AudioSourceにBGMクリップを設定
        SceneManager.sceneLoaded += OnSceneLoaded; // シーンが読み込まれたときに呼ばれるイベントを設定
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // シーンが読み込まれたら指定した秒数後にBGMを再生
        Invoke("PlayBGM", delayInSeconds);
    }

    private void PlayBGM()
    {
        // BGMを再生
        audioSource.Play();
    }
}

