using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カードの初期化とリセットをするコンポーネント
/// </summary>
public class ResetButtonController : MonoBehaviour
{
    /// <summary>このデッキの上にカードを置く</summary>
    [SerializeField] LayoutGroup m_deck = null;
    /// <summary>カードを置く枚数</summary>
    [SerializeField] int m_count = 6;
    /// <summary>カードのプレハブ</summary>
    [SerializeField] Image m_cardPrefab = null;
    Sprite[] m_cardSprites = null;

    void Start()
    {
        m_cardSprites = Resources.LoadAll<Sprite>("Sprites");   // Resources/Sprites 以下にある全てのスプライトを読み込む
        Reset();
    }

    /// <summary>
    /// カードをリセットする
    /// </summary>
    public void Reset()
    {
        DestroyAllCards();

        for (int i = 0; i < m_count; i++)
        {
            Image image = CreateRandomCard();
            image.transform.SetParent(m_deck.transform);
        }
    }

    /// <summary>
    /// ランダムな絵柄のカードを一枚生成して戻り値として返す
    /// </summary>
    /// <returns></returns>
    Image CreateRandomCard()
    {
        Image image = Instantiate(m_cardPrefab);
        image.sprite = m_cardSprites[Random.Range(0, m_cardSprites.Length)];
        image.gameObject.name = image.sprite.name;
        return image;
    }

    /// <summary>
    /// 全てのカードを破棄する
    /// </summary>
    void DestroyAllCards()
    {
        foreach(var card in GameObject.FindGameObjectsWithTag("CardTag"))
        {
            Destroy(card);
        }
    }
}
