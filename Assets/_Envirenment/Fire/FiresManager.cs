﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiresManager : ForceBase {

    static FiresManager instance;
    public static FiresManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(FiresManager)) as FiresManager;
            return instance;
        }
    }

    protected override void UpdateActive()
    {
        if (Time.time - lastChangedTime < minChangeTime) return;
        // if (activeIndex > 0 &&
        //     GetSqrDistanceToPlayer(activeIndex) > GetSqrDistanceToPlayer(activeIndex - 1))
        // {
        //     ChangeActive(activeIndex - 1);
        //     lastChangedTime = Time.time;
        //     return;
        // }

        if (activeIndex < obj.Length - 1 &&
            obj[activeIndex].transform.position.x < player.position.x)
        {
            ChangeActive(activeIndex + 1);
            lastChangedTime = Time.time;
            return;
        }
    }

    void Start() {
        player = Player.Instance.transform;
        base.StartWithTag("Fire");
    }
	
}
