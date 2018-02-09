# ChangeRegResolution

##構文
ChangeRegResolution /c
ChangeRegResolution /s <ハードウェアID> /x <解像度(横)> /y <解像度(縦)>

####最初に、
---
```
ChangeRegResolution /c
```
を実行すると、↓のようなメッセージが確認できるので、
```
MONITOR\SHP1412
```
「\」より右側の文字をハードウェアIDとしてメモしておく。


####次に、
---
```
ChangeRegResolution /s <前手順で確認したハードウェアID> /x <解像度(横)> /y <解像度(縦)>
```
を実行して、解像度設定を変更する。

例)
```
ChangeRegResolution /s SHP1412 /x 2560 /y 1440
```

####それから
---
ログオフ/再ログオン
or
再起動

解像度が変わっていたら成功。
