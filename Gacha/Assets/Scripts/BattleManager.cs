using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {
    public delegate void Control(GameObject hero);
    public static event Control GiveControl;

    [SerializeField]
    private GameObject[] heroes;

    [SerializeField]
    private int maxTurnBar = 1000;

    private bool control = false;

    // Use this for initialization
    void Start () {
        heroes = GameObject.FindGameObjectsWithTag("Hero");
        Action.ActionFinished += AssumeControl;
								HeroSpawner.HeroesSpawned += AssumeControl;
				}
	
    void Update()
    {
        if (control)
        {
												heroes = GameObject.FindGameObjectsWithTag("Hero");
												GameObject activeHero = GetTurnOrder();
            if (activeHero != null)
            {
                GiveControl(activeHero); // Pass control to target hero.
                control = false; // Relinquish GameMaster control until target hero concludes their turn.
            }
            else
            {
                ElapseTime(); // If no heroes have filled turn bar, elapse time by 1 step.
            }
        }
    }

    private GameObject GetTurnOrder()
    {
        Array.Sort(heroes, new HeroComparer());
								var script = heroes[0].GetComponent<HeroStats>();
								if (script.GetTurnbar() >= maxTurnBar && !script.IsDead())
        {
            return heroes[0];
        }
        else
        {
            return null;
        }
    }
	
    private void ElapseTime()
    {
        foreach(GameObject hero in heroes)
        {
            var hero_stats = hero.GetComponent<HeroStats>();
												if (!hero_stats.IsDead())
												{
																hero_stats.ModTurnbar(hero_stats.GetSpeed());
												}
            
        }
    }

    private void AssumeControl()
    {
        control = true;
    }
}

public class HeroComparer : IComparer
{
    // Call CaseInsensitiveComparer.Compare with the parameters reversed.
    public int Compare(object x, object y)
    {
        int x_speed = ((GameObject) x).GetComponent<HeroStats>().GetTurnbar();
        int y_speed = ((GameObject) y).GetComponent<HeroStats>().GetTurnbar();

        return y_speed - x_speed;
    }
}
