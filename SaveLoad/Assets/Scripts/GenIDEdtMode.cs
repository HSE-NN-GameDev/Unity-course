using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GenIDEdtMode : MonoBehaviour
{
    ToggleScript ts;

    private void Awake()
    {
        ts = GetComponent<ToggleScript>();
        if (ts.id == "")
            ts.GenerateId();
    }

}
