using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]private AudioSource _audioSource;
    [SerializeField] private AudioClip backgroundMusic;

    private void Awake()
    {
        int backgroundMusicCount = FindObjectsOfType<BackgroundMusic>().Length;
        if (backgroundMusicCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.gameObject);
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
        }
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
