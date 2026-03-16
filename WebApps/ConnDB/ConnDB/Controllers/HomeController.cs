using CsvHelper;

using ExcelToDatabaseAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Text;
using ExcelToDatabaseAPI.Context;
using Microsoft.EntityFrameworkCore;
using Azure.Messaging;


namespace ExcelToDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        

        [HttpGet("readcsv")]
        public IActionResult ReadCsv()
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "example.csv");

            if (!System.IO.File.Exists(filepath))
            {
                return NotFound();
            }

            using var reader = new StreamReader(filepath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<StudentCsv>().ToList();
            foreach (var student in records)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
            }

            return Ok(records);


        }
        [HttpGet("exportcsv")]
        public IActionResult WriteCsv()
        {
            var students = StudentDb.Instance.Students;
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "exported_students.csv");
            using var writer = new StreamWriter(filepath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(students);
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
            }

            return Ok(new { Message = "CSV file exported successfully.", FilePath = filepath, students });




        }
        [HttpDelete("deletestud/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = StudentDb.Instance.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound(new { Message = "Student not found." });
            }
            StudentDb.Instance.Students.Remove(student);
            return Ok(new { Message = "Student deleted successfully.", DeletedStudent = student });
        }
        [HttpGet("studpdf")]
        public IActionResult GetStudentsPdf()
        {
            var students = StudentDb.Instance.Students;
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "students.pdf");

            using (var pdfWriter = new StreamWriter(filepath))
            {
                pdfWriter.WriteLine("Student List");
                pdfWriter.WriteLine("============");
                foreach (var student in students)
                {
                    pdfWriter.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
                }
            }
            return Ok(new { Message = "PDF file generated successfully.", FilePath = filepath, students });
        }
        
    }
}
