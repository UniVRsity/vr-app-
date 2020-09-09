echo off
curl -v -b cookie -X PUT -F "kit[zip]=@C:\Users\Nicolas\Desktop\VR Projects\vr-app-\Uploader Test\1457438402138865951_tingle.zip" -F "kit[game_engine_version]=20194" https://account.altvr.com/api/kits/1457438402138865951.json
