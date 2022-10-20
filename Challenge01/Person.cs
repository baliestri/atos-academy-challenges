// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using System.Text;

namespace Challenge01;

public class Person {
  public Person() { }

  public Person(string name, string phoneNumber, string city, string rg, string cpf)
    => (Name, PhoneNumber, City, Rg, Cpf) = (name, phoneNumber, city, rg, cpf);

  public Person(Person person) : this(person.Name, person.PhoneNumber, person.City, person.Rg, person.Cpf) { }

  public string Name { get; init; } = default!;
  public string PhoneNumber { get; init; } = default!;
  public string City { get; init; } = default!;
  public string Rg { get; init; } = default!;
  public string Cpf { get; init; } = default!;

  public override string ToString()
    => new StringBuilder()
      .AppendLine("{")
      .AppendLine($"\tNome: {Name}, Telefone: {PhoneNumber}, Cidade: {City},")
      .AppendLine($"\tRG: {Rg}, CPF: {Cpf}")
      .AppendLine("}")
      .ToString();
}
