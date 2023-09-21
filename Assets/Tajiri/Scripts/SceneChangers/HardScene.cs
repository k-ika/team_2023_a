using UnityEngine;
using UnityEngine.SceneManagement;

public class HardScene : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        // プレイボタンがクリックされたときの処理
        SceneManager.LoadScene("HardGameScene"); // シーン名を適切なものに変更
    }
}

