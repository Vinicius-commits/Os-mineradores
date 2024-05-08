using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxigenio : MonoBehaviour
{
    [SerializeField] float Area;
    [SerializeField] GameObject Player;
    private OxigenioPlayer player;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Area);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject == Player)
        {
            player.oxigenioatual += 6 * Time.deltaTime;
        }
    }
}
