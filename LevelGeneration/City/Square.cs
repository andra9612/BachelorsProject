using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Prefab{
	House,
	Tree,
	Streat,
	Wasteland
}

public enum Direction{
	Up,
	Right,
	Down,
	Left,
	None
}

public class Square{
	private int _streatIndex;
	private Prefab _prefab;
	private Direction _direction;

	public Square(int streatNumber, Prefab objectPrefab,Direction direction){
		StreatIndex = streatNumber;
		CurentPrefab = objectPrefab;
		CurrentDirection = direction;
	}

	public Square(){
		StreatIndex = 0;
		CurentPrefab = Prefab.Wasteland;
		CurrentDirection = Direction.None;
	}

	public int StreatIndex{ get; set; }
	public Prefab CurentPrefab{ get;set;}
	public Direction CurrentDirection{ get;set;}

}
