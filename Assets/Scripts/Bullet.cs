using UnityEngine;

namespace photonPun
{
    /// <summary>
    /// 子彈
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        /// <summary>
        /// 子彈的目標
        /// </summary>
        [HideInInspector]
        public Vector3 targetPoint;

        [SerializeField, Header("子彈移動速度"), Range(0, 1000)]
        private float speed = 60;

        [Header("子彈傷害"), Range(0, 10)]
        public float bulletDamage = 10;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position,targetPoint,speed * Time.deltaTime);
        }
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}

