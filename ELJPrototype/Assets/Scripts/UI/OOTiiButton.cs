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

        //if (gameObject.name == "MicroPhoneBnt_Play" && Panel_01Menu.instance != null)
        //{
        //   // MessageDispatcher.AddListener(EnumTypeMessage.MICROPHONE_PLAY, Panel_01Menu.instance.OnMicroPhoneBnt_PlayMessageReceived, true);

        //}

        //if (gameObject.name == "MicroPhoneBnt_Pause" && Panel_01Menu.instance != null)
        //{
        //    MessageDispatcher.AddListener(EnumTypeMessage.MICROPHONE_PAUSE, Panel_01Menu.instance.OnMicroPhoneBnt_PauseMessageReceived, true);

        //}

        //if (gameObject.name == "SettingBnt" && Panel_01Menu.instance != null)
        //{
        //    MessageDispatcher.AddListener(EnumTypeMessage.GOTOSETTING, Panel_01Menu.instance.OnGoToSettingMessageReceived, true);
        //}

        //if (gameObject.name == "ExitBnt" && Panel_01Menu.instance != null)
        //{
        //    MessageDispatcher.AddListener(EnumTypeMessage.EXITSETTING, Panel_01Menu.instance.OnExitSettingMessageReceived, true);
        //}

        //if (gameObject.name == "RestartBnt" && Panel_01Menu.instance != null)
        //{
        //    MessageDispatcher.AddListener(EnumTypeMessage.RESTART, Panel_01Menu.instance.OnReStartMessageReceived, true);
        //}

        //if (gameObject.name == "HomeBnt" && Panel_01Menu.instance != null)
        //{
        //    MessageDispatcher.AddListener(EnumTypeMessage.HOME, Panel_01Menu.instance.OnHomeMessageReceived, true);
        //}


    }

    public override void Update()
    {
        base.Update();
    }


    

}
