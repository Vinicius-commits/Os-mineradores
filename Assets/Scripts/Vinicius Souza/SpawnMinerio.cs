using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMinerio : MonoBehaviour
{
    [SerializeField] private GameObject[] minerios;
    [SerializeField] private Transform[] Pos;
    [SerializeField] private int NumMinerios;
    public void Start()
    {
        for (int i = 0; i < NumMinerios; i++) 
        {
            int index = i % minerios.Length;
            Vector3 pos = Pos[i % Pos.Length].position;
            GameObject G = Instantiate(minerios[index], pos, Quaternion.identity);
            G.transform.parent = transform;
        }
    }
}
