using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource m_AudioSource;
    #region Interacoes
    [Header("TiposDeChão")]
    [SerializeField] private bool metal;
    [SerializeField] private bool madeira;
    [SerializeField] private bool carpete;
    #endregion

    #region Interacoes
    [Header("Audios")]
    [SerializeField] private AudioClip mine;
    [SerializeField] private AudioClip agua;
    [SerializeField] private AudioClip[] walk;
    [SerializeField] private AudioClip[] run;
    [SerializeField] private AudioClip[] walkMetal;
    [SerializeField] private AudioClip[] runMetal;
    [SerializeField] private AudioClip[] walkMadeira;
    [SerializeField] private AudioClip[] runMadeira;
    [SerializeField] private AudioClip[] walkCarpete;
    [SerializeField] private AudioClip[] runCarpete;
    #endregion


    // Update is called once per frame
    void Update()
    {

    }
    public void PassosAudio()
    {
        CheckGroundTag();
        if (!metal && !madeira && !carpete)
            m_AudioSource.PlayOneShot(walk[Random.Range(0, walk.Length)]);
        else if (madeira && !metal && !carpete)
            m_AudioSource.PlayOneShot(walkMadeira[Random.Range(0, walkMadeira.Length)]);
        else if (!metal && carpete && !madeira)
            m_AudioSource.PlayOneShot(walkCarpete[Random.Range(0, walkCarpete.Length)]);
        else
            m_AudioSource.PlayOneShot(walkMetal[Random.Range(0, walkMetal.Length)]);
    }
    public void RunAudio()
    {
        CheckGroundTag();
        if (!metal && !madeira && !carpete)
            m_AudioSource.PlayOneShot(run[Random.Range(0, run.Length)]);
        else if (madeira && !metal && !carpete)
            m_AudioSource.PlayOneShot(runMadeira[Random.Range(0, runMadeira.Length)]);
        else if (!metal && carpete && !madeira)
            m_AudioSource.PlayOneShot(runCarpete[Random.Range(0, runCarpete.Length)]);
        else
            m_AudioSource.PlayOneShot(runMetal[Random.Range(0, runMetal.Length)]);
    }

    public void AguaAudio()
    {
        m_AudioSource.PlayOneShot(agua);
    }
    public void Minerando()
    {
        m_AudioSource.PlayOneShot(mine);
    }

    private void CheckGroundTag()
    {
        RaycastHit hit;
        Vector3 rayStart = transform.position + new Vector3(0, 0.5f, 0);

        if (Physics.Raycast(rayStart, Vector3.down, out hit, 2.0f))
        {
            if (hit.collider.tag == "Metal")
            {
                metal = true;
                madeira = false;
            }
            else if (hit.collider.tag == "Madeira")
            {
                metal = false;
                madeira = true;
            }
            else if (hit.collider.tag == "Carpete")
            {
                metal = false;
                madeira = false;
                carpete = true;
            }

            else
            {
                metal = false;
                madeira = false;
            }
        }
    }

    void OnDrawGizmos()
    {
        float maxDistance = 10f;
        RaycastHit hit;
        Vector3 rayStart = transform.position + new Vector3(0, 0.5f, 0);
        bool isHit = Physics.Raycast(rayStart, Vector3.down, out hit, 0);
        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(rayStart, Vector3.down);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(rayStart, Vector3.down);
        }
    }
}
