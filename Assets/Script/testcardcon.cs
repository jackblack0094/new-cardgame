using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testcardcon : DMController
{
    [SerializeField] private Text cardname;
    [SerializeField] private Text cost;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(cardname.text);
        Debug.Log(cost.text.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
