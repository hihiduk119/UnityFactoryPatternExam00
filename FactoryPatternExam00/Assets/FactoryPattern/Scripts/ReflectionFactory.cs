using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace ReflectionFactory {
    /// <summary>
    /// 팩토리 패턴에서 추상화 클래스.
    /// </summary>
    public abstract class Ability
    {
        public abstract string Name { get; }
        public abstract void Process();
    }

    /// <summary>
    /// 추상화된 클래스를 구현한 공격 능력 클래스.
    /// </summary>
    public class StartFireAbility : Ability
    {
        //using .Net 3.5
        //public override string Name { get { return "fire"; }}
        //using .Net 4.0
        public override string Name => "fire";

        public override void Process()
        {

        }
    }

    /// <summary>
    /// 추상화된 클래스를 구현한 자체 힐 능력 클래스.
    /// </summary>
    public class HealSelfAbility : Ability
    {
        //using .Net 3.5
        //public override string Name { get { return "heal"; }}
        //using .Net 4.0
        public override string Name => "heal";
        public override void Process()
        {

        }
    }

    /// <summary>
    /// 해당 클래스의 능력을 공장에서 받아오는 클래스.
    /// </summary>
    public static class AbilityFactory
    {
        private static Dictionary<string, Type> abititiesByName;
        private static bool IsInitialized => abititiesByName != null;

        public static void InitializedFactory()
        {
            abititiesByName = new Dictionary<string, Type>();

            var abilityTypes = Assembly.GetAssembly(typeof(Ability)).GetTypes()
                                     .Where(myType => 
                                            myType.IsClass && 
                                            !myType.IsAbstract && 
                                            myType.IsSubclassOf(typeof(Ability)));

            foreach(var type in abilityTypes) {
                var tempEffect = Activator.CreateInstance(type) as Ability;
                abititiesByName.Add(tempEffect.Name, type);
            }
        }

        public static Ability GetAbility(string abilityType)
        {
            if (abititiesByName.ContainsKey(abilityType))
            {
                Type type = abititiesByName[abilityType];
                var ability = Activator.CreateInstance(type) as Ability;
                return ability;
            }

            return null;
        }

        internal static IEnumerable<string> GetAbilityNames()
        {
            return abititiesByName.Keys;
        }
    }
}
