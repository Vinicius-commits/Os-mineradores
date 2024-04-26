using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedraPerigo : MonoBehaviour
{
    [SerializeField] private GameObject pedra;
    [SerializeField] private GameObject pedraSpawnada;

    void Start()
    {
        Invoke("Gravidade", 1.5f);
        Invoke("DestruirObj", 5f);
    }
    void Gravidade()
    {
        Vector3 spw = new Vector3(transform.position.x , transform.position.y+15,transform.position.z);
        pedraSpawnada = Instantiate(pedra, spw , Quaternion.identity);
        if(pedraSpawnada is not null){
        Rigidbody rb = pedraSpawnada.GetComponent<Rigidbody>();
        rb.useGravity = true;
        }

    }
    void DestruirObj()
    {
        Destroy(this.gameObject);
    }
}
