﻿using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace AoC15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program _instance = new Program();
            string input = "";
            string result = "";

            int day = 13;
            int part = 2;
            bool test = false;

            input = "./Input/day" + day.ToString() + "_1";
            input += (test) ? "_test.txt" : ".txt";

            Console.WriteLine("AoC 2015 - Day {0} , Part {1} - Test Data {2}", day, part, test);

            result = day switch
            {
                1 => _instance.Day1(input, part).ToString(),
                2 => _instance.Day2(input, part).ToString(),
                3 => _instance.Day3(input, part).ToString(),
                4 => _instance.Day4(input, part).ToString(),
                5 => _instance.Day5((part == 2 && test) ? "./Input/day5_2_test.txt" : input, part).ToString(),
                6 => _instance.Day6(input, part).ToString(),
                7 => _instance.Day7(input, part).ToString(),
                8 => _instance.Day8(input, part).ToString(),
                9 => _instance.Day9(input, part).ToString(),
                10 => _instance.Day10(input, part).ToString(),
                11 => _instance.Day11(input, part).ToString(),
                12 => _instance.Day12(input, part).ToString(),
                13 => _instance.Day13(input, part).ToString(),
                14 => _instance.Day14(input, part).ToString(),
                _ => throw new ArgumentException("Wrong day number - unimplemented"),
            };
            Console.WriteLine("Result : {0}", result);
            Console.ReadLine();
        }

        int Day1(string input, int part)
        {
            var lines = File.ReadLines(input).ToList();
            Day1.Elevator elevator =  new(lines[0]);

            return part == 1 ? elevator.FinalFloor : elevator.BasementEntry();
        }

        int Day2(string input, int part)
        {
            var lines = File.ReadLines(input).ToList();
            var boxes = lines.Select(x => new Day2.PresentBox(x)).ToList();

            return part == 1 ? boxes.Sum(x => x.WrapArea) : boxes.Sum(x => x.RibbonLength);
        }

        int Day3(string input, int part)
        {
            var lines = File.ReadLines(input).ToList();
            var routes = lines.Select(x => new Day3.PresentRoute(x, part)).ToList();

            return routes.Sum(x=>x.VisitedHouses);
        }

        int Day4(string input, int part)
        {
            var lines = File.ReadLines(input).ToList();
            var miner = new Day4.AdventCoinMiner(lines[0]);
            
            return miner.Mine(part);
        }

        int Day5(string input, int part)
        {
            var lines = File.ReadLines(input).ToList();
            var niceLines = lines.Select(x => new Day5.StringChecker(x, part).IsNice).ToList();
            return niceLines.Where(x => x == true).Count();
        }

        int Day6(string input, int part)
        {
            var lines = File.ReadLines(input).ToList();
            Day6.LightManager lightManager = new(part);

            foreach (var line in lines)
                lightManager.DoInstruction(line);

            return lightManager.CountLights();
        }

        int Day7(string input, int part)
        {
            var lines = File.ReadLines(input).ToList();

            Day7.CircuitManager cm = new(part);
            cm.BuildCircuit(lines);
            
            if(part ==1) 
                return cm.GetWireValue("a");

            // Functional version for part 2
            Day7.CircuitManagerFunctional cmf= new();
            cmf.BuildCircuit(lines);
            var signal = cmf.GetWireValue("a");
            
            
            cm.OverrideWire("b", AoC15.Day7.WireOperations.assign, signal, "", "");
            return cm.GetWireValue("a");
        }

        int Day8(string input, int part)
        {
            var lines = File.ReadLines(input).ToList();
            Day8.StringMemory stringMemo = new();
            int value = (part == 1) ? stringMemo.Process(lines)
                                    : stringMemo.ProcessP2(lines);
            return value;
        }

        int Day9(string input, int part)
        {
            var lines = File.ReadLines(input).ToList();
            var tp = new Day9.TripPlanner(lines);

            return tp.GetRoute(part);
        }

        int Day10(string input, int part)
        {
            var lines = File.ReadLines(input).ToList();
            var lookAndSay = new Day10.LookAndSay();


            return (part == 1) ? lookAndSay.PlayTimes(lines[0],40)
                               : lookAndSay.PlayTimes(lines[0],50);
        }

        string Day11(string input, int part)
        {
            var lines = File.ReadLines(input).ToList();
            Day11.PasswordGenerator pg = new();
            var firstPass = pg.FindNextPass(lines[0]);
            return (part == 1) ? firstPass
                               : pg.FindNextPass(firstPass);
        }

        int Day12(string input, int part)
        {
            var lines = File.ReadLines(input).ToList();
            Day12.JSONHelper jh = new();

            //return jh.GetSum(lines[0]);   // Part 1
            return jh.GetSumJson(lines[0], part);
        }

        int Day13(string input, int part)
        {
            var lines = File.ReadLines(input).ToList();
            Day13.DinnerTable dt = new(lines);
            if (part == 2)
                dt.AddMyself();
            return dt.GetHappiness(part);
        }
        int Day14(string input, int part)
        {
            var lines = File.ReadLines(input).ToList();
            return 0;
        }

    }
}