using Player;
using UnityEngine;

namespace EnemyController
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private int damage;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                other.GetComponent<PlayerManager>().ModifyHp(-damage);
            }
        }
    }
}