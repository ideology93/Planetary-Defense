using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : StateMachineBehaviour
{
  
    public Button menu;
    public Button quit;
       override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        menu.enabled = true;
        quit.enabled = true;
    }
}
