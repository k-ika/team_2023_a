using UnityEngine;

public class sDamageReceiver : MonoBehaviour
{
    // 最大体力をインスペクタウィンドウから調整可能にするためにpublicに変更
    [Header("最大体力")] [SerializeField]
    private int maxHealth = 100; // 最大体力

    private int currentHealth; // 現在の体力

    // インスペクタウィンドウから設定可能な遅延時間
    [Header("死亡後の遅延時間（秒）")] [SerializeField]
    private float deathDelay = 3f;

    [Header("スコア")] [SerializeField] int score;

    [Header("このオブジェクトの名前")] [SerializeField] string thisObjectname;
    GameObject GameSystem;

    private void Start()
    {
        currentHealth = maxHealth; // ゲーム開始時に体力を最大値に設定
        GameSystem = GameObject.Find("GameSystem");
    }

    // ダメージを受けたときの処理
    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                // インスペクタで設定した遅延時間後にDieメソッドを呼び出す
                Invoke("Die", deathDelay);
            }
        }
    }

    // オブジェクトが死亡したときの処理
    private void Die()
    {
        //GameSystemにScoreを足す
        GameSystem.GetComponent<Score>().PlusScore(score);
        // オブジェクトの破壊など、必要な処理を追加
        Destroy(gameObject);
        //破壊率のオブジェクト数に1足す
        GameSystem.GetComponent<DestroyPercent>().PlusDestroyPer(1);

        //Logにポイントを表示させる
        GameSystem.GetComponent<LogScript>().LogUpdater("\n+" + score + "(" + thisObjectname + ")");
    }
}
