using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class crocoAnimations : MonoBehaviour {
	public bool idle;
	public bool walk;
	public bool run;
	public bool attack;
	public bool deffence;
	public bool dead;
	public Animator croco;
	public GameObject crocoBody;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (idle == true) {
			croco.Play ("idle");
		}
		if (walk == true) {
			croco.Play ("walking");
		}
		if (run == true) {
			croco.Play ("running");
		}
		if (attack == true) {
			croco.Play ("attack1");
		}
		if (deffence == true) {
			croco.Play ("deffence");
		}
		if (dead == true) {
			croco.Play ("dead");
		}
	}
	public void walkPress(){
		walk = true;
		idle = false;
		run = false;
		attack = false;
		deffence = false;
		dead = false;
	}
	public void idlePress(){
		walk = false;
		idle = true;
		run = false;
		attack = false;
		deffence = false;
		dead = false;
	}
	public void runPress(){
		walk = false;
		idle = false;
		run = true;
		attack = false;
		deffence = false;
		dead = false;
	}
	public void attackPress(){
		walk = false;
		idle = false;
		run = false;
		attack = true;
		deffence = false;
		dead = false;
	}
	public void deffencePress(){
		walk = false;
		idle = false;
		run = false;
		attack = false;
		deffence = true;
		dead = false;
	}
	public void deadPress(){
		walk = false;
		idle = false;
		run = false;
		attack = false;
		deffence = false;
		dead = true;
	}
	public void RotatePress(){
		crocoBody.transform.Rotate (0, 180, 0);
	}
}
