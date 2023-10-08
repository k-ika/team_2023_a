using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExplosionSample
{
    public class s2BombDamage : MonoBehaviour
    {
        [Header("爆発までの時間[s]")] [SerializeField]
        private float _time = 3.0f;

        [Header("爆風のPrefab")] [SerializeField] private Explosion _explosionPrefab;

        [Header("爆風の範囲")] [SerializeField] private float explosionRadius = 5f;

        // maxDamage フィールドをインスペクタから設定できるようにpublicに変更
        [Header("最大ダメージ")] [SerializeField] private float maxDamage = 50f;

        private void Start()
        {
            // 一定時間経過後に発火
            Invoke(nameof(Explode), _time);

            //このメソッドは、爆弾がステージ外で生成されたときの処理である
            LimitPosition();
        }

        private void Explode()
        {
            // 爆発を生成
            var explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            explosion.Explode();

            Explode1();
            
            // 自身は消える
            Destroy(this.gameObject);
        }

        private void Explode1()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

            foreach (Collider collider in colliders)
            {
                // 距離に応じてダメージを計算
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                float damage = Mathf.Lerp(maxDamage, 0f, distance / explosionRadius);

                //DamageReceiver damageReceiver = collider.GetComponent<DamageReceiver>();
                sDamageReceiver damageReceiver = collider.GetComponent<sDamageReceiver>();
                if (damageReceiver != null)
                {
                    damageReceiver.TakeDamage(Mathf.RoundToInt(damage));
                }

                //Detonator damageReceiver1 = collider.GetComponent<Detonator>();
                sDetonator damageReceiver1 = collider.GetComponent<sDetonator>();
                if (damageReceiver1 != null)
                {
                    damageReceiver1.TakeDamage1(Mathf.RoundToInt(damage));
                }
            }
        }
        void LimitPosition()
        {
            GameObject Player = GameObject.Find("Player");

            Vector3 currentPos = transform.position;
        
            //追加　Mathf.ClampでX,Yの値それぞれが最小～最大の範囲内に収める。
            //範囲を超えていたら範囲内の値を代入する
            currentPos.x = Mathf.Clamp(currentPos.x, Player.GetComponent<sPlayerController>().nxLimit, Player.GetComponent<sPlayerController>().pxLimit);
            currentPos.z = Mathf.Clamp(currentPos.z, Player.GetComponent<sPlayerController>().nzLimit, Player.GetComponent<sPlayerController>().pzLimit);
            
            //追加　positionをcurrentPosにする
            transform.position = currentPos;
        }
    }
}

