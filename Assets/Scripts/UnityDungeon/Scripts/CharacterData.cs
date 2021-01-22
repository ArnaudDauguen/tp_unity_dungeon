using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityDungeon {
    [CreateAssetMenu (fileName = "New Character", menuName = "CustomScripts/Character")]
    public class CharacterData : ScriptableObject {
        public new string name;
        public int maxHP;
        public int strength;
        public int defense;
        public int intelligence;

        [Tooltip("Chances for the attack to succeed. Must be between 0 and 1.")]
        public float precision;

        private float currentHP;
        public int HP 
        {
            get {
                return Mathf.RoundToInt (currentHP);
            }
            set
            {
                currentHP = value > 0 ? value : 0;
            }
        }
        public int MAXHP 
        {
            get {
                return Mathf.RoundToInt (maxHP);
            }
            set
            {
                maxHP = value > 0 ? value : 0;
            }
        }
        public int STR
        {
            get {
                return Mathf.RoundToInt (strength);
            }
            set
            {
                strength = value > 0 ? value : 0;
            }
        }
        public int INT
        {
            get {
                return Mathf.RoundToInt (intelligence);
            }
            set
            {
                intelligence = value > 0 ? value : 0;
            }
        }
        public float DEX
        {
            get {
                return precision;
            }
            set
            {
                precision = value > 0 ? (value > 1 ? 1 : value) : 0;
            }
        }

        void OnEnable()
        {
            currentHP = maxHP;
        }

        public void TakeDamage (float damage) {
            currentHP = Mathf.Max (currentHP - damage, 0);
            // currentHP -= damage;
            // if(currentHP < 0)
            // {
            //     currentHP = 0;
            // }
        }

        public void Heal (float health) {
            currentHP = Mathf.Min (currentHP + health, maxHP);
            // currentHP += health;
            // if(currentHP > maxHP)
            // {
            //     currentHP = maxHP;
            // }
        }
    }
}