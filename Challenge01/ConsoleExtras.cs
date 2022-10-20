// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

namespace Challenge01;

public static class ConsoleExtras {
  public static void WriteSuccess(string message) {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(message);
    Console.ResetColor();
  }

  public static void WriteWarning(string message) {
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(message);
    Console.ResetColor();
  }

  public static void WriteError(string message) {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
  }

  public static void WritePerson(object person) {
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(person);
    Console.ResetColor();
  }

  public static void WriteStudent(object student) {
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(student);
    Console.ResetColor();
  }

  public static void WriteExit() {
    Console.Write("\nPressione qualquer tecla para sair...");
    Console.ReadKey(true);
  }
}
