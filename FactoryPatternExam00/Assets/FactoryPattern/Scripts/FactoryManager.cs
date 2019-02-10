using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SimpleFactory;

public class FactoryManager : MonoBehaviour {
    public GameObject Cube;
    //큐브 만드는 갯수
    public int max = 3;
    //능력을 만드는 역활을 하는 공장
    AbilityFactory abilityFactory = new AbilityFactory();

    private void Start()
    {
        this.MakeObject();
    }

    void MakeObject(){
        GameObject clone;

        for (int index = 0; index < this.max;index++) {
            clone = Instantiate(this.Cube) as GameObject;
            clone.GetComponent<Cube>().abilities.Add(this.abilityFactory.GetAbility("fire"));

            if(index < 1) {
                clone.GetComponent<Cube>().abilities.Add(this.abilityFactory.GetAbility("heal"));
            }
        }
    }
}
