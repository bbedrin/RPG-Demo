using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float healthPoints = 100f;
        private static readonly int DieTransitionTrigger = Animator.StringToHash("die");

        private bool _isDead = false;

        public bool IsDead()
        {
            return _isDead;
        }
        
        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            if (healthPoints == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (_isDead) return;

            _isDead = true;
            GetComponent<Animator>().SetTrigger(DieTransitionTrigger);
        }
    }
}