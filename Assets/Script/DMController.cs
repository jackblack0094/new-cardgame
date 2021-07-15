﻿using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームの基本を担当するコンポーネント
/// </summary>
public class DMController : MonoBehaviour
{
    [SerializeField] public GameObject LowerDeck = null;
    [SerializeField] public GameObject LowerCemetery = null;
    [SerializeField] public GameObject LowerBattleZone = null;
    [SerializeField] public GameObject LowerManaZone = null;
    [SerializeField] public GameObject LowerHandZone = null;

    /// <summary>このデッキの上にカードを置く</summary>
    [SerializeField] GameObject m_tsetHand = null;
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
    private void Update()
    {
        
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
            image.transform.SetParent(m_tsetHand.transform);
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
        foreach (var card in GameObject.FindGameObjectsWithTag("CardTag"))
        {
            Destroy(card);
        }
    }
    public void test()
    {
        Debug.Log("test");
    }
}
