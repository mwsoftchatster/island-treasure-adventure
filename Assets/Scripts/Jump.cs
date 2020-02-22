/*
  Copyright (C) 2016 - 2020 MWSOFT
  This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.
  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.
  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    public float jumpSpeed = 340f;
    public float forwardSpeed = 20f;

    private Rigidbody2D body2d;
    private InputState inputState;
    public AudioClip jumpSound;

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
        inputState = GetComponent<InputState>();
    }

	
	// Update is called once per frame
	void Update () {
        if (inputState.standing)
        {
            if (inputState.actionButton) {
                body2d.velocity = new Vector2(transform.position.x < 0 ? forwardSpeed : 0,jumpSpeed);
                if (PlayerPrefs.GetString("SoundOnOff").Equals("On"))
                {
                    GetComponent<AudioSource>().PlayOneShot(jumpSound);
                }
                
            }
            
        }
	}
}
