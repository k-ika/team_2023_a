using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneChange : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        Debug.Log("Pushed");
        // プレイボタンがクリックされたときの処理
        SceneManager.LoadScene("DifficultySelectionScene"); // シーン名を適切なものに変更
    }
}

