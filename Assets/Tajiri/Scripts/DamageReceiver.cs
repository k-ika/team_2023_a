using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    // 最大体力をインスペクタウィンドウから調整可能にするためにpublicに変更
    [Header("最大体力")] [SerializeField]
    private int maxHealth = 100; // 最大体力

    private int currentHealth; // 現在の体力

    // インスペクタウィンドウから設定可能な遅延時間
    [Header("死亡後の遅延時間（秒）")] [SerializeField]
    private float deathDelay = 3f;

    private void Start()
    {
        currentHealth = maxHealth; // ゲーム開始時に体力を最大値に設定
    }

    // ダメージを受けたときの処理
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            // インスペクタで設定した遅延時間後にDieメソッドを呼び出す
            Invoke("Die", deathDelay);
        }
    }

    // オブジェクトが死亡したときの処理
    private void Die()
    {
        // オブジェクトの破壊など、必要な処理を追加
        Destroy(gameObject);
    }
}
