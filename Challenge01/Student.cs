// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using System.Text;

namespace Challenge01;

public class Student : Person {
  public Student() { }

  public Student(string name, string phoneNumber, string city, string rg, string cpf, string enrollment,
    string courseCode, string courseName) : base(name, phoneNumber, city, rg, cpf)
    => (Enrollment, CourseCode, CourseName) = (enrollment, courseCode, courseName);

  public Student(string name, string phoneNumber, string city, string rg, string cpf, Student student)
    : base(name, phoneNumber, city, rg, cpf)
    => (Enrollment, CourseCode, CourseName) = (student.Enrollment, student.CourseCode, student.CourseName);

  public Student(Person person, string enrollment, string courseCode, string courseName) : base(person)
    => (Enrollment, CourseCode, CourseName) = (enrollment, courseCode, courseName);

  public Student(Person person, Student student) : base(person)
    => (Enrollment, CourseCode, CourseName) = (student.Enrollment, student.CourseCode, student.CourseName);

  public string Enrollment { get; init; } = default!;
  public string CourseCode { get; init; } = default!;
  public string CourseName { get; init; } = default!;

  public override string ToString()
    => new StringBuilder()
      .AppendLine("{")
      .AppendLine($"\tNome: {Name}, Telefone: {PhoneNumber}, Cidade: {City},")
      .AppendLine($"\tRG: {Rg}, CPF: {Cpf}, Matrícula: {Enrollment},")
      .AppendLine($"\tCódigo do curso: {CourseCode}, Nome do curso: {CourseName}")
      .AppendLine("}")
      .ToString();
}
