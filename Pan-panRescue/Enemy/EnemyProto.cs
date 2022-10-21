using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Enemy prototype 만들어보기
//Reference : https://everycommit.tistory.com/42
public abstract class EnemyProto
{
    public abstract EnemyProto Clone();
}

//Clone 추상 메서드를 갖는 베이스 클래스를 만든다.
