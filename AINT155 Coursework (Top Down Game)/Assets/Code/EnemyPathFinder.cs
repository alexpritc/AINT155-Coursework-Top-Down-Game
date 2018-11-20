/**********************************************************
 * 
 * EnemyPathFinder.cs
 * - connects the A* pathfinding code to our zombie, so it can pathfind the player
 * 
 * 
 * public variables
 * - target
 *   - the player Transform, this will be set by the Enemy component
 *   
 * 
 * private variables
 * - ai
 *   - this is a reference to the AILerp component on our Zombie
 *   - AILerp will do the moving towards and looking at the player
 *   
 *   
 * public custom methods
 * - SetTarget
 *   - this is used by the Enemy component to set the target variable to the player
 *   
 * 
 **********************************************************/
using UnityEngine;
using Pathfinding;

public class EnemyPathFinder : MonoBehaviour {

    /*
     * target
     * a reference to the player Transform
     * set using the SetTarget method by the Enemy component
     */ 
    public Transform target;

    /*
     * ai
     * a reference to the AILerp component
     * this is a custom component, part of the pathfinding library
     */ 
    private IAstarAI ai;


    /*
     * Start, provided by Monobehaviour
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
     * we will get the AILerp component here for use later
     * note, "IAstarAI" is an interface that AILerp uses
     * see link: https://unity3d.com/learn/tutorials/topics/scripting/interfaces?playlist=17117
     */
    private void Start()
    {
        /*
         * GET THE AILerp COMPONENT, STORE IN THE ai VARIABLE
         */ 
        ai = GetComponent<IAstarAI>();
    }

    /*
     * Update, provided by Monobehaviour
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
     * here we check we have the target and ai variables set
     * if they are set, we set our move destination to the target
     * then we start searching for a path towards the target
     */
    private void Update ()
    {
        /*
         * CHECK THE target AND ai VARIABLES ARE SET 
         */ 
        if (target != null && ai != null)
        {
            /*
             * SET THE DESTINATION TO THE target POSITION
             * we want to get the player position
             */ 
            ai.destination = target.position;

            /*
             * START SEARCHING FOR A PATH TO THE target POSITION
             * we call the SearchPath method on the ai component
             * this will automatically search for a path towards the target,
             * then start moving to towards it
             */ 
            ai.SearchPath();
        }
    }


    /*
     * SetTarget
     * this method is used by the Enemy component to set the player as the target to pathfind towards
     */ 
    public void SetTarget(Transform newTarget)
    {
        /*
         * SET THE target VARIABLE TO THE newTarget
         * we are given a newTarget Transform, which will be the player
         * we set this to our target variable
         */ 
        target = newTarget;
    }
}
