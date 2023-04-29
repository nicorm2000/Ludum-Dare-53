using Player;
using UnityEngine;

namespace EnemyController
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private int damage;
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
                FindObjectOfType<GamePlayManager>().ModifyHp(-damage);
            }
        }
    }
}