using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        [Header("Text")]
        public TMPro.TextMeshProUGUI jumpBoostText;
        public TMPro.TextMeshProUGUI GlobalTimerText;

        
        private JumpEnhance jumpEnhance;
        private FirstPersonController firstPersonController;

    public void Start()
        {
            jumpBoostText.enabled = false;//disabled de text van de boost aan het begin
            timerJump = boostTimer; // zet de timer's int op hetzelfde als de boost timer
            firstPersonController = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
            jumpEnhance = GameObject.Find("TriggerJumpBoost").GetComponent<JumpEnhance>();
            oldJumpPower = firstPersonController.m_JumpSpeed;
        }
        public void Update()
        {
            hasJumpPower = jumpEnhance.jumpPower;
            JumpPowerIncrease();
            UpdateJumpBoostText();
            Timer();
        }

        public void JumpPowerIncrease()// zet de jump power omhoog als je door de jumpboost trigger bent gegaan. daarna zet het de timer aan 
        {
            
            if (hasJumpPower == true)
            {
                firstPersonController.m_JumpSpeed = newJumpPower;
                jumpBoostText.enabled = true;
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
            }
        }

        public void UpdateJumpBoostText()// text van hoeveel sec er nog zijn op de jump boost
        {
            jumpBoostText.text = ("Jumpboost Remaining: " + (int)timerJump + " !");
        }

        public void Timer()//global timer van de game voor speedruns
        {
            timer += Time.deltaTime;
            GlobalTimerText.text = ("Timer: " + (int)timer + " !");
        }
    }
}
