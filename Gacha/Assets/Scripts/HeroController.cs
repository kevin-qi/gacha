using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

    public delegate bool ClickAction(GameObject hero, Action action); // returns true if ClickAction is valid
    public static event ClickAction HeroClicked;

    [SerializeField]
    private bool control;

    public GameObject turnMarkerPrefab;
    private GameObject turnMarker;


    // Use this for initialization
    void Start () {
        BattleManager.GiveControl += HasControl;
        control = false;
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked!");
            if (HeroClicked(this.gameObject, new Attack())) // Check if clicked target is valid
            {
                Debug.Log("Valid attack!");
            }
        }
    }

    public bool Action(GameObject target, Action action)
    {
        Debug.Log("action!");
        if (action.Apply(this.gameObject, target))
        {
            this.gameObject.GetComponent<HeroStats>().ResetTurnbar();
            control = false;
            Destroy(turnMarker);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void HasControl(GameObject hero)
    {
        if(hero == this.gameObject)
        {
            Debug.Log("has control", this.gameObject);
            // Activate desired behavior here for when it is hero's turn.
            control = true;
            turnMarker = Instantiate(turnMarkerPrefab, this.transform);
            turnMarker.transform.position = this.transform.position + new Vector3(0, 1.5f, 0);
        }
    }
}
