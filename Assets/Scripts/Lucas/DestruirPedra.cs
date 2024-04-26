using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirPedra : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestruirObj", 3.5f);
    }

    void DestruirObj()
    {
        Destroy(this.gameObject);
    }
}
