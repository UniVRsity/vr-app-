echo off
title Sign In to AltspaceVR
curl -v -d "user[email]=nicolas.barone@univrsitytech.com&user[password]=070498nb" https://account.altvr.com/users/sign_in.json -c cookie
