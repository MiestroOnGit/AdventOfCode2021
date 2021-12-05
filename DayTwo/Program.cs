// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using DayOne.solvers.DayTwo;
using FileLoader;

IEnumerable<string> input = FileReader.ReadFileToCollection<string>(@"../../../input.txt");

DiveSolver diveSolver = new(false);
var enumerable = input as string[] ?? input.ToArray();
int solution = diveSolver.solve(enumerable);

Console.WriteLine($"part one solution: {solution}");

DiveSolver partTwoDiveSolver = new(true);
int solutionTwo = partTwoDiveSolver.solve(enumerable);

Console.WriteLine($"part two solution: {solutionTwo}");