echo off
curl -v -b cookie -X PUT -F "kit[zip]=@C:\Users\Nicolas\Desktop\VR Projects\vr-app-\Info Session\1561832827287240937_test-folder.zip" -F "kit[game_engine_version]=20194" https://account.altvr.com/api/kits/1561832827287240937.json
