using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyScene : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        // プレイボタンがクリックされたときの処理
        SceneManager.LoadScene("EasyGameScene"); // シーン名を適切なものに変更
    }
}

