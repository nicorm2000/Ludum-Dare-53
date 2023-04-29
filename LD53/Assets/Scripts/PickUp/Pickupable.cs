using System;
using Player;
using UnityEngine;

namespace PickUp
{
    public class Pickupable : MonoBehaviour
    {
        [SerializeField] private int scoreIncrease;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                other.GetComponent<PlayerManager>().ModifyHp(scoreIncrease);
            }
        }
    }
}
