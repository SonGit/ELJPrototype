using com.ootii.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOTiiButton : VR_FlashButton
{

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        if (gameObject.name == "MicroPhoneBnt_Play" && Panel_01Menu.instance != null)
        {
           // MessageDispatcher.AddListener(EnumTypeMessage.MICROPHONE_PLAY, Panel_01Menu.instance.OnMicroPhoneBnt_PlayMessageReceived, true);

            gameObject.SetActive(false);
        }

        if (gameObject.name == "MicroPhoneBnt_Pause" && Panel_01Menu.instance != null)
        {
            MessageDispatcher.AddListener(EnumTypeMessage.MICROPHONE_PAUSE, Panel_01Menu.instance.OnMicroPhoneBnt_PauseMessageReceived, true);

            gameObject.SetActive(true);
        }
    }

    public override void Update()
    {
        base.Update();
    }


    

}
