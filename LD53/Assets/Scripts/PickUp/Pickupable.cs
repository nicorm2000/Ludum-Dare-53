using System;
using Player;
using UnityEngine;

namespace PickUp
{
    public class Pickupable : MonoBehaviour
    {
        [SerializeField] private int scoreIncrease;
        [SerializeField] float maxTime = 15f;

        float timer;

        private void Update()
        {
            if (timer > maxTime)
            {
                DestroyPickupable();
                timer = 0;
            }

            timer += Time.deltaTime;
        }

        private void DestroyPickupable()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
                
                GamePlayManager.Get().ModifyHp(scoreIncrease);
            }
        }
    }
}
