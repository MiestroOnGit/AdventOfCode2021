// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using DayThree;
using FileLoader;

IEnumerable<string> input = FileReader.ReadFileNameToCollection<string>(@"input.txt");

//Assuming all the binary strings are the same length
GammaSolver solver = new(input, input.ElementAt(0).Length);

ulong solution = solver.solve();

Console.WriteLine(solution);