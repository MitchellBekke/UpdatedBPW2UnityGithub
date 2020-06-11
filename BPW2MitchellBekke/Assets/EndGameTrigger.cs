using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{

    public class EndGameTrigger : MonoBehaviour
    {
        public GameManagerScript gameManager;
        

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(gameManager.EndGame());
        }



    }
}
