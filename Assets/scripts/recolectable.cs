using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recolectable : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;

    private void Awake()
    {
        total++;
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
