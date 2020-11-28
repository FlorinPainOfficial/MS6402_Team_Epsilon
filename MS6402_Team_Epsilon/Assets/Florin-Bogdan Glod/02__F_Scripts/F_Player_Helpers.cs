﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script works with the script that is controlling the player and with the script that is on the pistol. 
/// To fire, player first needs to aim. To do that, player needs to hold right click pressed, and an animation will play, with player raising weapon.
/// After the weapon is in position, the player can fire by pressing left click
/// </summary>
public class F_Player_Helpers : MonoBehaviour
{
    public GameObject pistolHandgun;
    public Animator anim;
    public float delayApprovalShooting;
    [HideInInspector] public float containerTime;
    [HideInInspector] public float cooldown = 0.1f;
    [HideInInspector] public float nextCooldown = 0;




    void Start()
    {

    }//Start



    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            anim.SetBool("Pain_Aiming", true);

            if (Time.time > nextCooldown && containerTime < delayApprovalShooting)
            {
                nextCooldown = Time.time + cooldown;
                containerTime += cooldown;
            }

            if(containerTime >= delayApprovalShooting)
            {
                pistolHandgun.GetComponentInChildren<SimpleShoot>().b_externalPermission = true;
            }

        }


        if (Input.GetKeyUp(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Pain_Aiming", false);
            containerTime = 0;
            pistolHandgun.GetComponentInChildren<SimpleShoot>().b_externalPermission = false;
        }


    }//Update




}//END
