using System.Collections;
using MoreMountains.Tools;
using UnityEngine;

namespace Player
{
    public class PlayerManager : PlayableCharacter, MMEventListener<MMGameEvent>
    {
        public PlayerController player;
        
        public int currentHealth = 5;
        public int maxHealth = 5;
        public bool isDead;
        public int maxHealthCanBeIncrease = 10;
        
        public bool haveShield;
        public GameObject shield;
        public int shieldStrength = 2;
        public float shieldDuration = 30;

        public int score;
        public int scoreIncrement = 1;
        public float scoreIncrementDelay = 0.1f;
        
        private float _delayTime;
        
        public static PlayerManager Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            }
        }

        private void Start()
        {
            score = 0;
            isDead = false;
            _delayTime = 0;
        }

        private void Update()
        {
            _delayTime += Time.deltaTime;

            if (_delayTime > scoreIncrementDelay)
            {
                score += scoreIncrement;
                _delayTime = 0;
            }

            if (currentHealth < 0 || maxHealth < 0)
            {
                isDead = true;
            }

            if (isDead)
            {
                //do something
            }
            
        }

        public void IncreaseHealth(int value)
        {
            if(currentHealth + value <= maxHealth)
                currentHealth += value;
            else
                score += 100;
        }
        
        public void IncreaseMaxHealth(int value)
        {
            if (maxHealth + value <= maxHealthCanBeIncrease)
                maxHealth += value;
            else
                score += 1000;
        }

        public void DecreaseHealth(int value)
        {
            if (haveShield && shieldStrength > 0)
            {
                DecreaseShieldStrength();
            }
            else
            {
                currentHealth -= value;
                player.Hurt();
            }
            
        }
        
        public void DecreaseMaxHealth(int value)
        {
            if (haveShield && shieldStrength > 0)
            {
                DecreaseShieldStrength();
            }
            else
            {
                maxHealth -= value;
                player.Hurt();
            }
        }

        public void DecreaseShieldStrength()
        {
            if (shieldStrength > 1)
            {
                shieldStrength--;
            }
            else if (shieldStrength <= 1)
            {
                BreakShield();
            }
        }

        public void BreakShield()
        {
            haveShield = false;
            shield.SetActive(haveShield);
            shieldStrength = 0;
            shieldDuration = 0;
            StopAllCoroutines();
        }

        public void CreateShield(float duration, int strength)
        {
            shieldDuration = duration;
            shieldStrength = strength;
            
            if (!haveShield)
            {
                haveShield = true;
                shield.SetActive(haveShield);
                StartCoroutine(ShieldTimeout());
            }
            
        }

        public virtual void GameStart()
        {
            // _rigidbodyInterface.IsKinematic(false);
        }
        IEnumerator ShieldTimeout()
        {
            yield return new WaitForSeconds(shieldDuration);
            BreakShield();
        }

        public void OnMMEvent(MMGameEvent gameEvent)
        {
            if (gameEvent.EventName == "GameStart")
            {
                GameStart();
            }
        }
    }
}


