using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaZoneController : DMController
{
    /// <summary>
    /// マナの最大値を数える変数
    /// </summary>
    private int manacount;
    /// <summary>
    /// マナの変化を検出するための変数
    /// </summary>
    private int currentcount;

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {

        currentcount = this.transform.childCount;
        if (this.transform.childCount >= 1 && currentcount != manacount)
        {
            manacount = currentcount;
            CountMana();
        }
    }

    public void CountMana()
    {
        //manacount = this.transform.childCount;
        Debug.Log("現在のマナは"+manacount+"です");
    }
}
