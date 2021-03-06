**UIGenerator** はFunny_Silkieによって開発されたAltseed1対応のUI制作補助ツールです

[ダウンロードはこちらから](https://drive.google.com/drive/folders/1xd2uPFpxAVmuKH_G-gvwP8y4MBraGvNa?usp=sharing)  

# UIGeneratorの目的
ゲームでUIを作る時，文字やウィンドウの位置関係や色などは微調整する必要があります。  
しかし，C#等の言語では確認するためにはコンパイルしなおさなくてはなりません。  
それはとてもめんどくさいので，実際にどんな状態になっているかを確認しながらUIの情報を設定する事が出来るこのアプリケーションを制作しました。

# 機能
## ウィンドウ
アプリケーションを立ち上げると，

- コンソールウィンドウ
- メインウィンドウ
- Altseedのウィンドウ

の3つのウィンドウが立ち上がります。  
コンソールウィンドウでは処理の成否などのログが表示されます。  
Altseedウィンドウではこのアプリケーションで編集できるUIのオブジェクトが表示されます。  
メインウィンドウではこのアプリケーションで管理されているUIオブジェクトが表示されており，様々な機能を使用する事が出来ます。
(詳しくは次の項を参照)

## メインウィンドウ
メインウィンドウでは主に3つの機能があります。  
1つめの機能は，様々な機能を持つウィンドウの表示です。  
メニューの"編集"からはUIオブジェクトの追加/削除，フォントの追加/削除，テクスチャの追加/削除，ファイルパッケージの追加/削除に使用するウィンドウを開く事が出来ます。  
2つめの機能は，UIオブジェクトの編集です。  
追加されたUIオブジェクトはここから編集する事が出来ます。  
3つめの機能は，表示モードの変更です。  
このUIGeneratorでは，表示モードというものが設定されています。  
表示モードはそれぞれのUIオブジェクトに割り当てられており，このメインウィンドウで指定された表示モードを持つ要素だけが描画されるというものです。  

## UIオブジェクトの使用
UIオブジェクトは主に`asd.Object2D`から派生したオブジェクトとしての物と，`asd.Layer2D`から呼び出せるDraw○○Additionallyメソッドとして追加描画の2つに分かれます。  
オブジェクトはText，Texture，Windowの3つに分かれています。  
Textでは`asd.TextObject2D`を継承したオブジェクトを扱います。  
Textureでは`asd.TextureObject2D`を継承したオブジェクトを扱います。  
Windowも`asd.TextureObject2D`を継承したものですが，枠線の表示の有無などの独自の設定が出来ます。  

追加描画はArc，Circle，Line，Rectangle，RotatedRectangle．Sprite，Text，Triangleを使用する事が出来ます。  
それぞれ`asd.Layer2D`から呼び出せる追加描画メソッドの物と同じです。  

オブジェクトには表示モードと名前を割り振る必要があります。  
表示モードと名前の組み合わせは一意にする必要があり，重複させることはできません。  
オブジェクト情報の編集は，追加した後にメインウィンドウのリストの，編集したいオブジェクトの部分をダブルクリックすれば行う事が出来ます。  

## フォント
フォントはフォントファイルから動的に生成するフォントと.affファイルから生成するもの両方使用することができます。  
読み込んだフォントはUIオブジェクトのテキスト系に使用する事が出来ます。  
フォントはデフォルトの物が既に登録されおり，削除することは出来ません。

## テクスチャ
テクスチャも読み込むことが出来，テクスチャオブジェクトや追加描画で使用する事が出来ます。  
テクスチャにもフォント同様デフォルトの物が有ります。

## ファイルパッケージ
ファイルパッケージも登録する事が出来ます。  
Altseedの仕様上，読み込み時にパスワードを間違えたりしていると，エラーウィンドウが出てきます。  
その時はエラーウィンドウが消えるまで"無視"を押してください。  
続行を押すとアプリケーションが強制終了する恐れがあります。
ファイルパッケージ内へのファイルパスの存在を確認したいときは，メインウィンドウのツールからファイルパス検証ツールがあるのでそちらをご利用ください。  
デフォルトのフォントとテクスチャは`DefaultResource.pack`に格納されているため，適宜読み込んで使用ください。  
パスワードかかっていません。

## Altseedウィンドウのオプション
メインウィンドウのツールからオプションを開く事が出来ます。  
Altseedウィンドウのサイズはデフォルトでは640×480ですが，ここで変更する事が出来ます。  
また，プロジェクト名も変更する事が出来ます。  

## プロジェクトファイル
プロジェクトファイルはメインウィンドウのファイルメニューから保存及び読み込みをする事が出来ます。  
プロジェクトファイルは`.ugpf`拡張子を持ちます。  
読み込み時はインスタンス生成時に保管されたファイルパスから再読み込みを行います。  
正常な読み込みをするには後述のリソースファイルも生成してそちらを先に読み込んでおくことをお勧めします。  
メニューから新規作成を選んだ時は**警告なしに**全ての情報がリセットされるため，ご注意ください。

## リソースファイル
登録したリソースは一つのファイルにまとめて保管する事が出来ます。  
ファイルデータごと全て保管するため，ファイルサイズは大きくなります。  
拡張子は`.ugrpf`です。  

## エクスポート
メニューのエクスポートからエクスポート画面を表示する事が出来ます。  
エクスポート画面では名前空間や生成されるレイヤーの名前を設定する事が出来ます。  
ファイルパスを指定してエクスポートボタンを押すとC#コードがエクスポートされます。  
C++やJavaのコード生成関連は好事家に投げます。  

## エクスポート後
Altseed.dll，fslib.dll，UIGeneratorObjects.dllをプロジェクトの参照に加え，エクスポートされたcsファイルを"既存の要素を追加する"で追加してください。  
エクスポート後のレイヤーは`UIGeneratorObjects.UILayer`を継承しています。  
その主要メソッドは以下の通りです。

|メソッド名|効果|
|:---:|:--|
|AddUIObject|UIオブジェクトを表示モード管理に加える|
|ChangeMode|表示モードを変更する|
|ContainsUIObject|UIオブジェクトの有無を取得する|
|RemoveUIObject|UIオブジェクトの管理を解除する|

`asd.Layer2D.AddObject`等のメソッドでは表示モード管理には入れられないため，`AddUIObject`メソッドで追加して下さい。  

# 最後に
Altseed2がそろそろできると思うんであんま使うことないと思いますがよろしければどうぞ。  
作者を偽らなければ配布などご自由に行って結構です。  
但し配布の場合は無料に限ります。  
このソフトウェアによってもたらされたあらゆる不利益に関して製作者は一切の責任を負いませんので，ご了承ください。  
バグや要望などは必ずではありませんが，対応はしていくつもりです。

## 作者Link
- [Twitter](https://twitter.com/Funny_Silkie)
- [Github](https://github.com/Funny-Silkie)

## その他Link
- [Altseed](https://altseed.github.io/)
- [AmusementCreators](https://www.amusement-creators.info/)
- [ダウンロードはこちらから](https://drive.google.com/drive/folders/1xd2uPFpxAVmuKH_G-gvwP8y4MBraGvNa?usp=sharing)  