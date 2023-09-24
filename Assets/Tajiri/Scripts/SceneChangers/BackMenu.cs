using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenu : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        // プレイボタンがクリックされたときの処理
        SceneManager.LoadScene("Title"); // シーン名を適切なものに変更
    }
}

