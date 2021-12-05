// See https://aka.ms/new-console-template for more information

using System;
using DayOne.solvers;
using FileLoader;

var input = FileReader.ReadFileToIntCollection(@"../../../2021input.txt");
DayOneSonarSweep solver = new(3);
var solution = solver.Solve(input);

Console.WriteLine(solution);