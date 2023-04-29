using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private int score = 5;
        [SerializeField] private int hp = 3;

        public void ModifyScore(int scoreModifier)
        {
            score += scoreModifier;
        }

        public void ModifyHp(int hpModifier)
        {
            hp += hpModifier;
        }
    }
}