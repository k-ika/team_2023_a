using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher3 : MonoBehaviour
{
    public GameObject Ato;
    public GameObject Mae;

    public void SwitchToDifficultyCanvas()
    {
        Ato.SetActive(true); // タイトル画面のキャンバスを非アクティブに
        Mae.SetActive(false); // 難易度選択画面のキャンバスをアクティブに
    }
}
