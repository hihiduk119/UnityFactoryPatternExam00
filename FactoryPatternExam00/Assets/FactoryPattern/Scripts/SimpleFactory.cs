using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SimpleFactory {
    /// <summary>
    /// 팩토리 패턴에서 추상화 클래스.
    /// </summary>
    public abstract class Ability {
        public abstract void Process();
    }

    /// <summary>
    /// 추상화된 클래스를 구현한 공격 능력 클래스.
    /// </summary>
    public class StartFireAbility : Ability {
        public override void Process()
        {

        }
    }

    /// <summary>
    /// 추상화된 클래스를 구현한 자체 힐 능력 클래스.
    /// </summary>
    public class HealSelfAbility : Ability {
        public override void Process()
        {

        }
    }

    /// <summary>
    /// 해당 클래스의 능력을 공장에서 받아오는 클래스.
    /// </summary>
    public class AbilityFactory {
        public Ability GetAbility(string name) {
            switch(name) {
                case "fire":
                    return new StartFireAbility();
                case "heal":
                    return new HealSelfAbility();
                default:
                    return null;
            }
        }
    }
}
