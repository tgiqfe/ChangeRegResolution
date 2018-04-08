# ChangeRegResolution

<br>
↓次バージョン作成中。<br>
https://github.com/tgiqfe/RizoChange2<br>
多分今度はもっと使いやすくなります。<br>
<br>
<br>

## 構文
ChangeRegResolution /c<br>
ChangeRegResolution /s <ハードウェアID> /x <解像度(横)> /y <解像度(縦)>
<br>
<br>

#### 最初に、
---
管理者として実行して、
```
ChangeRegResolution /c
```
を実行すると、↓のようなメッセージが確認できるので、
```
MONITOR\SHP1412
```
「\」より右側の文字をハードウェアIDとしてメモしておく。
<br>
<br>

#### 次に、
---
管理者として実行して、
```
ChangeRegResolution /s <前手順で確認したハードウェアID> /x <解像度(横)> /y <解像度(縦)>
```
を実行して、解像度設定を変更する。

例)
```
ChangeRegResolution /s SHP1412 /x 2560 /y 1440
```
<br>

#### それから
---
ログオフ/再ログオン
or
再起動
<br>
<br>

解像度が変わっていたら成功。
<br>
<br>

#### その他
---
```
ChangeRegResolution /s <前手順で確認したハードウェアID> /x <解像度(横)> /y <解像度(縦)> /n <ディスプレイ番号>
```
で、特定の番号のディスプレイにのみ解像度設定をすることも可能です。<br>
ディスプレイ番号は、大抵、00、01、02、03・・・<br>
になります。<br>
※/n 指定がない場合、全ディスプレイに解像度設定が適用<br>
