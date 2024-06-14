using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip[] walk;
    [SerializeField] private AudioClip[] run;
    [SerializeField] private AudioClip mine;

    // Update is called once per frame
    void Update()
    {

    }
    public void PassosAudio()
    {
        m_AudioSource.PlayOneShot(walk[Random.Range(0, walk.Length)]);
    }
    public void RunAudio()
    {
         m_AudioSource.PlayOneShot(run[Random.Range(0, run.Length)]);
    }
    public void Minerando()
    {
        m_AudioSource.PlayOneShot(mine);
    }
}
