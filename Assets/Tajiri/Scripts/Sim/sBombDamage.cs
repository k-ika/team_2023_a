using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExplosionSample
{
    public class sBombDamage : MonoBehaviour
    {

        [Header("爆風のPrefab")] [SerializeField] private Explosion _explosionPrefab;
        //GameObject blast;

        [Header("爆風の範囲")] [SerializeField] private float explosionRadius = 5f;

        // maxDamage フィールドをインスペクタから設定できるようにpublicに変更
        [Header("最大ダメージ")] [SerializeField] private float maxDamage = 50f;
        GameObject Righthand;

        private void Start()
        {
            //blast = GameObject.Find("ExplosionForDetonator");
            Righthand = GameObject.Find("Righthand");
        }

        void OnCollisionEnter(Collision collision)
        {
            if (gameObject.transform.parent == null)
            {
                // 爆発を生成
                var explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
                explosion.Explode();
                // 爆発を生成
                //Instantiate(blast, transform.position, Quaternion.identity);
                //blast.GetComponent<Explosion>().Explode();

                Explode1();
                
                // 自身は消える
                Destroy(this.gameObject);
            }
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
    }
}

