using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerCactusScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI pressKeyText;
    public bool inTrigger = false;
    public GameObject cactus;
    public GameObject jumpBoostTrigger;
    

    public void Start()
    {
        pressKeyText.enabled = false;
    }
    public void Update()
    {
        ColorChangeEffect();
    }
    public void OnTriggerEnter(Collider other)
    {
        pressKeyText.enabled = true;
        inTrigger = true;
    }

    public void OnTriggerExit(Collider other)
    {
        pressKeyText.enabled = false;
        inTrigger = false;
    }

    public void ColorChangeEffect()
    {
        if (Input.GetKeyDown(KeyCode.F) && inTrigger)
        {
            Debug.Log("Cactus effect");
            pressKeyText.enabled = false;
            Destroy(cactus);
            Destroy(gameObject);
            Destroy(jumpBoostTrigger);
        }
    }
}
