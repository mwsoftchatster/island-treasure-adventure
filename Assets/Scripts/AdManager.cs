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
using admob;

public class AdManager : MonoBehaviour {

    public AdManager Instance { set; get; }

    public string bannerId;

    public string videoId;

    public void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

#if UNITY_EDITOR
#elif UNITY_ANDROID
        Admob.Instance().initAdmob(bannerId, videoId);
        Admob.Instance().loadInterstitial();
#endif
    }

    public void Start()
    {
        #if UNITY_EDITOR
        #elif UNITY_ANDROID
                        if (Admob.Instance().isInterstitialReady())
                        {
                            Admob.Instance().showInterstitial();
                        }
        #endif
    }
}
