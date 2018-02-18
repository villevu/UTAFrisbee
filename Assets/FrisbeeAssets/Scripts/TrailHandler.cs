﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailHandler : MonoBehaviour {

	// Variable for the width of the trail pieces
	public float trailSize;

	// Variable for the number of trail pieces drawn (100 = all, 20 = every fifth, etc.)
	public float trailFrequency;

	// List of trail piece objects
	List<GameObject> trailPieces;

    public Color trailColor = Color.red;

    bool rotSpeedSetting = true;

    //change whether tooltip shows rotation speed
    public void showRotSpeed(bool show)
    {
        rotSpeedSetting = show;
    }

    void Start() {

		// Initialize the list
		trailPieces = new List<GameObject>();
    }

	// Function to create the trail (called in ModeHandler after a throw is completed).
	// The parameter, buffer, is a list of frisbee positions (x, y, z)
	public void Create(List<FrisbeeLocation> buffer) {

		// Create a piece for every nth position in the buffer, based on the frequency
		for (int i = 0; i < buffer.Count; i += (int)(100/trailFrequency)) {

			// Create an empty sphere object for the trail pieces
			GameObject trailPiece = GameObject.CreatePrimitive (PrimitiveType.Sphere);

			// Set the width of the trail pieces to trailSize
			trailPiece.transform.localScale = new Vector3(trailSize, trailSize, trailSize);

			// Place the trail pieces at a position from the buffer
			trailPiece.transform.position = buffer[i].pos;

			// Set the trail pieces' color
			trailPiece.GetComponent<Renderer> ().material.color = trailColor;

			// Add a script component for the trail piece (for mouse hovering functionality)
			trailPiece.AddComponent<TrailPieceScript> ();

            // Set the mouse hover text to speed data from the buffer
            trailPiece.GetComponent<TrailPieceScript>().trailColor = trailColor;
            trailPiece.GetComponent<TrailPieceScript>().rotSpeed = buffer[i].rotSpeed;
			trailPiece.GetComponent<TrailPieceScript>().forwardSpeed = buffer[i].forwardSpeed;
            trailPiece.GetComponent<TrailPieceScript>().showRotSpeed(rotSpeedSetting);

            // Add the trail piece to the list
            trailPieces.Add(trailPiece);
		}
	}

	// Function to reset the trail (called in ModeHandler at the beginning of new throw)
    public void Reset() {

		// Destroy every trail piece object in the list (this can cause a lag spike)
		for (int i = 0; i < trailPieces.Count; i++) {
			Destroy (trailPieces [i]);
		}

		// Clear the list
		trailPieces.Clear ();
    }
}
