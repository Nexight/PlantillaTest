using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorDeMonedas : MonoBehaviour
{
    TMPro.TMP_Text text;
    int contador;

    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    private void Start() => UpdateCount();

    void OnEnable() => recolectable.OnCollected += OnCollectibleCollected;
    void OnDisable() => recolectable.OnCollected -= OnCollectibleCollected;
    
    void OnCollectibleCollected()
    {
        contador++;
        UpdateCount();
    }

    void UpdateCount()
    {
        text.text = $"{contador} / {recolectable.total}";
    }
}
