using UnityEngine;
namespace ExplosionSample
{
public class sDetonator : MonoBehaviour
{
    // 最大体力をインスペクタウィンドウから調整可能にするためにpublicに変更
    [Header("最大体力")] [SerializeField]
    private int maxHealth = 100; // 最大体力

    private int currentHealth; // 現在の体力

    [Header("爆風のPrefab")] [SerializeField] private DetonationalExplosion _explosionPrefab;

    // インスペクタウィンドウから設定可能な遅延時間
    [Header("死亡後の遅延時間（秒）")] [SerializeField] private float deathDelay = 3f;
    
    [Header("爆風の範囲")] [SerializeField] private float explosionRadius = 5f;

    // maxDamage フィールドをインスペクタから設定できるようにpublicに変更
    [Header("最大ダメージ")] [SerializeField] private float maxDamage = 50f;

    [Header("スコア")] [SerializeField] int score;

    //[SerializeField] GameObject GameSystem;
    GameObject GameSystem;





    private void Start()
    {
        currentHealth = maxHealth; // ゲーム開始時に体力を最大値に設定
        GameSystem = GameObject.Find("GameSystem");
    }





    // ダメージを受けたときの処理
    public void TakeDamage1(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                // インスペクタで設定した遅延時間後にExplosionメソッドを呼び出す
                Invoke("Explode3", deathDelay);
            }
        }
    }





    // 爆発をトリガーするメソッド
    private void Explode3()
    {
        // 爆風のプレハブを生成
        var explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            explosion.Explode();

        Explode1();    

        // オブジェクトの破壊
        Destroy(gameObject);
        //GameSystemにScoreを足す
        GameSystem.GetComponent<Score>().PlusScore(score);
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