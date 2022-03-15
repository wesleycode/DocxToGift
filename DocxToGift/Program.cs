using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocxToGift.bo;
using DocxToGift.model;
using DocxToGift.utils;
using System.Text;
using System.Text.RegularExpressions;

var showTextQuestions = false;
var listaDeArquivos = GetNamesFromAllFilesInLocation();
var prefixo = "";

// Run Application //
ShowWarningsAboutAssertiveQuestions();
InitializeApplication();
GetPrefixOfQuestions();
ConvertQuestionsToGiftFormat();
FinalizeApplication();

void InitializeApplication()
{
    Console.WriteLine("[Core] > Initializing Application...");
    ChangeColorOfConsole(ConsoleColor.Green);
    Console.WriteLine("[Core] > Converting questions to GIFT format...");
    Console.WriteLine("[Core] > Number of files to read: " + listaDeArquivos.Count);
    ChangeColorOfConsole(ConsoleColor.White);
}

void ConvertQuestionsToGiftFormat()
{
    for (var x = 0 ; x < listaDeArquivos.Count; x++)
    {
        var texto = new GerenciadorDeArquivosDeTexto().LerDeArquivoDeTexto(listaDeArquivos[x]);
        List<Questao> questoes = new QuestoesBO().ConverterListaDeLinhasEmListaDeQuestao(texto);
        List<Questao> questoesFormatadas = new QuestoesBO().FormatarListaDeQuestoes(questoes);
        string questoesEmFormatoGift = new GerenciadorDeQuestoesGift().ConverterListaDeQuestoesFormatoGIFT(questoesFormatadas, prefixo);
        if (showTextQuestions)
        {
            ChangeColorOfConsole(ConsoleColor.Red);
            Console.WriteLine(questoesEmFormatoGift);
            ChangeColorOfConsole(ConsoleColor.White);
        }
        new GerenciadorDeArquivosDeTexto().GravarEmArquivoDeTexto(texto: questoesEmFormatoGift, arquivo: CreateNewFileName(listaDeArquivos[x]), encoding: Encoding.UTF8, append: false);
    }
}

void FinalizeApplication()
{
    ChangeColorOfConsole(ConsoleColor.Green);
    Console.WriteLine("[Core] > All files created with success...");
    ChangeColorOfConsole(ConsoleColor.White);
    Console.WriteLine("[Core] > Finalizing Application...");
    Console.ReadLine();
}

void ChangeColorOfConsole(ConsoleColor color)
{
    Console.ForegroundColor = color;
}

void ShowWarningsAboutAssertiveQuestions()
{
    ChangeColorOfConsole(ConsoleColor.Red);
    Console.WriteLine("** Remember to put '-' char before the assertive questions secondary strings **");
    Console.WriteLine("** And 'ENTER' chars to separate every question **");
    Console.WriteLine("** Put '-h' or '--help' to see more info ** \n");
    ChangeColorOfConsole(ConsoleColor.White);
}

void GetPrefixOfQuestions()
{
    Console.WriteLine("[Core] > Digit the prefix for questions... Example: DC3-A3-");
    prefixo = Console.ReadLine();
}

string CreateNewFileName(string oldFileName)
{
    return Regex.Replace(oldFileName, ".txt", "_formatted") + ".txt";
}

List<string> GetNamesFromAllFilesInLocation()
{
    return Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt").ToList();
}