using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher2 : MonoBehaviour
{
    public GameObject titleCanvas;
    public GameObject difficultyCanvas;

    public void SwitchToDifficultyCanvas()
    {
        titleCanvas.SetActive(true); // タイトル画面のキャンバスを非アクティブに
        difficultyCanvas.SetActive(false); // 難易度選択画面のキャンバスをアクティブに
    }
}
