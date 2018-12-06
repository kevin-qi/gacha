using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action {
    public override bool Apply(GameObject source, GameObject target)
    {
								var targetStats = target.GetComponent<HeroStats>();
        if (source != target && !targetStats.IsDead())
        {
            targetStats.ModHealth(-1 * Calc_Dmg(source, target));
            Done();
            return true;
        }
        else
        {
            Debug.Log("Cannot attack self or dead target");
            return false;
        }
    }

    private int Calc_Dmg(GameObject source, GameObject target)
    {
        return source.GetComponent<HeroStats>().GetAttack() - target.GetComponent<HeroStats>().GetDefense();
    }
}
