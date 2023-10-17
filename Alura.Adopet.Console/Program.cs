﻿using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Controls;
using System.Windows.Input;

SystemCommands comandos = new();

Console.ForegroundColor = ConsoleColor.Green;
try
{
    string comando = args[0].Trim();
    IControll? cmd = comandos[comando];
    if (cmd is not null) await cmd.ExecuteAsync(args);
    else Console.WriteLine("Comando inválido!");
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}