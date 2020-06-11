using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Volume))]
public class PostProcessingHueShift : MonoBehaviour
{
    Volume volume;

    public float hueVal = 0f;
    public float speed = 1;

    void Start()
    {
        volume = GetComponent<Volume>();
    }


    void Update()
    {
        if (volume.profile.TryGet(out ColorAdjustments colorAdjustments))
        {
            colorAdjustments.hueShift.value = hueVal;
        }

        //Count();
    }

    public void ColorChangeEffect()
    {
        hueVal += speed;
        if(hueVal > 180)
        {
            hueVal = -180;
        }
    }
}
