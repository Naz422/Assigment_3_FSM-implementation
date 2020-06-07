using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_controller : MonoBehaviour
{
    public enum INIT_State { INITIAL, MOVING, DEAD, LEVEL_OVER };
    [SerializeField]
    private INIT_State currentState;

    private FSM_Running run;

    void Start()
    {
        run = GetComponent<FSM_Running>();
        CurrentState = INIT_State.INITIAL;
    }
    public INIT_State CurrentState
    {
        get
        {
            return currentState;
        }
        set
        {
            currentState = value;
            StopAllCoroutines();
            switch (currentState)
            {
                case INIT_State.INITIAL:
                    StartCoroutine(E_Initial(true));
                    break;
                case INIT_State.MOVING:
                    StartCoroutine(E_Running(true));
                    break;
                case INIT_State.DEAD:
                    StartCoroutine(E_Dead());
                    break;
            }
          }
    }
    public IEnumerator E_Initial(bool tick)
    {
        
            while (tick)
            {
                if (run.running)
                {
                    tick = false;
                    break;
                    CurrentState = INIT_State.MOVING;
                }
            }

            yield return null;
    
    }
    public IEnumerator E_Running(bool tick)
    {
       
            while (tick)
            {
                if (run.collide)
                {
                    if (run.energatic > 0)
                    {
                        tick = false;
                        
                        break;
                        CurrentState = INIT_State.DEAD;
                    }
                    else
                    {
                        tick = false;
                        CurrentState = INIT_State.LEVEL_OVER;
                    }

                }
            }
        
        yield return null;
    }
    public IEnumerator E_Dead()
    {

        yield return new WaitForSeconds(8f);
    }
    void Update()
    {


    }
}
// Start is called before the first frame update
