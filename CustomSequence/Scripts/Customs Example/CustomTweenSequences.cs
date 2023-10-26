using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DOTweenElement.UI;
using DG.Tweening;

namespace DOTweenElement.UI.Example
{
    //Inherit from CustomElement
    public class CustomTweenSequences : CustomElement
    {
        
        protected override void CustomStart()
        {
            //write the events in the start
        }
        protected override void CustomOnDestroy()
        {
            base.CustomOnDestroy();

            //write the events on the destroy
        }
        protected override void CreateReverseTween()
        {
            //describe the behavior of the twin during the reverse movement of time
            //customTween=...
           
        }
        protected override void CreateDirectTween()
        {
            //describe the behavior of the tween in the direct movement of time
            //customTween=...
           
        }
    }
}