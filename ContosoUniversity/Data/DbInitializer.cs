using ContosoUniversity.Data;
using ContosoUniversity.Models;
using System;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {

            bool isDatabaseAllreadySeeded = context.Students.Any() && 
                context.Courses.Any() && 
                context.Enrollments.Any();

            // Look for any students.
            if (isDatabaseAllreadySeeded)
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{FirstMidName="Emma",LastName="Anderson",EnrollmentDate=DateTime.Parse("2020-08-10")},
                new Student{FirstMidName="Martin",LastName="Petrov",EnrollmentDate=DateTime.Parse("2019-08-10")},
                new Student{FirstMidName="Victoria",LastName="Kancheva",EnrollmentDate=DateTime.Parse("2019-08-10")},
                new Student{FirstMidName="Kris",LastName="Kanchev",EnrollmentDate=DateTime.Parse("2020-08-10")},
                new Student{FirstMidName="Todor",LastName="Todorov",EnrollmentDate=DateTime.Parse("2019-08-10")},
                new Student{FirstMidName="Isabella",LastName="Morison",EnrollmentDate=DateTime.Parse("2020-08-10")},
                new Student{FirstMidName="Alexander",LastName="Konstantinov",EnrollmentDate=DateTime.Parse("2020-08-10")},
                new Student{FirstMidName="Cvetelina",LastName="Aleksieva",EnrollmentDate=DateTime.Parse("2019-08-10")}
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var instructors = new Instructor[]
          {
                new Instructor { FirstMidName = "Alexander", LastName = "Trifonov",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstMidName = "Radostin", LastName = "Raikov",
                    HireDate = DateTime.Parse("1990-02-22") },
                new Instructor { FirstMidName = "Kristiqn", LastName = "Vachkov",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstMidName = "Gabriel", LastName = "Atanasov",   
                    HireDate = DateTime.Parse("2001-11-15") },
                new Instructor { FirstMidName = "Mariq", LastName = "Litova",
                    HireDate = DateTime.Parse("2004-02-12") }
          };

            context.Instructors.AddRange(instructors);
            context.SaveChanges();

            var departments = new Department[]
           {
                new Department { Name = "English",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Trifonov").ID },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Raikov").ID },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Vachkov").ID },
                new Department { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Atanasov").ID },
           };

            context.Departments.AddRange(departments);
            context.SaveChanges();

            var courses = new Course[]
            {
                  new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                },
                new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new Course {CourseID = 1045, Title = "Calculus",       Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Course {CourseID = 2021, Title = "Composition",    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                },
                new Course {CourseID = 2042, Title = "Literature",     Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                },
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
           {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Atanasov").ID,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Litova").ID,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Raikov").ID,
                    Location = "Thompson 304" },
           };

            context.OfficeAssignments.AddRange(officeAssignments);
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Atanasov").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Vachkov").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Litova").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Litova").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Raikov").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Vachkov").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Trifonov").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Literature" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Trifonov").ID
                    },
            };

            context.CourseAssignments.AddRange(courseInstructors);
            context.SaveChanges();



            var enrollments = new Enrollment[]
            {
                //new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
                //new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
                //new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
                //new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
                //new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
                //new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
                //new Enrollment{StudentID=3,CourseID=1050},
                //new Enrollment{StudentID=4,CourseID=1050},
                //new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
                //new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
                //new Enrollment{StudentID=6,CourseID=1045},
                //new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
                   new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Anderson").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    Grade = Grade.B
                },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Anderson").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                    Grade = Grade.A
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Anderson").ID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    Grade = Grade.A
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Petrov").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Petrov").ID,
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Petrov").ID,
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                    Grade = Grade.D
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kancheva").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    Grade = Grade.A
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kancheva").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                    Grade = Grade.B
                    },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kanchev").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Todorov").ID,
                    CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Morison").ID,
                    CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                    Grade = Grade.A
                    }
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}