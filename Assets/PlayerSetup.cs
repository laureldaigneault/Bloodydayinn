using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisable;

    Camera sceneCamera;

    //launched when the player spawn, because we extend the class from NetworkBehavior
    void Start()
    {
        if (!isLocalPlayer)
        {
            for(int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        } else
        {
            sceneCamera = Camera.main; //we can call Camera.main, because we added the 'tag' main to that camera
            if (sceneCamera)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }  
    }

    void OnDisable()
    {
        if (sceneCamera)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
