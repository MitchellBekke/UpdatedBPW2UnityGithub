using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnhance : MonoBehaviour
{
    public bool jumpPower = false;
    // Start is called before the first frame update

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        jumpPower = true;
    }
}
