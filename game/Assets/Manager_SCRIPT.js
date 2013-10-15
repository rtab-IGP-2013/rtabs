#pragma strict

var player : GameObject;
var start_marker : Transform;
var start_position : Vector3;

function Start () {
	start_position = start_marker.position;
	Instantiate(player, start_position, Quaternion.identity);
}

function Update () {

}