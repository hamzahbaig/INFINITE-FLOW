using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using System;
using UnityEngine.UI;
using System;
[Serializable]
public class playerinfo
{
    public string playerid;
    public string password;
    public string nickname;
    public int skill;
    public int multiplayer_skill;
    public int trophies_locked;
    public int trophies_unlocked;

    public playerinfo()
    {
        playerid = Playerscore.playerid_signup;
        password= Playerscore.password_signup;
        nickname = Playerscore.nickname_signup;
        skill = Playerscore.skill;
        multiplayer_skill = Playerscore.multiplayer_skill;
        trophies_locked = Playerscore.trophies_locked;
        trophies_unlocked = Playerscore.trophies_unlocked;
    }
}