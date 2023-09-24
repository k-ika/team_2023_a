using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject titleCanvas;
    public GameObject difficultyCanvas;

    public void SwitchToDifficultyCanvas()
    {
        titleCanvas.SetActive(false); // タイトル画面のキャンバスを非アクティブに
        difficultyCanvas.SetActive(true); // 難易度選択画面のキャンバスをアクティブに
    }
}
