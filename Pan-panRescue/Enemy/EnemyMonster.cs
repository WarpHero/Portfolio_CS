using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

//Reference : https://everycommit.tistory.com/42
//Reference : https://mrhook.co.kr/265
//Reference : https://learnandcreate.tistory.com/751
public class EnemyMonster : EnemyProto
{


    public override EnemyProto Clone()
    {
        throw new System.NotImplementedException();
    }  //Deep copy 방식으로 할 예정
}
