﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameState[] states;
    public GameState.StateName firstState;
    public GameState.StateName currentState;
    public int currentStateIndex = 0;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < states.Length; i++)
        {
            states[i].Initialize();
            states[i].onStateChange += delegate(GameState.StateName p_state)
            {
                ChangeGameState(p_state);
            };
        }
    }
	
	// Update is called once per frame
	void Update () {
        states[currentStateIndex].Update();
	}

    public void ChangeGameState(GameState.StateName p_newGameState)
    {
        for (int i = 0; i < states.Length; i++)
        {
            if (states[i].state == currentState) states[i].Disable();
        }

        for (int i = 0; i < states.Length; i++)
        {
            Debug.Log("Procurando novo estado");
            if (states[i].state == p_newGameState)
            {
                Debug.Log("Encontrou estado");
                states[i].Enable();
                currentStateIndex = i;
            }
        }
    }
}