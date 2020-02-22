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

public class GameAdManager : MonoBehaviour
{

    public GameAdManager Instance { set; get; }

    public string bannerId;

    public string videoId;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Admob.Instance().initAdmob(bannerId, videoId);
        
    }

    public void ShowBanner()
    {
        #if UNITY_EDITOR
        #elif UNITY_ANDROID
               Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 5);
        #endif
    }

    public void HideBanner()
    {
        #if UNITY_EDITOR
        #elif UNITY_ANDROID
                       Admob.Instance().removeBanner();
        #endif

    }


}

