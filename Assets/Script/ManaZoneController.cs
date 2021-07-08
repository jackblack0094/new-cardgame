using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaZoneController : DMController
{
    private int manacount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        manacount = this.transform.childCount;
        Debug.Log(manacount);
    }
}
