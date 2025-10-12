using UnityEngine;
using UnityEngine.UI;

public class UIImageSwitcher : MonoBehaviour
{
    public Image targetImage; // UIのImageコンポーネント
    public string imageName;  // 変更したい画像の名前（アセットの名前）
    public string resourcesFolder = "Images"; // Resourcesフォルダ内の画像フォルダ名

    void Start()
    {
        ChangeImage(imageName);
    }

    public void ChangeImage(string newImageName)
    {
        if (string.IsNullOrEmpty(newImageName))
        {
            Debug.LogError("画像名が空です。");
            return;
        }

        // Resourcesフォルダからスプライトをロード
        Sprite newSprite = Resources.Load<Sprite>($"{resourcesFolder}/{newImageName}");

        if (newSprite != null)
        {
            targetImage.sprite = newSprite;
        }
        else
        {
            Debug.LogError($"画像 '{newImageName}' が見つかりませんでした。");
        }
    }
}
