using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem
{
    public delegate void Notify(params dynamic[] massage);

    internal class MainDriverClass
    {
        static void Main(string[] args)
        {
            HandlerClass handler = new HandlerClass();
            handler.processCompleted += eventHandlerFunction;

            FileManager fileManager = new FileManager();

            List<dynamic> studentList = fileManager.readFiles("students.json", "student");
            List<dynamic> semesterList = fileManager.readFiles("semesters.json", "semester");
            List<dynamic> courseList = fileManager.readFiles("courses.json", "course");

            Console.WriteLine("Welcome to the Student Management System\n");
            while (true)
            {
                label:

                displayInformation(studentList, "student");

                int option = firstWorkFlowInput();
                if (option > 3) break;
                else
                {
                    if (option == 1)
                    {
                        Student obj = handler.inputStudent();
                        studentList.Add(obj);

                        if (!semesterList.Any(item => item.semesterCode.ToLower() == obj.joiningBatch.semesterCode.ToLower() && 
                            item.year.ToLower() == obj.joiningBatch.year.ToLower())) {
                            semesterList.Add(obj.joiningBatch);
                        }
                    }
                    else if (option == 2)
                    {
                        Console.WriteLine("Enter Student id.");
                        string id = Console.ReadLine();

                        int index = specificStudentIndex(studentList, id);

                        if (index == -1) Console.WriteLine("Student not found.\n");
                        else
                        {
                            studentList[index].getFormatedOutput();

                            option = semesterOptionChooser();
                            if (option == 2)
                            {
                                goto label;
                            }
                            else if (option > 2)
                            {
                                break;
                            }
                            else
                            {
                                displayInformation(semesterList, "semester");
                                Console.WriteLine("(if semester not in list just give the new semester code and year).");

                                Semester obj = handler.inputSemester();

                                bool flag = true;
                                foreach (var semester in semesterList)
                                {
                                    if (semester.semesterCode.ToLower() == obj.semesterCode.ToLower() && semester.year.ToLower() == obj.year.ToLower())
                                    {
                                        flag = false;
                                    }
                                }

                                if (flag)
                                {
                                    semesterList.Add(obj);
                                    studentList[index].attendedSemester.Add(obj.createDeepCopy());
                                }
                                else if(studentList[index].attendedSemester.Count == 0)
                                {
                                    studentList[index].attendedSemester.Add(obj.createDeepCopy());
                                }
                            }

                            displayInformation(courseList, "course");
                            Console.WriteLine("Enter number of courses be added");
                            int n = Convert.ToInt32(Console.ReadLine());

                            List<Course> chosenCourses = new List<Course>();
                            for(int i = 0; i < n; i++)
                            {
                                Console.WriteLine("Enter CourseID");
                                string courseId = Console.ReadLine();

                                foreach(var course in courseList)
                                {
                                    if(course.courseID == courseId)
                                    {
                                        chosenCourses.Add(course.createDeepCopy());
                                    }
                                }
                            }
                            if(chosenCourses.Count != 0) studentList[index].courseInEachSemester.Add(chosenCourses);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter Student id");
                        string id = Console.ReadLine();

                        int index = specificStudentIndex(studentList, id);
                        if(index != -1) studentList.RemoveAt(index);
                    }
                }
            }

            fileManager.writeFiles("semesters.json", semesterList);
            fileManager.writeFiles("students.json", studentList);
            Console.WriteLine("Thanks for using our service");
        }

        private static int semesterOptionChooser()
        {
            Console.WriteLine("Press 1 for : Add semester.");
            Console.WriteLine("Press 2 for : Return Home Page.");
            Console.WriteLine("Press Any other key to exit the application.\n");

            string choice = Console.ReadLine();
            int option;

            try
            {
                option = Convert.ToInt32(choice);
            }
            catch
            {
                option = 3;
            }

            return option;
        }

        private static int specificStudentIndex(List<dynamic> studentList, string id)
        {
            int index = -1, i = 0;
            foreach (var student in studentList)
            {
                if (student.studentID == id)
                {
                    index = i;
                }
                i++;
            }

            return index;
        }

        private static void displayInformation(List<dynamic> lists, string type)
        {
            Console.WriteLine($"Existing {type} are: ");

            if (lists.Count == 0) Console.WriteLine($"No {type} exits till now");

            foreach(var list in lists)
            {
                if(type == "student")
                {
                    Console.WriteLine($"{list.studentID} | {list.firstName}");
                }
                else if(type == "semester")
                {
                    Console.WriteLine($"{list.semesterCode} | {list.year}");
                }
                else
                {
                    Console.WriteLine($"{list.courseID} | {list.courseName}");
                }
            }
            Console.WriteLine();
        }

        private static int firstWorkFlowInput()
        {
            Console.WriteLine("Choose your desired option from below:");
            Console.WriteLine("Press 1 for : Add Student.");
            Console.WriteLine("Press 2 for : View Student Details.");
            Console.WriteLine("Press 3 for : Delete Specific Student Details.");
            Console.WriteLine("Press Any other Key for exit.\n");

            string input = Console.ReadLine();
            int choice;
            try
            {
                choice = Convert.ToInt32(input);
            }
            catch
            {
                choice = 4;
            }

            return choice;
        }

        static void eventHandlerFunction(params dynamic[] massages)
        {
            foreach (var massage in massages)
            {
                Console.Write($"{massage} | ");
            }
            Console.WriteLine();
        }

    }
}
