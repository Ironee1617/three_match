using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ICheck
{
    void UpCheck(Fruit fruit);
    void DownCheck(Fruit fruit);
    void RightCheck(Fruit fruit);
    void LeftCheck(Fruit fruit);
}
