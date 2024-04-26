using UnityEngine;

public class Perigo : MonoBehaviour
{
    [SerializeField] private Transform[] spawn;
    [SerializeField] private GameObject perigo;
    [SerializeField] private Fase[] fase;
    private int rng;
    private int rngaux;

    void Start()
    {
        if (fase[0].ativar)
            InvokeRepeating("SpawnRNG", fase[0].timer, fase[0].timer);
        else if (fase[1].ativar)
            InvokeRepeating("SpawnRNG", fase[1].timer, fase[1].timer);
        else if (fase[2].ativar)
            InvokeRepeating("SpawnRNG", fase[2].timer, fase[2].timer);
    }

    void SpawnRNG()
    {
        
        rng = Random.Range(0, spawn.Length);
        while(rng == rngaux)
        {
            rng = Random.Range(0, spawn.Length);
        }
        rngaux = rng;
        
        Instantiate(perigo,spawn[rng].position, Quaternion.identity);    
    }
}

[System.Serializable]
public class Fase
{
    public string nome;
    public bool ativar;
    public float timer;
}
