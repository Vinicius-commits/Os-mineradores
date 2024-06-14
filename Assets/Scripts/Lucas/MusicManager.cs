using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioSource ambient_AudioSource;
    [SerializeField] private AudioClip[] musicLevel;
    [SerializeField] private AudioClip musicMuseu;
    [SerializeField] private bool museu;
    private int rnd;
    private static MusicManager instance;

    void Awake()
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

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Museu")
        {
            m_AudioSource.loop = true;
            m_AudioSource.PlayOneShot(musicMuseu);
            museu = true;
            ambient_AudioSource.Stop();
        }

        else
        {
            ambient_AudioSource.Play();
            m_AudioSource.loop = false;
            rnd = Random.Range(0, musicLevel.Length);
            m_AudioSource.PlayOneShot(musicLevel[rnd]);
            museu = false;
            Invoke("TrocarMusica",musicLevel[rnd].length);
        }

    }


    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu" || SceneManager.GetActiveScene().name == "Creditos" || SceneManager.GetActiveScene().name == "Configurations" || SceneManager.GetActiveScene().name == "MapaBrasil")
        {
            Destroy(gameObject);
        }
        if(museu != (SceneManager.GetActiveScene().name == "Museu"))
        {
            museu = !museu;
            m_AudioSource.Stop();
            CancelInvoke("TrocarMusica");
            Invoke("TrocarMusica", 0f);
        }

    }
    void TrocarMusica()
    {
        if (museu)
        {
            ambient_AudioSource.Stop();
            m_AudioSource.loop = true;
            m_AudioSource.PlayOneShot(musicMuseu);
            museu = true;
        }

        else
        {
            ambient_AudioSource.Play();
            m_AudioSource.loop = false;
            m_AudioSource.PlayOneShot(musicLevel[Random.Range(0, musicLevel.Length)]);
            museu = false;
            Invoke("TrocarMusica",musicLevel[rnd].length);
        }
    }
}
