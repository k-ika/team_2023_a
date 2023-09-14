using UnityEngine;
namespace ExplosionSample
{
public class Detonator : MonoBehaviour
{
    // 最大体力をインスペクタウィンドウから調整可能にするためにpublicに変更
    [Header("最大体力")] [SerializeField]
    private int maxHealth = 100; // 最大体力

    private int currentHealth; // 現在の体力

    [Header("爆風のPrefab")] [SerializeField] private DetonationalExplosion _explosionPrefab;


    // インスペクタウィンドウから設定可能な遅延時間
    [Header("死亡後の遅延時間（秒）")] [SerializeField]
    private float deathDelay = 3f;

    private void Start()
    {
        currentHealth = maxHealth; // ゲーム開始時に体力を最大値に設定
    }

    // ダメージを受けたときの処理
    public void TakeDamage1(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            // インスペクタで設定した遅延時間後にExplosionメソッドを呼び出す
            Invoke("Explode3", deathDelay);
        }
    }

    // 爆発をトリガーするメソッド
    private void Explode3()
    {
        // 爆風のプレハブを生成
        var explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            explosion.Explode();

        // オブジェクトの破壊
        Destroy(gameObject);
    }
}
}