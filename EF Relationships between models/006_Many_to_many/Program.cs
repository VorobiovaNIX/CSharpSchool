using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _006_Many_to_many
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (Context db = new Context())
            {
                Student s1 = new Student { Name = "Tom" };
                Student s2 = new Student { Name = "Alice" };
                Student s3 = new Student { Name = "Bob" };
                db.Students.AddRange(new List<Student> { s1, s2, s3 });

                Course c1 = new Course { Name = "Algoritms" };
                Course c2 = new Course { Name = "Data base course" };
                db.Courses.AddRange(new List<Course> { c1,c2 });

                db.SaveChanges();

                //add courses to the students
                s1.StudentCourses.Add(new StudentCourse { CourseId = c1.Id, StudentId = s1.Id });
                s2.StudentCourses.Add(new StudentCourse { CourseId = c1.Id, StudentId = s2.Id });
                s2.StudentCourses.Add(new StudentCourse { CourseId = c2.Id, StudentId = s2.Id });
                db.SaveChanges();

                var courses = db.Courses.Include(c => c.StudentCourses).ThenInclude(sc => sc.Student).ToList();

                //print all courses
                foreach (var item in courses)
                {
                    Console.WriteLine($"\n Course: {item.Name}");
                    //print all students for certain course
                    var students = item.StudentCourses.Select(sc => sc.Student).ToList();
                    foreach (Student s in students)
                    {
                        Console.WriteLine($"{s.Name}");
                    }
                }
            }
        }
    }
}
