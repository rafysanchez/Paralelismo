﻿using System.Diagnostics;
using Paralelismo;
using Paralelismo.Models;

string[] ceps = new string[5];
ceps[0] = "07155081";
ceps[1] = "15800100";
ceps[2] = "38407369";
ceps[3] = "77445100";
ceps[4] = "78015818";

var parallelOptions = new ParallelOptions();
parallelOptions.MaxDegreeOfParallelism = 8;

var stopWatch = new Stopwatch();

stopWatch.Start();
var listaCep = new List<CepModel>();

Parallel.ForEach(ceps, parallelOptions, cep =>
{
    listaCep.Add(new ViaCepService().GetCep(cep) );
   Console.WriteLine(new ViaCepService().GetCep(cep) + $" Thread: {Thread.CurrentThread.ManagedThreadId.ToString()}");
});

// foreach(var cep in ceps)
// {
//     listaCep.Add(new ViaCepService().GetCep(cep));
// }
stopWatch.Stop();

Console.WriteLine($"O Tempo de processamento total é de {stopWatch.ElapsedMilliseconds} ms");

// listaCep.ToList().ForEach(cep => Console.WriteLine(cep));




