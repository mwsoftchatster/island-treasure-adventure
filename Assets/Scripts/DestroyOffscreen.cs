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

public class DestroyOffscreen : MonoBehaviour {

	public float offset = 16f;
	public delegate void OnDestroy();
	public event OnDestroy DestroyCallback;


	private bool offscreen;
	private float offscreenX = 0;
	private Rigidbody2D body2d;
    private PixelPerfectCamera pixelPerfectCamera;

    void Awake(){
		body2d = GetComponent<Rigidbody2D> ();
        pixelPerfectCamera = GameObject.Find("Main Camera").GetComponent<PixelPerfectCamera>();
    }

	// Use this for initialization
	void Start () {
		offscreenX = (Screen.width / pixelPerfectCamera.pixelsToUnits) / 2 + offset;
	}
	
	// Update is called once per frame
	void Update () {

		var posX = transform.position.x;
		var dirX = body2d.velocity.x;

		if (Mathf.Abs (posX) > offscreenX) {

			if (dirX < 0 && posX < -offscreenX) {
				offscreen = true;
			} else if (dirX > 0 && posX > offscreenX) {
				offscreen = true;
			}

		} else {
			offscreen = false;
		}

		if (offscreen) {
			OnOutOfBounds();
		}

	}

	public void OnOutOfBounds(){
		offscreen = false;
        GameObjectUtil gameObjectUtil = new GameObjectUtil();

        gameObjectUtil.Destroy (gameObject);

		if (DestroyCallback != null) {
			DestroyCallback();
		}
	}
}
