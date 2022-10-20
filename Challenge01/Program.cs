// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

namespace Challenge01;

internal class Program {
  private static string[ ] _lines = Array.Empty<string>();
  private static readonly string _filePath = Path.Join(AppContext.BaseDirectory, "dados.txt");

  private static readonly Uri _fileUri =
    new(
      "https://raw.githubusercontent.com/alexandrezamberlan/academiaDotNet_3/main/2%20-%20exerciciosDesafios/10_TXTdesafio10_Arquivo.txt");

  private static readonly List<Person> _persons = new();

  public static void Main() {
    Console.WriteLine("--- DESAFIO 01 ---\n");

    readFile();
    preparePersons();
    showData();

    ConsoleExtras.WriteExit();
  }

  private static void showData() {
    ConsoleExtras.WriteWarning("Mostrando os dados coletados [Azul = Pessoa; Ciano = Estudante]...\n");

    _persons.ForEach(person => {
      if (person.GetType().IsAssignableTo(typeof(Student))) {
        ConsoleExtras.WriteStudent(person);
      }
      else {
        ConsoleExtras.WritePerson(person);
      }
    });

    ConsoleExtras.WriteSuccess("Finalizado...");
  }

  private static void preparePersons() {
    ConsoleExtras.WriteWarning("Preparando os dados...");

    string? current;
    string? next;

    foreach (var line in _lines) {
      var index = Array.IndexOf(_lines, line);
      var length = _lines.Length;

      current = line;

      if (current.StartsWith("Y")) {
        continue;
      }

      if (length - index <= 1) {
        if (current.StartsWith("Z")) {
          var personData = current.Split('-').Skip(1).ToArray();
          var person = new Person(personData[0], personData[1], personData[2], personData[3], personData[4]);

          _persons.Add(person);
        }

        continue;
      }

      next = _lines[index + 1];

      if (current.StartsWith("Z") && next.StartsWith("Y")) {
        var personData = current.Split('-').Skip(1).ToArray();
        var studentData = next.Split('-').Skip(1).ToArray();

        var person = new Person(personData[0], personData[1], personData[2], personData[3], personData[4]);
        var student = new Student(person, studentData[0], studentData[1], studentData[2]);

        _persons.Add(student);
      }

      if (current.StartsWith("Z") && next.StartsWith("Z")) {
        var personData = current.Split('-').Skip(1).ToArray();
        var person = new Person(personData[0], personData[1], personData[2], personData[3], personData[4]);

        _persons.Add(person);
      }

      current = null;
      next = null;
    }

    var totalStudents = _persons.Count(x => x.GetType().IsAssignableTo(typeof(Student)));

    Console.WriteLine($"Total de pessoas: {_persons.Count - totalStudents}");
    Console.WriteLine($"Total de estudantes: {totalStudents}");
    ConsoleExtras.WriteSuccess("Finalizado...");
  }

  private static void readFile() {
    var path = _filePath.Remove(0, AppContext.BaseDirectory.Length);

    ConsoleExtras.WriteWarning($"Lendo os dados localizados em '{path}'");

    try {
      if (!File.Exists(_filePath)) {
        ConsoleExtras.WriteWarning($"O arquivo '{path}' não encontrado... Baixando do GitHub...");

        using var httpClient = new HttpClient();
        var result = httpClient.GetAsync(_fileUri).GetAwaiter().GetResult();
        var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        using var streamWriter = new StreamWriter(_filePath);
        streamWriter.Write(content);
        streamWriter.Close();
      }

      using var streamReader = new StreamReader(_filePath);

      _lines = streamReader
        .ReadToEnd()
        .Split(new[ ] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
        .Skip(1)
        .Where(x => !string.IsNullOrWhiteSpace(x))
        .ToArray();

      streamReader.Close();

      ConsoleExtras.WriteSuccess("Finalizado...");
    }
    catch (Exception e) {
      ConsoleExtras.WriteError(e.Message);
    }
  }
}
