using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMinerio : MonoBehaviour
{
    [SerializeField] private GameObject[] minerios;
    [SerializeField] private Vector3 Posicaotop, Posicaobot;
    [SerializeField] private int NumMinerios;
    public void Start()
    {
        for(int i = 0; i < NumMinerios; i++)
        {
            int j = Random.Range(0, minerios.Length);
            Vector3 pos = new Vector3(Random.Range(Posicaotop.x, Posicaobot.x), 0.5f, Random.Range(Posicaotop.z, Posicaobot.z));
            GameObject G = Instantiate(minerios[j], pos, Quaternion.identity);
            G.transform.parent = transform;
        }
    }
}
