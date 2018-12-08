using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using Vuforia;

/*

*******Trigger a scene with Matching Vumark Id***********

Place script on a empty game object that is a child of the VuMark.

Create empty game objects with matching VuMark Instance Ids.

inside of those empty game objects put in what you want to be active when the VuMark Id id tracked.

1. Vumark

    a. Empty game object with this script (child of VuMark)

        i. Empty game object- named same as VuMark Id (child of empty game object with script)

            1. Stuff you want to show up whe the Vumark ID is found (Child of empty game object with VuMark Id name)

        i. Empty game object- named same as VuMark Id (child of empty game object with script)

            1. Stuff you want to show up whe the Vumark ID is found (Child of empty game object with VuMark Id name)

    You can make as many as you want. The script will look down the list

    and if it finds a matching VuMarkId and a child of the object the script is on,

    it will make that object active, if not all objects stay inactive

    If you find any errors please email me

    Rich

   

richfiore01@gmail.com


*/

public class VuMarkIdToScene : MonoBehaviour {



    public VuMarkTarget vumark;

    private VuMarkManager mVuMarkManager;

    void Start ()

        {

            mVuMarkManager = TrackerManager.Instance.GetStateManager().GetVuMarkManager();

        }

    void Update ()

        {

        foreach (var bhvr in mVuMarkManager.GetActiveBehaviours())

        {

            vumark = bhvr.VuMarkTarget;

            var VuId = vumark.InstanceId;

            print ("Found ID number " + VuId);

            foreach (Transform child in transform)

                {

           

                if (child.name == VuId.ToString())

                    {

                    child.gameObject.SetActive (true);

                    }

                else

                    {

                    child.gameObject.SetActive(false);

                    }

                }

        }

    }

}

