echo ontitle AltspaceVR Kits

curl -v -b cookie https://account.altvr.com/api/kits/my.json -o page1-kits.json
curl -v -b cookie https://account.altvr.com/api/kits/my.json?page=2 -o page2-kits.json
