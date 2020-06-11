using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Characters.FirstPerson
{

    public class GameManagerScript : MonoBehaviour
    {
        [Header("TimeRelated")]
        [SerializeField] private float timer = 0;
        [SerializeField] private float timerJump;
        public float boostTimer = 25;

        [Header("JumpBoost")]
        public bool hasJumpPower = false;
        public float oldJumpPower;
        public float newJumpPower = 10;
        public bool gameIsEnded = false;

        [Header("UI")]
        public TMPro.TextMeshProUGUI jumpBoostText;
        public TMPro.TextMeshProUGUI globalTimerText;
        public TMPro.TextMeshProUGUI gameEndText;
        public Image jumpBoostIcon;

        [Header("Input")]
        public TriggerCactusScript cactusScript;
        public PostProcessingHueShift postProcessing;
        public GameObject endGameCollider;
        private JumpEnhance jumpEnhance;
        private FirstPersonController firstPersonController;

    public void Start()
        {
            jumpBoostText.enabled = false;//disabled de text van de boost aan het begin
            jumpBoostIcon.enabled = false;
            timerJump = boostTimer; // zet de timer's int op hetzelfde als de boost timer
            firstPersonController = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
            jumpEnhance = GameObject.Find("TriggerJumpBoost").GetComponent<JumpEnhance>();
            oldJumpPower = firstPersonController.m_JumpSpeed;
            gameEndText.enabled = false;
        }
        public void Update()
        {
            hasJumpPower = jumpEnhance.jumpPower;
            JumpPowerIncrease();
            UpdateJumpBoostText();
            Timer();
            
                if (cactusScript.cactusCollected == true)
                {
                    endGameCollider.SetActive(true);
                    postProcessing.ColorChangeEffect();
                }
            
        }

        public void JumpPowerIncrease()// zet de jump power omhoog als je door de jumpboost trigger bent gegaan. daarna zet het de timer aan 
        {
            
            if (hasJumpPower == true)
            {
                firstPersonController.m_JumpSpeed = newJumpPower;
                jumpBoostText.enabled = true;
                jumpBoostIcon.enabled = true;
                TimerJumpBoost();
            }
        }

        public void TimerJumpBoost()// telt af van 25 tot 0 en reset de boost
        {
            timerJump -= Time.deltaTime;
            if(timerJump <= 0)
            {
                jumpEnhance.jumpPower = false;
                firstPersonController.m_JumpSpeed = oldJumpPower;
                timerJump = boostTimer;
                jumpBoostText.enabled = false;
                jumpBoostIcon.enabled = false;
            }
        }

        public void UpdateJumpBoostText()// text van hoeveel sec er nog zijn op de jump boost
        {
            jumpBoostText.text = ("<color=orange>Jumpboost Active</color>" + "\n" + "Remaining: " + (int)timerJump + " !");
        }

        public void Timer()//global timer van de game voor speedruns
        {
            if (gameIsEnded == false)
            {
            timer += Time.deltaTime;
            globalTimerText.text = ("Timer: " + (int)timer + " !");
            }
        }

        public IEnumerator EndGame()
        {
            gameIsEnded = true;
            gameEndText.enabled = true;
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
