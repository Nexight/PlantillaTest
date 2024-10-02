using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Transform Player;

    float lookRadius;

    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 0;
    public int vida { get; private set; }

    private void Awake()
    {
        lookRadius = MaxDist;
    }
    void Start()
    {
        vida = 100;   
    }

    public void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                
            }

        }

        VidaCheck();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
        if(collider.CompareTag("Proyectil"))
        {
            vida -= 25;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    
    void VidaCheck()
    {
        if (vida<=0)
        {
            Destroy(gameObject);
        }
    }

}
