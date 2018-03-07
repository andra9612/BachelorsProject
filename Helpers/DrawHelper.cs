using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHelper {
	public static Rect GetRectangle( Vector3 screenPosition1, Vector3 screenPosition2 )
	{
		screenPosition1.y = Screen.height - screenPosition1.y;
		screenPosition2.y = Screen.height - screenPosition2.y;
		var topLeft = Vector3.Min( screenPosition1, screenPosition2 );
		var bottomRight = Vector3.Max( screenPosition1, screenPosition2 );
		return Rect.MinMaxRect( topLeft.x, topLeft.y, bottomRight.x, bottomRight.y );
	}

	public static Bounds GetBounds( Camera camera, Vector3 screenPosition1, Vector3 screenPosition2 )
	{
		Vector3 v1 = camera.ScreenToViewportPoint( screenPosition1 );
		Vector3 v2 = camera.ScreenToViewportPoint( screenPosition2 );
		Vector3 min = Vector3.Min( v1, v2 );
		Vector3 max = Vector3.Max( v1, v2 );
		min.z = camera.nearClipPlane;
		max.z = camera.farClipPlane;

		Bounds bounds = new Bounds();
		bounds.SetMinMax( min, max );
		return bounds;
	}
		
}
