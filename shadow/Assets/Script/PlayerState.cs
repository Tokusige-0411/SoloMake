using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public enum PlayerState
    {
        Idle,       // 立ち状態
        Walk,       // 歩いている
        Dash,       // 空中ﾀﾞｯｼｭ
        Hide,       // 隠れている
        Max
    }
}
