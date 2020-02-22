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

public class AnimatedTexture : MonoBehaviour {

    public Vector2 speed = Vector2.zero;
    private Vector2 offset = Vector2.zero;
    private Material material;
    public Material newMaterialRef;
    private Renderer render;

    void Awake()
    {
        if (PlayerPrefs.GetString("WorldChoice").Equals("Jungle"))
        {
            render = GetComponent<Renderer>();
            render.material = newMaterialRef;
        }
        
    }

    // Use this for initialization
    void Start () {

        material = GetComponent<Renderer>().material;

        offset = material.GetTextureOffset("_MainTex");
	
	}
	
	// Update is called once per frame
	void Update () {
        //deltaTime represents the difference in time between one frame rendering to the next, this is used because the game may not always run at 60fps
        //it is not ok to assume that we can simply add speed and it will be added the same way every single frame
        //so when you use deltaTime speed will be consistant
        offset += speed * Time.deltaTime;

        material.SetTextureOffset("_MainTex", offset);
	
	}
}
