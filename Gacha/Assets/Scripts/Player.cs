using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public delegate void Success();
    public static event Success SuccessfulAction;

    [SerializeField]
    private GameObject target;

    [SerializeField] 
    private BattleManager gm;

    [SerializeField]
    private GameObject controller;

    // Use this for initialization
    void Start()
    {
        HeroController.HeroClicked += Select;
        BattleManager.GiveControl += SetController;
        Action.ActionFinished += TurnFinished;
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<BattleManager>();
    }

    private bool Select(GameObject hero, Action action)
    {
        Debug.Log(hero);
        target = hero;
        if(controller.GetComponent<HeroController>().Action(target, action))
        {
            return true;
        }
        else
        {
            target = null;
            return false;
        }
    }

    private void SetController(GameObject hero)
    {
        controller = hero;
    }

    private void TurnFinished()
    {
        target = null;
        controller = null;
    }

    
}
