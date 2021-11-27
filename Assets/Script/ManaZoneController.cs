using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaZoneController : DMController
{
    public static ManaZoneController Instance;
    /// <summary>
    /// マナの最大値を数える変数
    /// </summary>
    public int manacount;
    /// <summary>
    /// 使ったマナを数える変数
    /// </summary>
    public int usedmana;

    public int canusemana;
    /// <summary>
    /// マナの変化を検出するための変数
    /// </summary>
    private int currentcount;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //canusemana = manacount - usedmana;

        currentcount = transform.childCount;
        if (currentcount >= 1 && currentcount != manacount)
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
