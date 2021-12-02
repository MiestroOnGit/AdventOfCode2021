// See https://aka.ms/new-console-template for more information

using System;
using adventOfCode2021.solvers;
using adventOfCode2021.Utils;

var input = FileReader.ReadFileToIntCollection(@"..\..\..\2021input.txt");
DayOneSonarSweep solver = new(3);
var solution = solver.Solve(input);

Console.WriteLine(solution);