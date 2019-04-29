using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using System;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class Playerscore : MonoBehaviour
{
    public Animator anime;
    public bool already_exist;
    //public  Text scoreText;
    //public static int playerScore;
    public static int total_trophies = 20;
    public static string playerid_signup;
    public static string password_signup;
    public static string nickname_signup;

    public static string playerid_login;
    public static string password_login;
    public static string nickname_login;
    public static int skill;
    public static int multiplayer_skill;
    public static int trophies_locked;
    public static int trophies_unlocked;
    // public InputField nameText;
    public InputField playerid_signupText;
    public InputField password_signupText;
    public InputField nickname_signupText;

    public InputField playerid_loginText;
    public InputField password_loginText;

    //public InputField  pointsText;
    public Text Is_submitted;
    public Text Nickname;
    public Text Skilltext;
    public Text L_Trophiestext;
    public Text U_Trophiestext;
    public Text M_Skilltext;
    private System.Random random = new System.Random();
    int hash;
    // Start is called before the first frame update
    void Start()
    {
        
        /*new*/
        password_signupText.contentType = InputField.ContentType.Password;
        /*new*/
        password_loginText.contentType = InputField.ContentType.Password;
    }

    public void Sign_up()
    {

        playerid_signup = playerid_signupText.text;
        print("playerID:" + playerid_signup);

        password_signup = password_signupText.text;
        print("Password:" + password_signup);

        nickname_signup = nickname_signupText.text;
        print("Nickname:" + nickname_signup);

        skill = random.Next(0, 50);
        print("skill:" + skill);
        multiplayer_skill = random.Next(0, 40);
        print("multiplayer_skill:" + multiplayer_skill);
        trophies_unlocked = random.Next(0, 10);
        print("trophies_unlocked:" + trophies_unlocked);
        trophies_locked = total_trophies - trophies_unlocked;
        print("trophies_locked:" + trophies_locked);

    }



    playerinfo check_player_get = new playerinfo();
    public void OnSubmit()
    {
        Sign_up();

        /*new*/
        RestClient.Get("https://infiflow-f2fab.firebaseio.com/" + "users/" + ".json").Then(response =>
        {
            string boss = response.Text;
            var data = (JObject)JsonConvert.DeserializeObject(boss);
            if (data[playerid_signup] != null)
            {
                Is_submitted.text = "Player ID already in use!";
            }
            else
            {
                PostToDatabase();
            }
        });


    }

    private void PostToDatabase()
    {
        playerinfo new_player = new playerinfo();
        /*new*/ //RestClient.Put("https://infiflow-f2fab.firebaseio.com/" + playerid_signup + ".json", new_player);
                /*new*/
        RestClient.Put("https://infiflow-f2fab.firebaseio.com/" + "users/" + playerid_signup + ".json", new_player);        // SIGN UP SUCCESFULL GOTO MAIN MENU
        SceneManager.LoadScene(2);
        Is_submitted.text = "Success!";
    }

    public void Log_in()
    {
        playerid_login = playerid_loginText.text;
        print("Login player id:" + playerid_login);

        password_login = password_loginText.text;
        print("Login player password:" + password_login);

    }

    public void OnGet()
    {
        
        Log_in();
        //playerName = nameText.text;
        GetterfromDatabase();

    }
    public void GetterfromDatabase()
    {
        /*new*/
        RestClient.Get("https://infiflow-f2fab.firebaseio.com/" + "users/" + ".json").Then(response1 =>
        {
            string boss1 = response1.Text;
            var data1 = (JObject)JsonConvert.DeserializeObject(boss1);
            if (data1[playerid_login] == null)
            {
                Nickname.text = "Player ID does not exist!";
            }
            else
            {
                GetFromDatabase();
            }
        });
    }



    playerinfo new_player_get = new playerinfo();

    private void GetFromDatabase()
    {

        /*new*/
        RestClient.Get<playerinfo>("https://infiflow-f2fab.firebaseio.com/" + "users/" + playerid_login + ".json").Then(response =>
        {
            new_player_get = response;
            print("fetched player id:" + new_player_get.playerid);
            print("fetched player password:" + new_player_get.password);
            print("fetched player nickname:" + new_player_get.nickname);
            if (password_login == new_player_get.password)
            {
                print("lallalalala");
                /*
                Nickname.text = "Nickname:" +new_player_get.nickname;
                print("skill:" + new_player_get.skill);
                Skilltext.text = "Skill:"+ new_player_get.skill.ToString();

                M_Skilltext.text = "M_Skill:" + new_player_get.multiplayer_skill.ToString();

                U_Trophiestext.text = "U_trophies:" + new_player_get.trophies_unlocked.ToString();

                L_Trophiestext.text = "L_trophies:"+new_player_get.trophies_locked.ToString();
                */
                // GOTO main menu
                print("hamzah");
               
                SceneManager.LoadScene(2);
                print("hyyyyyyyyyyyyyyy");
                //if (Int32.TryParse(Skilltext.text, out new_player_get.skill))
                //{
                //    Skilltext.text = new_player_get.skill.ToString();

                //}
                //else
                //{
                //    print("no");
                //}
            }
            else
            {
                Nickname.text = "Password wrong!";

            }
        });

    }
   
    private void UpdateScore()
    {
        // int gotten_score;
        //gotten_score = new_player_get.userScore;
        //scoreText.text = gotten_score.ToString();
    }
   

}