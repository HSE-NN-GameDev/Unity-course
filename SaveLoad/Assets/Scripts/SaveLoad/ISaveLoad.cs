using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveLoad
{
    void Load(SaveStruct saveStruct);

    void Save(SaveStruct saveStruct);
}
