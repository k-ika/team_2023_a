using UnityEngine;

namespace ExplosionSample
{
    public class Bomb : MonoBehaviour
    {
        [Header("爆発までの時間[s]")] [SerializeField]
        private float _time = 3.0f;

        [Header("爆風のPrefab")] [SerializeField] private Explosion _explosionPrefab;

        private void Start()
        {
            // 一定時間経過後に発火
            Invoke(nameof(Explode), _time);
        }

        private void Explode()
        {
            // 爆発を生成
            var explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            explosion.Explode();
            
            // 自身は消える
            Destroy(this.gameObject);
        }
    }
}
