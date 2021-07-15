using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // この名前空間にあるインターフェイスを使う
using System.Linq;

/// <summary>
/// カードを制御するコンポーネント
/// 
/// Unity の UI で使えるインターフェイスの一覧
/// https://docs.unity3d.com/ja/2018.4/ScriptReference/EventSystems.IBeginDragHandler.html
/// （※）左パネルのリストに使えるインターフェイスの一覧がある
/// </summary>
public class CardController : DMController, IDragHandler, IPointerDownHandler, IBeginDragHandler,IDropHandler
{
    /// <summary>テーブルオブジェクト（"TableTag" が付いている UI オブジェクト）</summary>
    GameObject m_table = null;
    /// <summary>このオブジェクトの Rect Transform</summary>
    RectTransform m_rectTransform = null;
    /// <summary>デッキの外に置けるかどうかの設定</summary>
    [SerializeField] bool m_canPutOutOfDeck = false;
    /// <summary>動かす前に所属していたデッキ</summary>
    Transform m_originDeck = null;


    void OnValidate() 
    {
        
    }
    void Start()
    {
        m_rectTransform = GetComponent<RectTransform>();
        m_table = GameObject.FindGameObjectWithTag("TableTag");
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        m_rectTransform.position = eventData.position;
        this.transform.SetAsLastSibling();
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        string message = $"OnPointerDown: {this.name}: ";
        var currentDeck = GetCurrentZone(eventData);

        if (currentDeck)
        {
            message += $"マウスポインタは {currentDeck.name} の上にあります";
            m_originDeck = currentDeck.transform;
        }
        else
        {
            message += "マウスポインタはデッキの上にありません";
        }

        Debug.Log(message);
    }
    void IDropHandler.OnDrop(PointerEventData eventData) 
    {
        var currentZone = GetCurrentZone(eventData);
        if (currentZone)
        {
            this.transform.SetParent(currentZone.transform);
            //置かれたゾーンによって違う処理をする
            //BattleZone　このカードが何かをしらべてさらに処理を分岐
            //ManaZone Manaカウントを増やす　多色の場合タップして置かれる

            if (currentZone == LowerBattleZone)
            {
                Debug.Log("プレイ");
            }
            if (currentZone == LowerManaZone)
            {

            }
        }
        else if(!currentZone && m_canPutOutOfDeck == false)
        {
            this.transform.SetParent(m_originDeck.transform);
        }
        Debug.Log($"OnDrop: {currentZone}" );
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"OnBeginDrag: {this.name}");
        this.transform.SetParent(m_table.transform);
    }

    /// <summary>
    /// マウスカーソルが現在どのデッキの上にあるかを返す。デッキとは "ZoneTag" がタグ付けされた GameObject のこと。
    /// なお、デッキは UI オブジェクトつまり Rect Transform コンポーネントがアタッチされたオブジェクトである必要がある。
    /// </summary>
    /// <param name="eventData">PointerEventData 型の引数。マウス操作の情報が入っている。</param>
    /// <returns></returns>
    public GameObject GetCurrentZone(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results); // マウスポインタの位置上に重なっている UI を全て results に取得する（※）
        var result = results.Where(x => x.gameObject.CompareTag("ZoneTag")).FirstOrDefault();    // results に入っているオブジェクトのうち、ZoneTag が付いているオブジェクトを一つ取得する
        return result.gameObject;   // 結果の GameObject を返す

        //（※）EventSystem のインターフェイスを使った通常のプログラミングだと、オブジェクトが重なっている場合は「一番上に描画されているオブジェクト」しかマウスの動きを検出できない。
        // そのため、デッキの上にカードが重なっている場合、デッキ側でマウスの動きを検出できない。そのため EventSystem.current.RaycastAll を使う必要があった。
        // ちなみに Hierarchy 上で下にある UI オブジェクトが前面に描画される。
    }
}
