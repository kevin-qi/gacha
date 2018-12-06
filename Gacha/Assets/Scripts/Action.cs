using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour {
    public delegate void Finished();
    public static event Finished ActionFinished;

    public abstract bool Apply(GameObject source, GameObject target);

    // Announces that action is finished. Passes GameManager control.
    public void Done()
    {
        ActionFinished();
    }
}
