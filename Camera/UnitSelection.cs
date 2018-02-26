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
	Vector3 mousePosition1;
	public GameObject selectedPrefab;
	Texture2D texture;
	GameObject currentlySelected;
	GameObject select;
	List<Cube> selectedObjects;

	void Start()
	{
		texture = new Texture2D (1, 1);
		texture.SetPixel (0, 0, new Color (0.8f, 0.8f, 0.95f, 0.25f));
		texture.Apply();
		selectedObjects = new List<Cube> ();
	}

	void Update()
	{
		if (Input.GetMouseButton (1)) 
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


		}

		if( Input.GetMouseButtonDown( 0 ) )
		{
			
			isSelecting = true;
			mousePosition1 = Input.mousePosition;

			foreach( var selectableObject in FindObjectsOfType<Cube>() )
			{
				if( selectableObject.Selected != null )
				{
					Destroy( selectableObject.Selected.gameObject );
					selectableObject.Selected = null;
				}
			}
		}


		if( Input.GetMouseButtonUp( 0 ) )
		{
			foreach( var selectableObject in FindObjectsOfType<Cube>() )
			{
				if( IsWithinSelectionBounds( selectableObject.gameObject ) )
				{
					selectedObjects.Add( selectableObject );
				}
			}
			if (Mathf.Abs(mousePosition1.x - Input.mousePosition.x) <=3f || Mathf.Abs(mousePosition1.z - Input.mousePosition.z) <=3f)
				selectCharacter ();
			var sb = new StringBuilder();
			sb.AppendLine( string.Format( "Selecting [{0}] Units", selectedObjects.Count ) );
			foreach( var selectedObject in selectedObjects )
				sb.AppendLine( "-> " + selectedObject.gameObject.name );
			Debug.Log( sb.ToString() );

			isSelecting = false;
		}


		if( isSelecting )
		{
			selectedObjects.Clear ();
			foreach( var selectableObject in FindObjectsOfType<Cube>() )
			{
				if( IsWithinSelectionBounds( selectableObject.gameObject ) )
				{
					selectedObjects.Add (selectableObject);
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

	public bool IsWithinSelectionBounds( GameObject gameObject )
	{
		if( !isSelecting )
			return false;

		var camera = Camera.main;
		var viewportBounds = DrawHelper.GetBounds( camera, mousePosition1, Input.mousePosition );
		return viewportBounds.Contains( camera.WorldToViewportPoint( gameObject.transform.position ) );
	}

	void OnGUI()
	{
		if( isSelecting )
		{
			var rect = DrawHelper.GetRectangle( mousePosition1, Input.mousePosition );
			GUI.DrawTexture (rect, texture);
		}
	}

	void selectCharacter()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();				
		if (Physics.Raycast (ray, out hit)) 
		{
			if (currentlySelected == null) {
				if (hit.collider.gameObject.tag == "Player") {
					currentlySelected = hit.collider.gameObject;
					currentlySelected.GetComponent<Cube> ().Selected = Instantiate (selectedPrefab, currentlySelected.transform.GetChild(0));
				} 
			} else {
				if (hit.collider.gameObject.tag == "Player") {
					currentlySelected = null;
					currentlySelected = hit.collider.gameObject;
					currentlySelected.GetComponent<Cube> ().Selected = Instantiate (selectedPrefab, currentlySelected.transform.GetChild (0));
				} else {
					currentlySelected = null;
					Destroy (select);
					Debug.Log (currentlySelected);
				}
			}
		}
	}
}
