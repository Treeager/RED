﻿using System.ComponentModel;
using System.IO.Compression;
using System.Linq.Expressions;
using System;
using System.Xml;

namespace Rot{
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Type 'e' for encrypt, 'd for decrypt or 'dnk' for decrypt no key.\nUse 'b' for break (exit).\n");

        // The main loop of the app
        while (true){
            int ROT;
            
            Console.Write("Mode: ");
            
            string mode = Console.ReadLine() ?? "";
            string fraze = "";

            Console.WriteLine();
            if (mode != "b") {
                Console.Write("Phraze: ");
                fraze = Console.ReadLine() ?? "";
            }
            else Environment.Exit(0);
            

            if (mode == "dnk") {
                Console.WriteLine(DecryptNoKey(fraze));
                continue;
            }
            
            ROT = GetRot();

            // TODO: find better way of asking for rot
            if (mode == "e") {
                Console.WriteLine("\nEncrypted: " + Encrypt(fraze, ROT));
            }
            else if (mode == "d") {
                Console.WriteLine("\nDecrypted: " + Decrypt(fraze, ROT));
            }
            else if (fraze == "") {
                Console.WriteLine("\n\nNo input.");
            }
        }
    }

    static int GetRot() {
        Console.Write("ROT: ");
        return Convert.ToInt32( Console.ReadLine() );
    }
    
    static string Encrypt(string fraze, int ROT) {
        string output = "";
        int letter;
        fraze = fraze.ToLower();

        foreach(char ch in fraze) {
            letter = Convert.ToInt32 (ch ) - 96;

            if (ch == ' ') {
                output += ' ';
                continue;
            }

            if ( letter + ROT > 26 ) {
                output += (char) ((int) (( letter + ROT ) % 26 ) + 96 );
            }
            else {
                output += (char) ( (int) ch + ROT );
            }
        }

        return output;
    }
    static string Decrypt(string fraze, int ROT) {
        string output = ""; int letter; 
        fraze = fraze.ToLower();

        foreach(char ch in fraze) {
            letter = (int) ch - 96;

            if (ch == ' ') {
                output += ' ';
                continue;
            }

            if (letter - ROT == 0) {
                output += 'z';
            }
            else if ( letter - ROT < 0 ) {
                output += (char) ( letter - ROT + 26 + 96 ) ;
            }
            else {
                output += (char) (ch - ROT);
            }
        }

        return output;
    }
    static string DecryptNoKey(string fraze) {
        string output = "";
        for (int rot = 1; rot <= 26; rot++) {
            output += $"Rot{rot}: {Decrypt(fraze, rot)} \n";
        }
        
        return output;
    }
}
}