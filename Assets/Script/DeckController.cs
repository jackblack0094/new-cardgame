using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        ///デッキにカードCardControllerクラスを継承したオブジェクトが置かれたとき(？)
        ///デッキに2枚以上カードがあればそれをZ軸で積み上げる
        ///1枚目のカードを置いた時には何も起こらない
        ///2枚目以降のカードを置いたときに1枚目のカードの座標を取ってきて1枚目の座標のZ+1にカードを動かす(これじゃダメ)
        ///このゾーンに何枚のカードが置いてあってそれが具体的に何か知りたい（配列？リスト？）
        ///
        ///
    }
}
