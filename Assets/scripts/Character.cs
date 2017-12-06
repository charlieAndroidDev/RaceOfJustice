using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public GameObject _character;
	private float _maxAcceleration = 3f;
	private float _maxDecceleration = 5f;
	private float _maxSpeed = 10f;
	private float _minSpeed = 0f;
	private float _currentSpeed;

	// Use this for initialization
	void Start () {
		_character = GameObject.Find("Car10");
	}
	
	// Update is called once per frame
	void Update ()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Time.deltaTime * _currentSpeed;

		if (Input.GetKey(KeyCode.W))
		{
			if (!(_currentSpeed > _maxSpeed))
			{
				_currentSpeed += _maxAcceleration * Time.deltaTime;	
			}
			if (_currentSpeed < 0f)
			{
				_currentSpeed += _maxDecceleration * Time.deltaTime;
			}
		} 
		else if (Input.GetKey(KeyCode.S))
		{
			if (!(_currentSpeed < _minSpeed))
			{
				_currentSpeed -= _maxDecceleration * Time.deltaTime;
			}
			else
			{
				_currentSpeed -= _maxAcceleration * Time.deltaTime;
			}	
		}
		else
		{
			if (!(_currentSpeed < _minSpeed))
			{
				_currentSpeed -= _maxAcceleration * Time.deltaTime;	
			}
		}
		
		_character.transform.Rotate(0, x, 0);
		_character.transform.Translate(0, 0, z);
	}
}
