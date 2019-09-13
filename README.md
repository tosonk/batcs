BatCs 
===================================================


Overview
--------

コンパイル（VSなどの開発環境）なしにC#を実行できるツール
参考URL https://qiita.com/cat2151/items/0f60bb6ab0ca811346d1#_reference-d29205d619ae29fd528b

batcsディレクトリだけコピーすればどこでもC#が実行できます。

HowToUse
--------

```
batcs\batcs.bat 実行したいファイル.cs csに渡す引数1 csに渡す引数2 ...
```

- csに渡す引数は文字列扱いされるので必要ならparseしてください
- sample.batを参考にしてください


Attention
--------

- 複数csの利用、外部DLLのリンク、IDEによるデバッグなどには未対応

