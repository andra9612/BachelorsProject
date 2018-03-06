using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;

public class UnitSelection : MonoBehaviour
{
	bool isSelecting = false;
	Vector3 mouseDownPosition;
	public GameObject selectedPrefab;
	Texture2D texture;
	GameObject currentlySelected;
	GameObject select;
	public List<GameObject> selectedObjects;
	Vector3 mouseUpPosition;

	void Start()
	{
		texture = new Texture2D (1, 1);
		texture.SetPixel (0, 0, new Color (0.8f, 0.8f, 0.95f, 0.25f));
		texture.Apply();
		selectedObjects = new List<GameObject> ();
	}		

	void Update()
	{


		/*if (Input.GetMouseButton (1)) 
		{   
			Debug.Log (selectedObjects.Count);
			if (selectedObjects.Count != 0 || currentlySelected != null) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit =  new RaycastHit();
				if (Physics.Raycast (ray, out hit)) {
					if (selectedObjects.Count != 0) {
						foreach (var item in selectedObjects)
							item.Move (hit.point);
					} 
					else 
					{
						currentlySelected.GetComponent<Cube> ().Move (hit.point);
					}
				}
				//moveToPosition = Camera.main.ScreenToViewportPoint (Input.mousePosition);
				//moveToPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.z, 0f);

			}


		}*/

		IsSelectingStarted ();
		IsSelectingEnded ();



	}

	bool IsWithinSelectionBounds( GameObject gameObject )
	{
		if( !isSelecting )
			return false;

		var camera = Camera.main;
		var viewportBounds = DrawHelper.GetBounds( camera, mouseDownPosition, Input.mousePosition );
		return viewportBounds.Contains( camera.WorldToViewportPoint( gameObject.transform.position ) );
	}

	void OnGUI()
	{
		if( isSelecting )
		{
			var rect = DrawHelper.GetRectangle( mouseDownPosition, Input.mousePosition );
			GUI.DrawTexture (rect, texture);
		}
			
			
	}

	void selectCharacter()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();				
		if (Physics.Raycast (ray, out hit)) 
		{
			/*if (currentlySelected == null) {
				if (hit.collider.gameObject.tag == "Player") {
					currentlySelected = hit.collider.gameObject;
					currentlySelected.GetComponent<Human> ().Selected = Instantiate (selectedPrefab, currentlySelected.transform.GetChild(0));
				} 
			} else {
				if (hit.collider.gameObject.tag == "Player") {
					currentlySelected = null;
					currentlySelected = hit.collider.gameObject;
					currentlySelected.GetComponent<Human> ().Selected = Instantiate (selectedPrefab, currentlySelected.transform.GetChild (0));
				} else {
					currentlySelected = null;
					Destroy (select);
					Debug.Log (currentlySelected);
				}
			}*/
			if (hit.collider.gameObject.tag == "Player") 
			{
					selectedObjects.Clear ();
					selectedObjects.Add (hit.collider.gameObject);
					selectedObjects [0].GetComponent<Human> ().Selected = Instantiate (selectedPrefab, selectedObjects [0].transform.GetChild (0));
			} 
			else 
			{
				foreach (GameObject go in selectedObjects) 
				{
					Destroy(go.GetComponent<Human>().Selected.gameObject);
				}
				selectedObjects.Clear ();

			}
		}
		isSelecting = false;
	}

	void IsSelectingStarted()
	{
		if( Input.GetMouseButtonDown( 0 ) )
		{

			isSelecting = true;
			mouseDownPosition = Input.mousePosition;

			foreach( var selectableObject in FindObjectsOfType<Human>() )
			{
				if( selectableObject.Selected != null )
				{
					Destroy( selectableObject.Selected.gameObject );
					selectableObject.Selected = null;
				}
			}
		}
	}

	void IsSelectingEnded()
	{
		if( Input.GetMouseButtonUp( 0 ) )
		{
			mouseUpPosition = Input.mousePosition;
			if (mouseDownPosition == mouseUpPosition)
				selectCharacter ();
			else 
			{
<<<<<<< HEAD
				/*foreach (var selectableObject in FindObjectsOfType<Human>()) {
					if (IsWithinSelectionBounds (selectableObject.gameObject)) {
						selectedObjects.Add (selectableObject.gameObject);
					}
				}*/
=======
				foreach (var selectableObject in FindObjectsOfType<Human>()) {
					if (IsWithinSelectionBounds (selectableObject.gameObject)) {
						selectedObjects.Add (selectableObject.gameObject);
					}
				}
>>>>>>> 0ae5f0d86388174acb0caee9372780532786ddc7
				var sb = new StringBuilder ();
				sb.AppendLine (string.Format ("Selecting [{0}] Units", selectedObjects.Count));
				foreach (var selectedObject in selectedObjects)
					sb.AppendLine ("-> " + selectedObject.gameObject.name);
				Debug.Log (sb.ToString ());

				isSelecting = false;
			}
		}


		if( isSelecting )
		{
			selectedObjects.Clear ();
			foreach( var selectableObject in FindObjectsOfType<Human>() )
			{
				if( IsWithinSelectionBounds( selectableObject.gameObject ) )
				{
					selectedObjects.Add (selectableObject.gameObject);
					if( selectableObject.Selected == null )
					{
						selectableObject.Selected = Instantiate (selectedPrefab, selectableObject.transform.GetChild(0));
					}
				}
				else
				{
					if( selectableObject.Selected != null )
					{
						Destroy( selectableObject.Selected.gameObject );
						selectableObject.Selected = null;
					}
				}
			}
		}
	}
		
}
