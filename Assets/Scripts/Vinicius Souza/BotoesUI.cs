using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoesUI : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] AudioSource audio2;
    [SerializeField] AnimationClip animacao;
    private Animation animation;
    [SerializeField] GameObject imagem;
    [SerializeField] GameObject imagem2;

    void Start()
    {
        animation = GetComponent<Animation>(); 
    }
    public void TocarAudio()
    {
        audio.Play();
    }

    public void TocarAudio2()
    {
        audio2.Play();
    }

    public void TocarAnimacao()
    {
        animation.clip = animacao;
        animation.Play();
    }

    public void TocarImagem()
    {
        imagem.SetActive(true);
    }

    public void TirarImagem()
    {
        imagem.SetActive(false);
    }
    public void TocarImagem2()
    {
        imagem2.SetActive(true);
    }

    public void TirarImagem2()
    {
        imagem2.SetActive(false);
    }
}
