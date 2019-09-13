using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;

public static class BatCs
{
    public static int Entry(string[] args)
    {
        foreach (var arg in args)
        {
            Console.WriteLine("Args: " + arg);
        }

        {
            var test = new LINQTest();
            test.Test();
        }
        
        {
            var test = new FILEIOTest();
            test.Test();
        }

        {
            Console.WriteLine("MessageBox Begin");
            var ret =  MessageBox.Show("メッセージ", "メッセージバー", MessageBoxButtons.YesNo);
            if (ret == DialogResult.Yes)
            {
                Console.WriteLine("Yes clicked");
            }
            if (ret == DialogResult.No)
            {
                Console.WriteLine("No clicked");
            }
            Console.WriteLine("MessageBox End");
        }

        return 0;
    }
}

public class LINQTest
{
    public void Test()
    {
        var list = new List<int> { 1, 84, 95, 95, 40, 6 };

        // list の最初の要素を取得する
        Console.WriteLine("First: " + list.First());

        // list の最後の要素を取得する
        Console.WriteLine("Last: " + list.Last());
    }
}

public class FILEIOTest
{
    public void Test()
    {
        PrintAllFiles();

        Write();
        Read();
        Delete();

        Regex();
    }

    private const string FILE_NAME = @"D:\test.txt";

    private void PrintAllFiles()
    {
        string path = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string[] files = System.IO.Directory.GetFiles(path, "*", System.IO.SearchOption.AllDirectories);
        foreach (var file in files)
        {
            Console.WriteLine("ファイル：" + file);
        }
    }

    private void Write()
    {
        using (System.IO.StreamWriter sw = System.IO.File.CreateText(FILE_NAME))
        {
            sw.WriteLine("aaa");
            sw.WriteLine("bbb");
            sw.WriteLine("ccc");
        }        
        
    }
    private void Read()
    {
        string s = "";
        using (System.IO.StreamReader sr = new System.IO.StreamReader(FILE_NAME, System.Text.Encoding.GetEncoding(932)))
        {
            s = sr.ReadToEnd();
        }

        Console.WriteLine(s);
    }

    private void Delete()
    {
        System.IO.File.Delete(FILE_NAME);
    }

    private void Regex()
    {
        string path = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string[] files = System.IO.Directory.GetFiles(path, "*", System.IO.SearchOption.AllDirectories);
        foreach (var file in files)
        {
            var mc = System.Text.RegularExpressions.Regex.Matches(file, @".*\.cs");
            foreach (System.Text.RegularExpressions.Match m in mc)
            {
                Console.WriteLine(m.Value);
            }
        }
    }
}