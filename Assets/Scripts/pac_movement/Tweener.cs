using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{

    private Tween activeTween;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (activeTween != null) {

            if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.1f)
            {
                setState(activeTween.Target, activeTween.Orientation);
                float easeInCubic = ((Time.time - activeTween.StartTime) / activeTween.Duration) * ((Time.time - activeTween.StartTime) / activeTween.Duration) * ((Time.time - activeTween.StartTime) / activeTween.Duration);
                float linearMotion = (Time.time - activeTween.StartTime) / activeTween.Duration;
                Vector3 interpolation = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, linearMotion);  
                activeTween.Target.position = interpolation;
            }

            if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) <= 0.1f)
            {
                activeTween.Target.position = activeTween.EndPos;
                unsetState(activeTween.Target);
                activeTween = null;
            }

        }
        
    }

    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration, string orientation) { 
        if (activeTween == null)
        {
            activeTween = new Tween( targetObject,  startPos,  endPos, Time.time, duration, orientation);
        }
    }

    private void setState(Transform targetObject, string orientation)
    {
        //set param
        targetObject.GetComponent<Animator>().SetBool(orientation, true);
    }

    private void unsetState(Transform targetObject) {
        //unset all
        targetObject.GetComponent<Animator>().SetBool("right", false);
        targetObject.GetComponent<Animator>().SetBool("left", false);
        targetObject.GetComponent<Animator>().SetBool("up", false);
        targetObject.GetComponent<Animator>().SetBool("down", false);
    }
}
